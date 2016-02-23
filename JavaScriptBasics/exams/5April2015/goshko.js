function goshko(input) {
	var vegetables = { '&': 0, '*': 0, '#': 0, '!': 0, 'wall hits': 0 };
	var commands = input[0].split(', ')
	var row = 0;
	var column = 0;	
	var symbolStrings = [];

	for (var i = 0; i < commands.length; i++) {
		var temporaryRow = row;
		var temporaryColumn = column;

		if (commands[i] == 'right') {
			temporaryColumn = column;
			column++;
		} else if (commands[i] == 'left') {
			temporaryColumn = column;			
			column--;
		} else if (commands[i] == 'down') {
			temporaryRow = row;			
			row++;
		} else {
			temporaryRow = row;			
			row--;
		}

		if (row < 0) {
			vegetables['wall hits']++;
			row = temporaryRow;

			continue;
		}

		if (column < 0) {
			vegetables['wall hits']++;
			calumn = temporaryColumn;

			continue;
		}

		if (row >= input.length) {			
			vegetables['wall hits']++;
			row = temporaryRow;

			continue;	
		}

		var strings = input[row + 1].split(', ');

		if (column >= strings.length) {
			vegetables['wall hits']++;
			column = temporaryColumn;

			continue;
		}

		var symbolString = strings[column];
		
		for (var j = 0; j < symbolString.length; j++) {
			if (symbolString[j] == '&') {
				vegetables['&']++;				
			}			

			if (symbolString[j] == '*') {
				vegetables['*']++;
			}

			if (symbolString[j] == '#') {
				vegetables['#']++;
			}

			if (symbolString[j] == '!') {
				vegetables['!']++;
			}								
		}

		symbolString = symbolString.replace('{&}', '@');			
		symbolString = symbolString.replace('{*}', '@');			
		symbolString = symbolString.replace('{#}', '@');			
		symbolString = symbolString.replace('{!}', '@');
		symbolStrings.push(symbolString);		
	}

	console.log(JSON.stringify(vegetables));

	if (symbolStrings.length > 0) {
		console.log(symbolStrings.join('|'));
	} else {
		console.log('no');
	}
}

goshko([
	'right, up, up, down',
	'asdf, as{#}j{g}dasd, kjldk{}fdffd, jdflk{#}jdfj',
	'tr{X}yrty, zxx{*}zxc, mncvnvcn, popipoip',
	'poiopipo, nmf{X}d{X}ei, mzoijwq, omcxzne'
]);

goshko([
	'up, right, left, down',
	'as{!}xnk'
]);

goshko([
	'right, right, down, left, left, down, right, right, down, left',
	'qwekjs, asd{#}a, mxz{#}{*}',
	'qwekjs, asd{#}a, xnc{&}a',
	'qwekjs, asd{#}a, xnc{&}a',
	'qwekjs, asd{#}a, xnc{&}a'
])
