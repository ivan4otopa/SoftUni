package bg.jwd.ejbs;

import javax.ejb.Local;

@Local
public interface Banking {
	void setAccount(String accountName, double amount, String currency);
	
	String getAccountName();
	
	void setAccountName(String accountName);
	
	double getAmount();
	
	void setAmount(double amount);
	
	String getCurrency();
	
	void setCurrency(String currency);
	
	void withdraw(double amount, String currency);
	
	void deposit(double amount, String currency);
}
