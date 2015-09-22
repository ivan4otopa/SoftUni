function biggerThanNeighbors(index, arr) {
	var i = index;
	var numbers = arr;
	if(i == 0 || i == numbers.length - 1)
		console.log('only one neighbor');
	else if(i > numbers.length - 1)
		console.log('undefined');
	else {
		if(numbers[i] > numbers[i - 1] && numbers[i] > numbers[i + 1])
			console.log('bigger');
		else if(numbers[i] <= numbers[i - 1] || numbers[i] <= numbers[i + 1])
			console.log('not bigger');
	}
}

biggerThanNeighbors(2, [1, 2, 3, 3, 5]);
biggerThanNeighbors(2, [1, 2, 5, 3, 4]);
biggerThanNeighbors(5, [1, 2, 5, 3, 4]);
biggerThanNeighbors(0, [1, 2, 5, 3, 4]);