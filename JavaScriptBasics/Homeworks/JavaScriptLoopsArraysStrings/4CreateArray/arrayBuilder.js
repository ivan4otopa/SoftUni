function createArray() {
	var numbers = [];
	for(var i = 0; i <= 20; i++)
		numbers[i] = i * 5;
	console.log(numbers.join(' '));
}

createArray();