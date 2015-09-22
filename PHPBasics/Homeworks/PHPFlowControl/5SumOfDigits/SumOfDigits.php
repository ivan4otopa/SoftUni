<?php
function digitsSum($number) {
	$sum = 0;
	$digit = 0;
	while($number > 0) {
		$digit = $number % 10;
		$number /= 10;
		$sum += $digit;
	}
	return $sum;
}
?>
<!DOCTYPE html>
<html>
	<head>
		<title>SumOfDigits</title>
		<link rel="stylesheet"href="styles/SumOfDigits.css" />
	</head>
	<body>
		<form method="get">
			<label>Input string:</label>
			<input type="text" name="string" />
			<button>Submit</button>
		</form>
		<?php
		if(isset($_GET['string'])):
			$input = explode(',', $_GET['string']);
		?>
		<table>
			<tbody>
				<?php foreach($input as $value): ?>
				<tr>
					<td><?= $value; ?></td>
					<?php if(is_numeric($value)): ?>
					<td><?= digitsSum($value); ?></td>
					<?php else: ?>
					<td>I cannot sum that</td>
					<?php endif; ?>
				</tr>
				<?php endforeach; ?>
			</tbody>
		</table>
		<?php endif; ?>
	</body>
</html>