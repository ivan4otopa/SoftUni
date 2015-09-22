<!DOCTYPE html>
<html>
	<head>
		<title>TextColorer</title>
	</head>
	<body>
		<form method="get">
			<textarea name="text">
				
			</textarea>
			<button>Color text</button>
		</form>
		<?php
		if(isset($_GET['text'])):
			$text = $_GET['text'];
			$text = trim($text);
			$letters = str_split($text);
		?>
		<?php foreach ($letters as $value):
			if(ord($value) % 2 == 0): ?>
				<span style="color:red"><?= $value . ' ' ?></span>
			<?php else: ?>
				<span style="color:blue"><?= $value ?></span>
		<?php endif; ?>
		<?php endforeach; ?>
		<?php endif; ?>
	</body>
</html>