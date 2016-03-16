package bg.jwd.bank.daos;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.List;

import org.springframework.stereotype.Repository;

import bg.jwd.bank.constants.DatabaseConstants;
import bg.jwd.bank.entities.Account;
import bg.jwd.bank.utils.UserUtils;

@Repository
public class AccountDaoImpl implements AccountDao{
	static {
		try {
			Class.forName("oracle.jdbc.OracleDriver");
		} catch (ClassNotFoundException e) {
			e.printStackTrace();
		}
	}
	
	@Override
	public List<Account> getAccounts() {
		List<Account> accounts = new ArrayList<>();
		
		try (Connection connection = DriverManager.getConnection(
				DatabaseConstants.URL,
				DatabaseConstants.USERNAME,
				DatabaseConstants.PASSWORD);
			Statement statement = connection.createStatement();) {
			String sql = "SELECT account_no, username, amount, currency, created_by FROM accounts";
			ResultSet resultSet = statement.executeQuery(sql);
			
			while (resultSet.next()) {
				Account account = new Account();
				
				account.setAccountNumber(resultSet.getLong("account_no"));
				account.setUsername(resultSet.getString("username"));
				account.setAmount(resultSet.getDouble("amount"));
				account.setCurrency(resultSet.getString("currency"));
				account.setCreatedBy(resultSet.getString("created_by"));
				
				accounts.add(account);
			}
		} catch (SQLException e) {
			e.printStackTrace();
			
			return null;
		}
		
		return accounts;
	}

	@Override
	public boolean addAccount(Account account) {
		String sql = "INSERT INTO accounts (id, account_no, username, amount, currency, created_by) VALUES (?, ?, ?, ?, ?, ?)";
		
		try (Connection connection = DriverManager.getConnection(
				DatabaseConstants.URL,
				DatabaseConstants.USERNAME,
				DatabaseConstants.PASSWORD);
			PreparedStatement statement = connection.prepareStatement(sql);) {
			statement.setLong(1, 1);
			statement.setLong(2, account.getAccountNumber());
			statement.setString(3, account.getUsername());
			statement.setDouble(4, account.getAmount());
			statement.setString(5, account.getCurrency());
			statement.setString(6, UserUtils.getUser().getUsername());
			statement.executeQuery();
		} catch (SQLException e) {
			e.printStackTrace();
			
			return false;
		}
		
		return true;
	}
}