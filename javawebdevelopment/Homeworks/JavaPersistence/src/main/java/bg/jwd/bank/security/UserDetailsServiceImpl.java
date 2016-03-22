package bg.jwd.bank.security;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

import org.springframework.security.core.GrantedAuthority;
import org.springframework.security.core.authority.SimpleGrantedAuthority;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.security.core.userdetails.UsernameNotFoundException;

import bg.jwd.bank.constants.DatabaseConstants;

public class UserDetailsServiceImpl implements UserDetailsService {
	static {
		try {
			Class.forName("oracle.jdbc.OracleDriver");
		} catch (ClassNotFoundException e) {
			e.printStackTrace();
		}
	}
	
	@Override
	public UserDetails loadUserByUsername(String username) throws UsernameNotFoundException {
		List<GrantedAuthority> authorities = new ArrayList<>();
		String getUserSql = "SELECT password, role FROM users WHERE username = ?";
		
		try (Connection connection = DriverManager.getConnection(
				DatabaseConstants.URL,
				DatabaseConstants.USERNAME,
				DatabaseConstants.PASSWORD);
			PreparedStatement statement = connection.prepareStatement(getUserSql);) {
			statement.setString(1, username);
			
			ResultSet resultSet = statement.executeQuery();
			
			if (resultSet.next()) {
				String role = "ROLE_" + resultSet.getString("role");
				
				authorities.add(new SimpleGrantedAuthority(role));
				
				return new User(username, resultSet.getString("password"), authorities);
			}
		} catch (SQLException e) {
			e.printStackTrace();
			
			return null;
		}		
		
		return null;
	}
}
