function xRemoval(input) {
	var output = [];
	for(var i = 0; i < input.length; i++)
		output[i] = input[i].split('');
	for(var i = 0; i < input.length; i++)
		input[i] = input[i].toLowerCase();
	for(var i = 1; i < input.length - 1; i++) {
		for(var j = 1; j < input[i].length; j++) {
			var a = input[i][j];
			var b = input[i - 1][j - 1];
			var c = input[i - 1][j + 1];
			var d = input[i + 1][j - 1];
			var e = input[i + 1][j + 1];
			if(a == b && b == c && c == d && d == e) {
				output[i][j] = '';
				output[i - 1][j - 1] = '';
				output[i - 1][j + 1] = '';
				output[i + 1][j - 1] = '';
				output[i + 1][j + 1] = '';
			}
		}
	}
	for(var i = 0; i < output.length; i++)
		console.log(output[i].join(''));
}

xRemoval(['abnbjs',
'xoBab',
'Abmbh',
'aabab',
'ababvvvv'
]);

xRemoval(['8888888',
'08*8*80',
'808*888',
'0**8*8?'
]);

xRemoval(['^u^',
'j^l^a',
'^w^WoWl',
'adw1w6',
'(WdWoWgPoop)'
]);

xRemoval(['puoUdai',
'miU',
'ausupirina',
'8n8i8',
'm8o8a',
'8l8o860',
'M8i8',
'8e8!8?!'
]);