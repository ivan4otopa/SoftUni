<!DOCTYPE html>
<html>
<head>
	<title>PrintTags</title>
	<link rel="stylesheet" href="styles/PrintTags.css"/>
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
		for($i = 0; $i < count($tags); $i++) {
			echo $i . ' : ' . $tags[$i] . '<br>';
		}
	}
	?>
</body>
</html>