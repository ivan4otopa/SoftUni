function tetrisFigures(input) {
	var figures = {'I': 0, 'L': 0, 'J': 0, 'O': 0, 'Z': 0, 'S': 0, 'T': 0};
	var field = [];
	for(var i = 0; i < input.length; i++)
		field[i] = input[i].split('');
	for(var i = 0; i < field.length; i++) {
		for(var j = 0; j < field[i].length; j++) {
			if(i < field.length - 3 && field[i][j] == 'o' && field[i][j] == field[i + 1][j] && field[i + 1][j] == field[i + 2][j] &&
				field[i + 2][j] == field[i + 3][j])
				figures.I++;
			if(i < field.length - 2 && j < field[i].length - 1 && field[i][j] == 'o' && field[i][j] == field[i + 1][j] && field[i + 1][j] == field[i + 2][j] &&
				field[i + 2][j] == field[i + 2][j + 1])
				figures.L++;
			if(i < field.length - 2 && j != 0 && field[i][j] == 'o' && field[i][j] == field[i + 1][j] && field[i + 1][j] == field[i + 2][j] &&
				field[i + 2][j] == field[i + 2][j - 1])
				figures.J++;
			if(i < field.length - 1 && j < field[i].length - 1 && field[i][j] == 'o' && field[i][j] == field[i + 1][j] && field[i + 1][j] == field[i][j + 1] &&
				field[i][j + 1] == field[i + 1][j + 1])
				figures.O++;
			if(i < field.length - 1 && j < field[i].length - 2 &&  field[i][j] == 'o' && field[i][j] == field[i][j + 1] &&
				field[i][j + 1] == field[i + 1][j + 1] && field[i + 1][j + 1] == field[i + 1][j + 2])
				figures.Z++;
			if(i != 0 && j < field[i].length - 2 && field[i][j] == 'o' && field[i][j] == field[i][j + 1] && field[i][j + 1] == field[i - 1][j + 1] &&
				field[i - 1][j + 1] == field[i - 1][j + 2])
				figures.S++;
			if(i < field.length - 1 && j < field[i].length - 1 && field[i][j] == 'o' && field[i][j] == field[i][j + 1] && field[i][j + 1] == field[i][j + 2] &&
				field[i][j + 1] == field[i + 1][j + 1])
				figures.T++;
		}
	}
	console.log(JSON.stringify(figures));
}

tetrisFigures(['--o--o-',
'--oo-oo',
'ooo-oo-',
'-ooooo-',
'---oo--'
]);

tetrisFigures(['-oo',
'ooo',
'ooo'
]);