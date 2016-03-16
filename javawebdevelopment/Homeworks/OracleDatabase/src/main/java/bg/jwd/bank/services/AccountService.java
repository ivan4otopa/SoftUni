package bg.jwd.bank.services;

import java.util.List;

import bg.jwd.bank.entities.Account;

public interface AccountService {
	List<Account> getAccounts();
	
	boolean addAccount(Account account);
}
