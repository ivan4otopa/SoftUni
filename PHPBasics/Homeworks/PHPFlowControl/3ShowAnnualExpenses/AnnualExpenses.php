<?php
$total = 0;
?>
<!DOCTYPE html>
<html>
	<head>
		<title>AnnualExpenses</title>
		<link rel="stylesheet" href="styles/AnnualExpenses.css" />
	</head>
	<body>
		<form method="get">
			<label>Enter number of years:</label>
			<input type="text" name="years" />
			<button>Show costs</button>
		</form>
		<?php
		if(isset($_GET['years'])):
			$years = $_GET['years'];
		?>
		<table>
			<thead>
				<tr>
					<th>Year</th>
					<th>January</th>
					<th>February</th>
					<th>March</th>
					<th>April</th>
					<th>May</th>
					<th>June</th>
					<th>July</th>
					<th>August</th>
					<th>September</th>
					<th>October</th>
					<th>November</th>
					<th>December</th>
					<th>Total:</th>
				</tr>
			</thead>
			<tbody>
				<?php for($i = 2014; $i > 2014 - $years; $i--): ?>
				<tr>
					<td><?= $i ?></td>
					<?php
					$random = rand(0, 999);
					?>
					<td><?= $random ?></td>
					<?php
					$total += $random;
					?>
					<?php
					$random = rand(0, 999);
					?>
					<td><?= $random ?></td>
					<?php
					$total += $random;
					?>
					<?php
					$random = rand(0, 999);
					?>
					<td><?= $random ?></td>
					<?php
					$total += $random;
					?>
					<?php
					$random = rand(0, 999);
					?>
					<td><?= $random ?></td>
					<?php
					$total += $random;
					?>
					<?php
					$random = rand(0, 999);
					?>
					<td><?= $random ?></td>
					<?php
					$total += $random;
					?>
					<?php
					$random = rand(0, 999);
					?>
					<td><?= $random ?></td>
					<?php
					$total += $random;
					?>
					<?php
					$random = rand(0, 999);
					?>
					<td><?= $random ?></td>
					<?php
					$total += $random;
					?>
					<?php
					$random = rand(0, 999);
					?>
					<td><?= $random ?></td>
					<?php
					$total += $random;
					?>
					<?php
					$random = rand(0, 999);
					?>
					<td><?= $random ?></td>
					<?php
					$total += $random;
					?>
					<?php
					$random = rand(0, 999);
					?>
					<td><?= $random ?></td>
					<?php
					$total += $random;
					?>
					<?php
					$random = rand(0, 999);
					?>
					<td><?= $random ?></td>
					<?php
					$total += $random;
					?>
					<?php
					$random = rand(0, 999);
					?>
					<td><?= $random ?></td>
					<?php
					$total += $random;
					?>
					<td><?= $total ?></td>					
				</tr>
				<?php
				$total = 0;
				?>
				<?php endfor; ?>
			</tbody>
		</table>
		<?php endif; ?>
	</body>
</html>