package bg.jwd.bank.services;

public interface OperationService {
	boolean deposit(long accountNumber, double amount, String currency);
	
	boolean withdraw(long accountNumber, double amount, String currency);
}
