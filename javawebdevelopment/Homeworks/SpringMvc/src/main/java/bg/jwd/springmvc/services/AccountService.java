package bg.jwd.springmvc.services;

import bg.jwd.springmvc.entities.Account;

public interface AccountService {
	void createAccount(String name, double amount, String currency);
	
	void withdraw(double amount, String currency);
	
	void deposit(double amount, String currency);
	
	Account getAccount();
	
	boolean exists();
}
