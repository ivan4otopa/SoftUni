<!DOCTYPE html>
<html>
<head lang="en">
    <meta charset="UTF-8">
    <title></title>
</head>
<body>
<form  action="fruitArrow.php" method="get">
    <input name="fruit" type="text" value="banana"/>
    <input type="submit"/>
</form>
<p><b>Expected output:</b> >>------(banana)---------></p>
<br/>
<form  action="fruitArrow.php" method="get">
    <input name="fruit" type="text" value="kiwi"/>
    <input type="submit"/>
</form>
<p><b>Expected output:</b> >>----(kiwi)------></p>
<br/>
<form  action="fruitArrow.php" method="get">
    <input name="fruit" type="text" value="apple"/>
    <input type="submit"/>
</form>
<p><b>Expected output:</b> >>-----(apple)></p>
</body>
<?php
if (isset($_GET['fruit'])) {
	$fruit = $_GET['fruit'];
	$letters = str_split($fruit);
	$totalSum = 0;
	
	for ($i = 0; $i < count($letters); $i++) { 
		$totalSum += ord($letters[$i]);
	}
	
	$numberOfTailDashes = intval(substr($totalSum, 0, 1));
	$numberOfHeadDashes = intval(substr($totalSum, count($totalSum) - 2, 1));
	
	echo '>>' . str_repeat('-', $numberOfTailDashes) . '(' . $fruit . ')' . str_repeat('-', $numberOfHeadDashes) . '>';
}
?>
</html>