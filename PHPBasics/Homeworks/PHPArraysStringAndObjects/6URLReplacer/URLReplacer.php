<!DOCTYPE html>
<html>
	<head>
		<title>URLReplacer</title>
	</head>
	<body>
		<form method="get">
			<textarea name="text">
				
			</textarea>
			<button>Submit</button>
		</form>
		<?php
		if(isset($_GET['text'])) {
			$text = $_GET['text'];
			$text = str_replace('<a href="', '[URL="', $text);
			$text = str_replace('">', '"]', $text);
			$text = str_replace('</a>', '[/URL]', $text);
			echo $text;
		}
		?>
	</body>
</html>