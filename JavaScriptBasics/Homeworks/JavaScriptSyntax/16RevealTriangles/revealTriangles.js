function revealTriangles(input) {
	var output = [];
	for(var i = 0; i < input.length; i++)
			output[i] = input[i].split('');

	for(var i = 1; i < output.length; i++) {
		for(var j = 0; j < output[i].length; j++) {
			var a = input[i - 1][j + 1];
			var b = input[i][j];
			var c = input[i][j + 1];
			var d = input[i][j + 2];
			if(a == b && b == c && c == d) {
				output[i - 1][j + 1] = '*';
				output[i][j] = '*';
				output[i][j + 1] = '*';
				output[i][j + 2] = '*';
			}
		}
	}

	for(var i = 0; i < input.length; i++)
		console.log(output[i].join(''));
}