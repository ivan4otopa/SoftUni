function findLargestBySumOfDigits(arr) {
	var sum = 0;
	var maxSum = 0;
	var largestSum = 0;
	for(var i = 0; i < arr.length; i++) {
		if(arr.length == 0 || typeof(arr[i]) != 'number' || arr[i] % 1 != 0) {
			console.log('undefined');
			return;
		}
		if(maxSum < calcDigits(arr[i])) {
			maxSum = calcDigits(arr[i]);
			largestSum = arr[i];
		}
		sum = 0;
	}
	function calcDigits(num) {
		var sum = 0;
		var digits = num.toString().replace('-', '').split('');
		for(var i = 0; i < digits.length; i++) {
			var a = parseInt(digits[i])
			sum += a;
		}
		return sum;
	}
	console.log(largestSum);
}

findLargestBySumOfDigits([5, 10, 15, 111]);
findLargestBySumOfDigits([33, 44, -99, 0, 20]);
findLargestBySumOfDigits(['hello']);
findLargestBySumOfDigits([5, 3.3]);