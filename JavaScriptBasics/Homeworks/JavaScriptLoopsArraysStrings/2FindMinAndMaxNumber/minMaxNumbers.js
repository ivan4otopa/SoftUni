function findMinAndMax(arr) {
	arr.sort(function(a, b) {
		return a > b;
	});
	console.log('Min -> ' + arr[0] + '\nMax -> ' + arr[arr.length - 1]);
}

findMinAndMax([1, 2, 1, 15, 20, 5, 7, 31]);
findMinAndMax([2, 2, 2, 2, 2]);
findMinAndMax([500, 1, -23, 0, -300, 28, 35, 12]);