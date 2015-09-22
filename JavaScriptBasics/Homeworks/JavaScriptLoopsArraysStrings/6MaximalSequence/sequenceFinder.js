function findMaxSequence(arr) {
	var count = 1;
	var maxCount = 1;
	var element = arr[0];
	var output = [];
	for(var i = 0; i < arr.length; i++) {
		if(arr[i] === arr[i + 1])
			count++;
		else {
			if(count >= maxCount) {
				maxCount = count;
				element = arr[i];
			}
			count = 1;
		}
	}
	for(var i = 0; i < maxCount; i++)
		output[i] = element;
	console.log(output);
}

findMaxSequence([2, 1, 1, 2, 3, 3, 2, 2, 2, 1]);
findMaxSequence(['happy']);
findMaxSequence([2, 'qwe', 'qwe', 3, 3, '3']);