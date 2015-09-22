<!DOCTYPE html>
<html>
<head>
	<title>PrintTags</title>
	<link rel="stylesheet" href="styles/MostFrequentTag.css"/>
	<meta charset="UTF-8" />
</head>
<body>
	<form method="get">
		<label>Enter Tags:</label>
		<input type="text" name="tags"/>
		<button>Submit</button>
	</form>
	<?php
	if(isset($_GET['tags'])) {
		$tags = explode(', ', $_GET['tags']);
		$uniqueTags = array_count_values($tags);
		arsort($uniqueTags);
		var_dump($uniqueTags);
		foreach ($uniqueTags as $key => $value) {
			echo $key . ' : ' . $value . '<br>';
		}
		reset($uniqueTags);
		echo 'Most frequent tag is: ' . key($uniqueTags);
	}
	?>
</body>
</html>