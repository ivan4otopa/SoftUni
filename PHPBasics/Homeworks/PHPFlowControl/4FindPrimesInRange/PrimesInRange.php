<?php
$count = 0;
?>
<!DOCTYPE html>
<html>
	<head>
		<title>PrimesInRange</title>
		<link rel="stylesheet" href="styles/PrimesInRange.css" />
	</head>
	<body>
		<form method="get">
			<label>Starting Index:</label>
			<input type="text" name="start" />
			<label>End:</label>
			<input type="text" name="end" />
			<button>Submit</button>
		</form>
		<?php
		if(isset($_GET['start'], $_GET['end'])):
			$start = $_GET['start'];
			$end = $_GET['end'];
		?>
		<div>
		<?php for($i = $start; $i <= $end; $i++):
		for($j = 1; $j <= $i; $j++) {
			if($i % $j == 0)
				$count++;
		}
		?>
		<?php if($count == 2): ?>
		<?php if($i == $end): ?>
		<b><?= $i ?></b>
		<?php else: ?>
		<b><?= $i . ',' ?></b>
		<?php endif; ?>
		<?php else: ?>
		<?php if($i == $end): ?>
		<?= $i ?>
		<?php else: ?>
		<?= $i . ',' ?>
		<?php endif; ?>
		<?php endif; ?>
		<?php
		$count = 0;
		?>
		<?php endfor; ?>
		<?php endif; ?>
		</div>
	</body>
</html>