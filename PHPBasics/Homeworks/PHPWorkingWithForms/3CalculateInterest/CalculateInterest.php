<!DOCTYPE html>
<html>
<head>
	<title>CalculateInterest</title>
	<link rel="stylesheet" href="styles/CalculateInterest.css" />
</head>
<body>
	<form method="get">
		<label>Enter Amount</label>
		<input type="text" name="amount" /><br>
		<input type="radio" name="currency" value="usd" id="usd" />
		<label for="usd">USD</label>
		<input type="radio" name="currency" value="eur" id="eur" />
		<label for="eur">EUR</label>
		<input type="radio" name="currency" value="bgn" id="bgn" />
		<label for="bgn">BGN</label><br>
		<label>Compound Interest Amount</label>
		<input type="text" name="interest" />
		<select name="period">
			<option>6 Months</option>
			<option>1 Year</option>
			<option>2 Years</option>
			<option>5 Years</option>
		</select>
		<button>Calculate</button>
	</form>
	<?php
	if(isset($_GET['amount']) && isset($_GET['currency']) && isset($_GET['interest']) && isset($_GET['period'])) {
		$amount = $_GET['amount'];
		$currency = $_GET['currency'];
		$interest = $_GET['interest'];
		$period = $_GET['period'];
		$interestPerMonth = $interest / 12;
		if($period == '6 Months') {
			for($i = 0; $i < 6; $i++)
				$amount *= ($interestPerMonth + 100) / 100;
		}
		if($period == '1 Year') {
			for($i = 0; $i < 12; $i++)
				$amount *= ($interestPerMonth + 100) / 100;
		}
		if($period == '2 Years') {
			for($i = 0; $i < 24; $i++)
				$amount *= ($interestPerMonth + 100) / 100;
		}
		if($period == '5 Years') {
			for($i = 0; $i < 60; $i++)
				$amount *= ($interestPerMonth + 100) / 100;
		}
		$amount = number_format($amount, 2, '.', '');
		if($currency == 'usd')
			echo '$ ' . $amount;
		if($currency == 'eur')
			echo '€ ' . $amount;
		if($currency == 'bgn')
			echo $amount . ' лв';
	}
	?>
</body>
</html>