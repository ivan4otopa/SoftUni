function findMaxSequence(arr) {
	var index;
	var count = 0;
	var maxCount = 0;
	var output = [];
	var sequence = false;
	for(var i = 0; i < arr.length; i++) {
		if(arr[i] < arr[i + 1]) {
			count += 1;
			sequence = true;
		}
		else {
			if(maxCount < count) {
				maxCount = count;
				index = i - maxCount;
			}
			count = 0;
		}
	}
	for(var i = 0; i <= maxCount; i++)
		output[i] = arr[i + index];
	if(sequence == true)
		console.log(output);
	else
		console.log('no');
}

findMaxSequence([3, 2, 3, 4, 2, 2, 4]);
findMaxSequence([3, 5, 4, 6, 1, 2, 3, 6, 10, 32]);
findMaxSequence([3, 2, 1]);