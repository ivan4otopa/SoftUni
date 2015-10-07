function plusRemove(input) {
	var output = [];
	for(var i = 0; i < input.length; i++)
		output[i] = input[i].split('');
	for(var i = 0; i < input.length; i++)
		input[i] = input[i].toLowerCase();
	for(var i = 1; i < input.length - 1; i++) {
		for(var j = 1; j < input[i].length; j++) {
			var a = input[i][j];
			var b = input[i - 1][j];
			var c = input[i][j - 1];
			var d = input[i][j + 1];
			var e = input[i + 1][j];
			if(a == b && b == c && c == d && d == e) {
				output[i][j] = '';
				output[i - 1][j] = '';
				output[i][j - 1] = '';
				output[i][j + 1] = '';
				output[i + 1][j] = '';
			}
		}
	}
	for(var i = 0; i < output.length; i++)
		console.log(output[i].join(''));
}

plusRemove(['ab**l5',
'bBb*555',
'absh*5',
'ttHHH',
'ttth'
]);

plusRemove(['888**t*',
'8888ttt',
'888ttt<<',
'*8*0t>>hi'
]);

plusRemove(['@s@a@p@una',
'p@@@@@@@@dna',
'@6@t@*@*ego',
'vdig*****ne6',
'li??^*^*'
]);