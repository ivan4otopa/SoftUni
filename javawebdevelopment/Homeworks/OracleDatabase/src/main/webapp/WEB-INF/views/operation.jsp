<html>
<head>
	<title>Operation</title>
</head>
<body>
	<form action="doOperation" method="POST" modelAttribute="operation">
		Account Number <input type="text" name="accountNumber" /><br />
		Operation <input type="radio" name="operation" value="deposit" /> Deposit <input type="radio" name="operation" value="withdraw" /> Withdraw<br />
		Amount <input type="text" name="amount" /><br />
		Currency <input type="text" name="currency" /><br />
		<input type="submit" value="Submit" />
	</form>
</body>
</html>