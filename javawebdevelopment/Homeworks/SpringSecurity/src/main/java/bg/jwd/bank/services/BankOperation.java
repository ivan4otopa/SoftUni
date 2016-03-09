package bg.jwd.bank.services;

import java.util.List;

import bg.jwd.bank.entities.Account;

public interface BankOperation {
	void addAccount(Account account);
	
	void deposit(long accountNumber, double amount, String currency);
	
	void withdraw(long accountNumber, double amount, String currency);
	
	List<Account> getAccounts();
}
