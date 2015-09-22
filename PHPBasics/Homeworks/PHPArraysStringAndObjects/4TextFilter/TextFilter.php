<!DOCTYPE html>
<html>
	<head>
		<title>TextFilter</title>
	</head>
	<body>
		<form method="get">
			<input type="text" name="text" />
			<input type="text" name="bans" />
			<button>Submit</button>
		</form>
		<?php
		if(isset($_GET['text'], $_GET['bans'])) {
			$text = $_GET['text'];
			$bans = $_GET['bans'];
			$banlist = explode(', ', $bans);
			for($i = 0; $i < strlen($text); $i++) {
				for($j = 0; $j < count($banlist); $j++) { 
					if(substr($text, $i, strlen($banlist[$j])) == $banlist[$j]) {
							$text = str_replace(substr($text, $i, strlen($banlist[$j])), str_repeat('*', strlen($banlist[$j])), $text);
					} 
				}
			}
			echo $text;
		}
		?>
	</body>
</html>