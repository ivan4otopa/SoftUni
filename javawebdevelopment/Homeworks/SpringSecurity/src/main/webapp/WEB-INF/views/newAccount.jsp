<html>
<head>
	<title>New Account</title>
</head>
<body>
	<form action="addAccount" method="POST" modelAttribute="account">
		Username <input type="text" name="username" /><br />
		Account Number <input type="text" name="accountNumber" /><br />
		Initial Amount <input type="text" name="amount" /><br />
		Account Currency <input type="text" name="currency" /><br />
		<input type="submit" value="Submit" />
	</form>
</body>
</html>