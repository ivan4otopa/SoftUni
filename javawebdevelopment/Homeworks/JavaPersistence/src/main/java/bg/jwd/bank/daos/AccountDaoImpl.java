package bg.jwd.bank.daos;

import java.util.List;

import org.hibernate.Criteria;
import org.hibernate.SessionFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

import bg.jwd.bank.entities.Account;

@Repository
public class AccountDaoImpl implements AccountDao {
	@Autowired
	private SessionFactory sessionFactory;
	
	@Override
	public List<Account> getAccounts() {
		Criteria criteria = sessionFactory.openSession().createCriteria(Account.class);
		
		return criteria.list();
	}

	@Override
	public boolean addAccount(Account account) {
//		Session session = sessionFactory.openSession();
//		Transaction tx = session.beginTransaction();
//		
//		session.save(account);
//		tx.commit();
//		session.close();
//		
		return true;
	}
}