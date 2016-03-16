package bg.jwd.bank.daos;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.HashMap;
import java.util.Map;

import org.springframework.stereotype.Repository;

import bg.jwd.bank.constants.DatabaseConstants;
import bg.jwd.bank.entities.ExchangeRate;
import bg.jwd.bank.utils.UserUtils;

@Repository
public class OperationDaoImpl implements OperationDao {
	private static Map<String, ExchangeRate> exchangeRates = new HashMap<>();
	
	static {
		ExchangeRate bulgarianExchangeRate = new ExchangeRate();
		ExchangeRate europeanExchangeRate = new ExchangeRate();
		
		bulgarianExchangeRate.setCurrency("BGN");
		bulgarianExchangeRate.setRate(0.51);
		europeanExchangeRate.setCurrency("EUR");
		europeanExchangeRate.setRate(1.95);
		
		exchangeRates.put("EUR", bulgarianExchangeRate);
		exchangeRates.put("BGN", europeanExchangeRate);
		
		try {
			Class.forName("oracle.jdbc.OracleDriver");
		} catch (ClassNotFoundException e) {
			e.printStackTrace();
		}
	}
	
	@Override
	public boolean deposit(long accountNumber, double amount, String currency) {
		String accountCurrency = "";
		
		String getCurrencySql = "SELECT currency FROM accounts WHERE account_no = ?";
		
		try (Connection connection = DriverManager.getConnection(
				DatabaseConstants.URL,
				DatabaseConstants.USERNAME,
				DatabaseConstants.PASSWORD);
			PreparedStatement statement = connection.prepareStatement(getCurrencySql);) {
			statement.setLong(1, accountNumber);
			
			ResultSet resultSet = statement.executeQuery();
			
			if (resultSet.next()) {
				accountCurrency = resultSet.getString("currency");
			} else {
				return false;
			}
		} catch (SQLException e) {
			e.printStackTrace();
			
			return false;
		}		
		
		if (!accountCurrency.equals(currency)) {
			ExchangeRate exchangeRate = exchangeRates.get(accountCurrency);
			
			amount *= exchangeRate.getRate();
		}
		
		String updateAmountSql = "UPDATE accounts SET amount = amount + ? WHERE account_no = ?";
		
		try (Connection connection = DriverManager.getConnection(
				DatabaseConstants.URL,
				DatabaseConstants.USERNAME,
				DatabaseConstants.PASSWORD);
			PreparedStatement statement = connection.prepareStatement(updateAmountSql);) {
			statement.setDouble(1, amount);
			statement.setLong(2, accountNumber);
			statement.executeQuery();
		} catch (SQLException e) {
			e.printStackTrace();
			
			return false;
		}
		
		return insertOperation(accountNumber, amount, currency, "deposit");
	}

	@Override
	public boolean withdraw(long accountNumber, double amount, String currency) {
		String accountCurrency = "";
		
		double accountAmount = 0;
		
		String getCurrencyAndAmountSql = "SELECT currency, amount FROM accounts WHERE account_no = ?";
		
		try (Connection connection = DriverManager.getConnection(
				DatabaseConstants.URL,
				DatabaseConstants.USERNAME,
				DatabaseConstants.PASSWORD);
			PreparedStatement statement = connection.prepareStatement(getCurrencyAndAmountSql);) {
			statement.setLong(1, accountNumber);
			
			ResultSet resultSet = statement.executeQuery();
			
			if (resultSet.next()) {
				accountCurrency = resultSet.getString("currency");
				accountAmount = resultSet.getDouble("amount");
			} else {
				return false;
			}
		} catch (SQLException e) {
			e.printStackTrace();
			
			return false;
		}		
		
		if (amount <= 0.5 * accountAmount) {
			if (!accountCurrency.equals(currency)) {
				ExchangeRate exchangeRate = exchangeRates.get(accountCurrency);
				
				amount *= exchangeRate.getRate();
			}
			
			String updateAmountSql = "UPDATE accounts SET amount = amount - ? WHERE account_no = ?";
			
			try (Connection connection = DriverManager.getConnection(
					DatabaseConstants.URL,
					DatabaseConstants.USERNAME,
					DatabaseConstants.PASSWORD);
				PreparedStatement statement = connection.prepareStatement(updateAmountSql);) {
				statement.setDouble(1, amount);
				statement.setLong(2, accountNumber);
				statement.executeQuery();
			} catch (SQLException e) {
				e.printStackTrace();
				
				return false;
			}
			
			return true;
		}
		
		return !insertOperation(accountNumber, amount, currency, "withdraw");
	}
	
	private boolean insertOperation(long accountNumber, Double amount, String currency, String operation) {
		String insertOperationSql = "INSERT INTO operations (id, account_no, operation, amount, currency, performed_by)" +
				"VALUES (?, ?, ?, ?, ?, ?)";
		
		try (Connection connection = DriverManager.getConnection(
				DatabaseConstants.URL,
				DatabaseConstants.USERNAME,
				DatabaseConstants.PASSWORD);
			PreparedStatement statement = connection.prepareStatement(insertOperationSql);) {
			statement.setLong(1, 1);
			statement.setLong(2, accountNumber);
			statement.setString(3, operation);
			statement.setDouble(4, amount);
			statement.setString(5, currency);
			statement.setString(6, UserUtils.getUser().getUsername());
			statement.executeQuery();
		} catch (SQLException e) {
			e.printStackTrace();
			
			return false;
		}
		
		return true;
	}
}
