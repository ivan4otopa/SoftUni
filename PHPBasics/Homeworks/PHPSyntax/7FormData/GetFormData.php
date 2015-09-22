<!DOCTYPE html>
<html>
<head>
	<title>FormData</title>
	<link rel="stylesheet" href="styles/GetFormData.css">
</head>
<body>
	<form method="get">
		<input type="text" name="name" placeholder="Name.."/>
		<input type="text" name="age" placeholder="Age.."/>
		<input type="radio" name="gender" value="male" id="male"/>
		<label for="male">Male</label><br />
		<input type="radio" name="gender" value="female" id="female"/>
		<label for="female">Female</label><br />
		<button>Submit</button>
	</form>
	<?php
	if(isset($_GET['name']) && isset($_GET['age']) && isset($_GET['gender']))
		echo "My name is " . $_GET['name'] . ". I am " . $_GET['age'] . " years old. I am " . $_GET['gender'] . '.';
	?>
</body>
</html>