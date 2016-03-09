package bg.jwd.bank.services;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import org.springframework.security.core.authority.SimpleGrantedAuthority;
import org.springframework.stereotype.Service;

import bg.jwd.bank.entities.Account;
import bg.jwd.bank.entities.ExchangeRate;
import bg.jwd.bank.security.User;
import bg.jwd.bank.utils.UserUtils;

@Service
public class BankOperationImpl implements BankOperation {
	private Map<Long, Account> accounts = new HashMap<>();
	private Map<User, Account> userAccounts = new HashMap<>();
	private static Map<String, ExchangeRate> exchangeRates = new HashMap<>();
	
	static {
		ExchangeRate bulgarianExchangeRate = new ExchangeRate();
		ExchangeRate europeanExchangeRate = new ExchangeRate();
		
		bulgarianExchangeRate.setCurrency("BGN");
		bulgarianExchangeRate.setRate(0.51);
		europeanExchangeRate.setCurrency("EUR");
		europeanExchangeRate.setRate(1.95);
		
		exchangeRates.put("EUR", bulgarianExchangeRate);
		exchangeRates.put("BGN", europeanExchangeRate);
	}
	
	@Override
	public void deposit(long accountNumber, double amount, String currency) {
		Account account = accounts.get(accountNumber);
		
		if (account != null) {
			if (!account.getCurrency().equals(currency)) {
				ExchangeRate exchangeRate = exchangeRates.get(account.getCurrency());
				
				amount *= exchangeRate.getRate();
			}
			
			account.setAmount(account.getAmount() + amount);
		}
	}

	@Override
	public void withdraw(long accountNumber, double amount, String currency) {
		Account account = accounts.get(accountNumber);
		
		if (account != null && account.getAmount() - amount >= 0) {
			if (!account.getCurrency().equals(currency)) {
				ExchangeRate exchangeRate = exchangeRates.get(account.getCurrency());
				
				amount *= exchangeRate.getRate();
			}
			
			account.setAmount(account.getAmount() - amount);
		}
	}

	@Override
	public void addAccount(Account account) {
		Account newAccount = new Account(account.getUsername(), account.getAccountNumber(), account.getAmount(), account.getCurrency());
		User currentUser = UserUtils.getUser();
		
		accounts.put(account.getAccountNumber(), newAccount);
		userAccounts.put(currentUser, account);
	}

	@Override
	public List<Account> getAccounts() {		
		if (UserUtils.getUser().getAuthorities().contains(new SimpleGrantedAuthority("ROLE_BANK_EMPLOYEE"))) {
			return new ArrayList<>(accounts.values());
		} else if (UserUtils.getUser().getAuthorities().contains(new SimpleGrantedAuthority("ROLE_USER"))) {
			List<Account> currentUserAccounts = new ArrayList<>();			
			User currentUser = UserUtils.getUser();
			
			for (User user : userAccounts.keySet()) {
				if (user.equals(currentUser)) {
					currentUserAccounts.add(userAccounts.get(user));
				}
			}
			
			return currentUserAccounts;
		}
		
		return null;
	}
}
