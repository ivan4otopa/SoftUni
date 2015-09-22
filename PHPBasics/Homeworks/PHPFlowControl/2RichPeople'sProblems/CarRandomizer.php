<?php
$colors = array('yellow', 'green', 'black');
$quantities = array(1, 2, 3, 4, 5);
?>
<!DOCTYPE html>
<html>
	<head>
		<title>CarRandomizer</title>
		<link rel="stylesheet" href="styles/CarRandomizer.css" />
	</head>
	<body>
		<form method="get">
			<label>Enter Cars</label>
			<input type="text" name="cars" />
			<button>Show result</button>
		</form>
		<?php
		if(isset($_GET['cars'])):
			$cars = explode(', ', $_GET['cars']);
		?>
		<table>
			<thead>
				<tr>
					<th>Car</th>
					<th>Color</th>
					<th>Quantity</th>
				</tr>
			</thead>
			<tbody>
				<?php foreach ($cars as $value): ?>
				<tr>
					<td><?= $value; ?></td>
					<td><?= $colors[array_rand($colors, 1)]; ?></td>
					<td><?= $quantities[array_rand($quantities, 1)]; ?></td>
				</tr>
				<?php endforeach; ?>
			</tbody>
		</table>
		<?php endif; ?>
	</body>
</html>