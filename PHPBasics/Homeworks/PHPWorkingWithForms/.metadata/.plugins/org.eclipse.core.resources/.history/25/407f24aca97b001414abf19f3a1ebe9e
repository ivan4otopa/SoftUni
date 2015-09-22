<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8" />
		<title>Print tags</title>
	</head>
	<body>
		<p>Enter Tags:</p>
		<form method="get" action="01-PrintTags.php">
			<input type="text" name="input" />
			<input type="submit" />
		</form>
	</body>
</html>

<?php
if (isset($_GET['input'])) {
	$tags = explode(', ', $_GET['input']);
	foreach ($tags as $key => $value) {
		echo "$key: $value <br>";
	}
}
?>