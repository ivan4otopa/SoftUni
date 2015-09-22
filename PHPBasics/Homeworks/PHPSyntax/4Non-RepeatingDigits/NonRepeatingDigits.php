<?php
$n = 247;
if ($n < 102)
	echo 'no';
else if ($n > 987) {
	for ($i = 102; $i <= 987; $i++) {
		if ((int)($i / 100) != (int)(($i % 100) / 10) && (int)($i / 100) != $i % 10 && (int)(($i % 100) / 10) != $i % 10) {
			if ($i != 987)
				echo $i . ', ';
			else
				echo $i;
		}
	}
} else if ($n >= 102 && $n < 987) {
	for ($i = 102; $i <= $n; $i++) {
		if ((int)($i / 100) != (int)(($i % 100) / 10) && (int)($i / 100) != $i % 10 && (int)(($i % 100) / 10) != $i % 10) {
			if ($i != $n)
				echo $i . ', ';
			else
				echo $i;
		}
	}
}
?>