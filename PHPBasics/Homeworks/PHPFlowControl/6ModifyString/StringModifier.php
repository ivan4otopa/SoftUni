<?php
function palindromeCheck($word) {
	$reversed = strrev($word);
	if($word == $reversed)
		return true;
	else 
		return false;
}
?>
<!DOCTYPE html>
<html>
	<head>
		<title>StringModifier</title>
	</head>
	<body>
		<form method="get">
			<input type="text" name="string" />
			<input type="radio" name="modification" value="palindrome" id="palindrome" />
			<label for="palindrome">Check Palindrome</label>
			<input type="radio" name="modification" value="reverse" id="reverse" />
			<label for="reverse">Reverse String</label>
			<input type="radio" name="modification" value="split" id="split" />
			<label for="split">Split</label>
			<input type="radio" name="modification" value="hash" id="hash" />
			<label for="hash">Hash String</label>
			<input type="radio" name="modification" value="shuffle" id="shuffle" />
			<label for="shuffle">Shuffle String</label>
			<button>Submit</button>
		</form>
		<?php
		if(isset($_GET['string'], $_GET['modification'])) {
			$string = $_GET['string'];
			$modification = $_GET['modification'];
			if($modification == 'palindrome') {
				if(palindromeCheck($string))
					echo $string . ' is a palindrome!';
				else
					echo $string . ' is not a palindrome!';
			}
			else if($modification == 'reverse') 
				echo strrev($string);
			else if($modification == 'split') {
				$letters = str_split($string);
				$letters = implode(' ', $letters);
				echo $letters;
			}
			else if($modification == 'hash')
				echo password_hash($string, PASSWORD_DEFAULT);
			else if($modification == 'shuffle')
				echo str_shuffle($string);
		}
		?>
	</body>
</html>