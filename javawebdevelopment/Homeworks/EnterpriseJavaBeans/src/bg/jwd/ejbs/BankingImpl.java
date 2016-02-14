package bg.jwd.ejbs;

import javax.ejb.Stateful;

@Stateful
public class BankingImpl implements Banking {
	private String accountName;
	private double amount;
	private String currency;
	
	@Override
	public void setAccount(String accountName, double amount, String currency) {
		this.setAccountName(accountName);
		this.setAmount(amount);
		this.setCurrency(currency);
	}
	
	@Override
	public String getAccountName() {
		return this.accountName;
	}
	
	@Override
	public void setAccountName(String accountName) {
		this.accountName = accountName;
	}
	
	@Override
	public double getAmount() {
		return this.amount;
	}
	
	@Override
	public void setAmount(double amount) {
		this.amount = amount;
	}
	
	@Override
	public String getCurrency() {
		return this.currency;
	}
	
	@Override
	public void setCurrency(String currency) {
		this.currency = currency;
	}

	@Override
	public void withdraw(double amount, String currency) {
		if (this.currency.equals("leva")) {
			if (currency.equals("euro")) {
				amount *= 1.96;
			} else if (currency.equals("dollar")) {
				amount *= 1.73;
			}
		} else if (this.currency.equals("euro")) {
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
		
		this.amount -= amount;
	}

	@Override
	public void deposit(double amount, String currency) {		
		if (this.currency.equals("leva")) {
			if (currency.equals("euro")) {
				amount *= 1.96;
			} else if (currency.equals("dollar")) {
				amount *= 1.73;
			}
		} else if (this.currency.equals("euro")) {
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
		
		this.amount += amount;
	}
}
