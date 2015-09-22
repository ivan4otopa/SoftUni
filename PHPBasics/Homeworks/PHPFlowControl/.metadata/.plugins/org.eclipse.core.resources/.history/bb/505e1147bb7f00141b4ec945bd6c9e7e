<?php
$sum = 0;
?>
<!DOCTYPE html>
<html>
	<head>
		<title>SquareRootSum</title>
		<link rel="stylesheet" href="styles/SquareRootSum.css" />
	</head>
	<body>
		<table>
			<thead>
				<tr>
					<th>Number</th>
					<th>Square</th>
				</tr>
			</thead>
			<tbody>
				<?php for($i = 0; $i <= 100; $i += 2): 
				$square = number_format(sqrt($i), 2);
				$sum += $square;
				?>
				<tr>
					<td><?= $i; ?></td>
					<td><?= $square; ?></td>
				</tr>
				<?php endfor; ?>
			</tbody>
			<tfoot>
				<tr>
					<td><b>Total:</b></td>
					<td><?= $sum  ?></td>
				</tr>
			</tfoot>
		</table>
	</body>
</html>