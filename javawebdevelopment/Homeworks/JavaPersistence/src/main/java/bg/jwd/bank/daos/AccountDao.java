package bg.jwd.bank.daos;

import java.util.List;

import bg.jwd.bank.entities.Account;

public interface AccountDao {
	List<Account> getAccounts();
	
	boolean addAccount(Account account);
}