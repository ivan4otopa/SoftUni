function findNthDigit(arr) {
	var num = arr[0];
	var n = Math.abs(arr[1]);
	var numbers = n.toString().replace('.', '').split('').reverse();
	if(numbers[num - 1] === undefined)
		console.log('The number doesn\'t have ' + num + ' digits');
	else
		console.log(numbers[num - 1]);
}

findNthDigit([1, 6]);
findNthDigit([2, -55]);
findNthDigit([6, 923456]);
findNthDigit([3, 1451.78]);
findNthDigit([6, 888.88]);