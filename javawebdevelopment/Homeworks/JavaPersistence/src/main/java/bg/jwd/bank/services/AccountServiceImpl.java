package bg.jwd.bank.services;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import bg.jwd.bank.entities.Account;
import bg.jwd.bank.daos.AccountDao;

@Service
public class AccountServiceImpl implements AccountService {
	@Autowired
	private AccountDao accountDao;
	
	@Override
	public List<Account> getAccounts() {		
		return accountDao.getAccounts();
	}
	
	@Override
	public boolean addAccount(Account account) {
		return accountDao.addAccount(account);
	}
}
