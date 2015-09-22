function convertKWtoHP(number) {
	var hp = number / 0.745699872;
	hp = hp.toFixed(2);
	console.log(hp);
}

convertKWtoHP(75);
convertKWtoHP(150);
convertKWtoHP(1000);