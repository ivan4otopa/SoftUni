function printNumbers(number) {
	if(number < 0)
		console.log('no');
	else {
		var numbers = [];
		for(var i = 1; i <= number; i++) {
			if(i % 4 != 0 && i % 5 != 0)
				numbers.push(i);
		}
		console.log(numbers.join(', '));
	}
}

printNumbers(20);
printNumbers(-5);
printNumbers(13)