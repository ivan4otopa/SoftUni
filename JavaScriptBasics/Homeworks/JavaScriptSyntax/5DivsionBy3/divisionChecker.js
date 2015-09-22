function divisionBy3(number) {
	if(number > 9) {
		var a = parseInt(number / 100);
		var b = parseInt((number % 100) / 10);
		var c = number % 10;
		var sum = a + b + c;
		if(sum % 3 == 0)
			console.log('the number is divided by 3 without remainder');
		else
			console.log('the number is not divided by 3 without remainder');
	}
}

divisionBy3(12);
divisionBy3(188);
divisionBy3(591);