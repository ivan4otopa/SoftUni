package bg.jwd.bank.entities;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;

import bg.jwd.bank.utils.UserUtils;

@Entity
@Table(name = "accounts")
public class Account {
	@Id
	private long id;
	private String username;
	@Column(name = "account_no")
	private long accountNumber;
	private double amount;
	private String currency;
	@Column(name = "created_by")
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
