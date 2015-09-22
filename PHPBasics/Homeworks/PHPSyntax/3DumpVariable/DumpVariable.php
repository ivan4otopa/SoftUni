<?php
$variable = (object)[2, 34];
if (is_numeric($variable)) {
	echo var_dump($variable);
} else {
	echo gettype($variable);
}
?>