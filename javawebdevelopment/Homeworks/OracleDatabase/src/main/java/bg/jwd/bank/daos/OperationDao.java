package bg.jwd.bank.daos;

public interface OperationDao {
	boolean deposit(long accountNumber, double amount, String currency);
	
	boolean withdraw(long accountNumber, double amount, String currency);
}
