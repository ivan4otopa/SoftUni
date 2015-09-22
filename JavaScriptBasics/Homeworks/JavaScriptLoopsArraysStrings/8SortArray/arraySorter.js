function sortArray(arr) {
	var temp;
	var temp2;
	for(var i = 0; i < arr.length - 1; i++) {
		temp = i;
		for(var j = i + 1; j < arr.length; j++) {
			if(arr[j] < arr[temp]) {
				temp = j;
			}
		}
		if(temp != i) {
			temp2 = arr[temp];
			arr[temp] = arr[i];
			arr[i] = temp2;
		}
	}
	console.log(arr.join(', '));
}

sortArray([5, 4, 3, 2, 1]);
sortArray([12, 12, 50, 2, 6, 22, 51, 712, 6, 3, 3]);