function revealTriangles(input) {
	var output = [];
	for(var i = 0; i < input.length; i++)
		output[i] = input[i].split('');
	for(var i = 1; i < input.length; i++) {
		for(var j = 0; j < input[i].length; j++) {
			if(input[i - 1][j + 1] == input[i][j] && input[i][j + 1] == input[i][j] && input[i][j + 2] == input[i][j + 1]) {
				output[i - 1][j + 1] = '*';
				output[i][j] = '*';
				output[i][j + 1] = '*';
				output[i][j + 2] = '*';
			}
		}
	}
	for(var i = 0; i < output.length; i++)
		console.log(output[i].join(''));
}

revealTriangles(['abcdexgh',
'bbbdxxxh',
'abcxxxxx'
]);

revealTriangles(['aa',
'aaa',
'aaaa',
'aaaaa'
])