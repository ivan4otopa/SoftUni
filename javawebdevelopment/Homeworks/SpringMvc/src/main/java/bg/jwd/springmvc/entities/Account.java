package bg.jwd.springmvc.entities;

public class Account {
	private String name;
	private double amount;
	private String currency;
	
	public Account(String name, double amount, String currency) {
		this.setName(name);
		this.setAmount(amount);
		this.setCurrency(currency);		
	}
	
	public String getName() {
		return this.name;
	}
	
	public void setName(String name) {
		this.name = name;
	}
	
	public double getAmount() {
		return this.amount;
	}
	
	public void setAmount(double amount) {
		this.amount = amount;
	}
	
	public String getCurrency() {
		return this.currency;
	}
	
	public void setCurrency(String currency) {
		this.currency = currency;
	}
}
