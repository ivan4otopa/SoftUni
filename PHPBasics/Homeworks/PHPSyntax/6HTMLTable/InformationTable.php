<?php
$name = 'Pesho';
$phoneNumber = '0884-888-888';
$age = 67;
$address = 'Suhata Reka';
?>

<!DOCTYPE html>
<html>
<head>
	<title>InformationTable</title>
	<link rel="stylesheet" href="styles/InformationTable.css">
</head>
<body>
	<table>
		<tr>
			<td>Name</td>
			<td>
				<?php echo $name; ?>
			</td>
		</tr>
		<tr>
			<td>Phone Number</td>
			<td>
				<?php echo $phoneNumber; ?>
			</td>
		</tr>
		<tr>
			<td>Age</td>
			<td>
				<?php echo $age; ?>
			</td>
		</tr>
		<tr>
			<td>Address</td>
			<td>
				<?php echo $address; ?>
			</td>
		</tr>
	</table>
</body>
</html>