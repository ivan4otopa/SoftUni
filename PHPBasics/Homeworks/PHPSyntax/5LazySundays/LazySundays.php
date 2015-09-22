<?php
function getSundays($y, $m) {
	return new DatePeriod(new DateTime("first sunday of $y-$m"), DateInterval::createFromDateString('next sunday'), new DateTime("last day of $y-$m"));
}

foreach (getSundays(2014, 12) as $sunday) {
	echo $sunday -> format("jS F, Y") . "<br>";
}
?>