package bg.jwd.bank.services;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import bg.jwd.bank.daos.OperationDao;

@Service
public class OperationServiceImpl implements OperationService {
	@Autowired
	private OperationDao operationDao;
	
	@Override
	public boolean deposit(long accountNumber, double amount, String currency) {
		return operationDao.deposit(accountNumber, amount, currency);
	}
	
	@Override
	public boolean withdraw(long accountNumber, double amount, String currency) {
		return operationDao.withdraw(accountNumber, amount, currency);
	}
}
