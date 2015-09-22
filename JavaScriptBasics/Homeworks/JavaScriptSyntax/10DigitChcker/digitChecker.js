function checkDigit(number) {
	if(number > 1000) {
		var a = number % 1000;
		var b = parseInt(a / 100);
		if(b == 3)
			console.log(true);
		else
			console.log(false);
	}
}

checkDigit(1235);
checkDigit(25368);
checkDigit(123456);