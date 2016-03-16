package bg.jwd.bank.entities;

import bg.jwd.bank.utils.UserUtils;

public class Account {
	private String username;
	private long accountNumber;
	private double amount;
	private String currency;
	private String createdBy;
	
	public Account(String username, long accountNumber, double amount, String currency) {
		this.setUsername(username);
		this.setAccountNumber(accountNumber);
		this.setAmount(amount);
		this.setCurrency(currency);
		this.setCreatedBy(UserUtils.getUser().getUsername());
	}
	
	public Account() {
	}
	
	public String getUsername() {
		return username;
	}
	
	public void setUsername(String username) {
		this.username = username;
	}
	
	public long getAccountNumber() {
		return accountNumber;
	}
	
	public void setAccountNumber(long accountNumber) {
		this.accountNumber = accountNumber;
	}
	
	public double getAmount() {
		return amount;
	}
	
	public void setAmount(double amount) {
		this.amount = amount;
	}
	
	public String getCurrency() {
		return currency;
	}
	
	public void setCurrency(String currency) {
		this.currency = currency;
	}
	
	public String getCreatedBy() {
		return createdBy;
	}
	
	public void setCreatedBy(String createdBy) {
		this.createdBy = createdBy;
	}
}
