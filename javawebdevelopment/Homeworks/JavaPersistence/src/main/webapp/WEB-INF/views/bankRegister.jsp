<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@ taglib prefix="sec" uri="http://www.springframework.org/security/tags" %>

<html>
<head>
	<title>Bank Register</title>
</head>
<body>
	<sec:authorize access="hasRole('ROLE_BANK_EMPLOYEE')">
		<button onclick="location = '/bank/newAccount'">New Account</button>
	</sec:authorize>
	<table border="1">
		<thead>
			<tr>
				<th>Username</th>
				<th>Account Number</th>
				<th>Current Amount</th>
				<th>Account Currency</th>
				<th>Created By</th>
			</tr>
		</thead>
		<tbody>		
			<c:if test='${ not empty accounts }'>
				<c:forEach var="account" items="${ accounts }">
					<tr>
						<td>${ account.username }</td>
						<td>${ account.accountNumber }</td>
						<td>${ account.amount }</td>
						<td>${ account.currency }</td>
						<td>${ account.createdBy }</td>	
					</tr>
				</c:forEach>
			</c:if>
		</tbody>
	</table>
	<sec:authorize access="hasRole('ROLE_USER')">
		<button onclick="location = '/bank/operation'">Operation</button><br />
	</sec:authorize>
	<button onclick="location = '/bank/login?logout'">Logout</button>
</body>
</html>