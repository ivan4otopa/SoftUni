package bg.jwd.springmvc.services;

import org.springframework.stereotype.Service;

import bg.jwd.springmvc.entities.Account;

@Service
public class AccountServiceImpl implements AccountService {
	private Account account;
	
	@Override
	public void createAccount(String name, double amount, String currency) {
		this.account = new Account(name, amount, currency);		
	}

	@Override
	public void withdraw(double amount, String currency) {
		amount = this.convertAmount(amount, currency);
		
		this.account.setAmount(this.account.getAmount() - amount);
	}

	@Override
	public void deposit(double amount, String currency) {
		amount = this.convertAmount(amount, currency);
		
		this.account.setAmount(this.account.getAmount() + amount);
	}
	
	public Account getAccount() {
		return this.account;
	}
	
	public boolean exists() {
		return this.account != null;
	}
	
	private double convertAmount(double amount, String currency) {
		if (this.account.getCurrency().equals("leva")) {
			if (currency.equals("euro")) {
				amount *= 1.96;
			} else if (currency.equals("dollar")) {
				amount *= 1.73;
			}
		} else if (this.account.getCurrency().equals("euro")) {
			if (currency.equals("leva")) {
				amount *= 0.511;
			} else if (currency.equals("dollar")) {
				amount *= 1.13;
			}
		} else {
			if (currency.equals("leva")) {
				amount *= 0.58;
			} else if (currency.equals("euro")) {
				amount *= 0.89;
			}
		}
		
		return amount;
	}
}
