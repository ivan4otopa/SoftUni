<?php
for($i = 1; $i <= 100; $i++) {
	echo $i . br();
}
function br() {
	if (PHP_SAPI === 'cli') 
	{ 
	   return PHP_EOL;
	} 
	else
	{
	   return "<BR/>";
	}
}
?>