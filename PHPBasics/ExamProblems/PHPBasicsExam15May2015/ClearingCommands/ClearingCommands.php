<!DOCTYPE html>
<html>
<head>
    <title>Clearing Commands</title>
    <meta charset="utf-8" />
</head>

<body>
<form method="get" action="ClearingCommands.php">
    Input array:
    <br/>
    <textarea name="array" rows="8" cols="20">**********
**>****v**
**********
**********
**^****<**
v*********</textarea><br/>
    <input type="submit" value="Send" />
</form>
<p>
    <b>Expected output:</b>
    <pre>
    <p>**********</p><p>**&gt;    v**</p><p>** **** **</p><p>** **** **</p><p>**^    &lt;**</p><p>v*********</p>
    </pre>
</p>


<form method="get" action="ClearingCommands.php">
    Input array:
    <br/>
    <textarea name="array" rows="3" cols="20">>basdnbdsdavd
>asdwepoiytr<</textarea><br/>
    <input type="submit" value="Send" />
</form>
<p>
    <b>Expected output:</b>
    <pre>
    <p>&gt;          vd</p><p>&gt;           &lt;</p>
    </pre>
</p>
</body>
<?php
if (isset($_GET['array'])) {
	$array = $_GET['array'];
	$output = explode(PHP_EOL, $array);

	foreach ($output as $key => $value) {
		$output[$key] = str_split($value);
	}
	
	$array = explode(PHP_EOL, $_GET['array']);
	
	for ($i = 0; $i < count($array); $i++) {	
		for ($j = 0; $j < strlen($array[$i]); $j++) { 
			if ($array[$i][$j] == '>') {
				if ($j != strlen($array[$i]) - 1) {
					for ($k = $j + 1; $k < strlen($array[$i]); $k++) { 
						if ($array[$i][$k] != '>' && $array[$i][$k] != '<' && $array[$i][$k] != '^' && $array[$i][$k] != 'v') {
							$output[$i][$k] = ' ';
						} else {
							break;
						}					
					}
				}
			}
			
			if ($array[$i][$j] == '<') {
				if ($j != 0) {
					for ($k = $j - 1; $k >= 0; $k--) { 
						if ($array[$i][$k] != '>' && $array[$i][$k] != '<' && $array[$i][$k] != '^' && $array[$i][$k] != 'v') {
							$output[$i][$k] = ' ';
						} else {
							break;
						}		
					}			
				}
			}
			
			if ($array[$i][$j] == '^') {
				if ($i != 0) {
					for ($k = $i - 1; $k >= 0; $k--) { 
						if ($array[$k][$j] != '>' && $array[$k][$j] != '<' && $array[$k][$j] != '^' && $array[$k][$j] != 'v') {
							$output[$k][$j] = ' ';
						} else {
							break;
						}
					}
				}
			}
			
			if ($array[$i][$j] == 'v') {
				if ($i != count($array) - 1) {							
					for ($k = $i + 1; $k < count($array); $k++) { 
						if ($array[$k][$j] != '>' && $array[$k][$j] != '<' && $array[$k][$j] != '^' && $array[$k][$j] != 'v') {
							$output[$k][$j] = ' ';
						} else {
							break;
						}
					}
				}
			}			
		}		
	}

	for ($i = 0; $i < count($output); $i++) {
		echo '<p>';
			
		for ($j = 0; $j < count($output[$i]); $j++) { 
			echo htmlspecialchars($output[$i][$j]);
		}		
		
		echo '</p>' . "\n";
	}
}
?>
</html>