function parachute(input) {
	var output = [];
	var landing = '';
	var endI = 0;
	var endJ = 0;
	for(var i = 0; i < input.length; i++)
		output[i] = input[i].split('');
	for(var i = 1; i < input.length; i++) {
		var move = blown(input[i])[0];
		var direction = blown(input[i])[1];
		for(var j = 0; j < input[i].length; j++) {
			if(output[i - 1][j] == 'o') {
				if(move != 0) {
					if(direction == 'right') {
						if(output[i][j + move] == '_') {
							landing = 'ground';
							endI = i;
							endJ = j + move;
						}
						else if(output[i][j + move] == '~') {
							landing = 'water';
							endI = i;
							endJ = j + move;
						}
						else if(output[i][j + move] == '/' || output[i][j + move] == '\\' || output[i][j + move] == '|') {
							landing = 'cliff';
							endI = i;
							endJ = j + move;
						}
						else
							output[i][j + move] = 'o';
					}
					else if(direction == 'left') {
						if(output[i][j - move] == '_') {
							landing = 'ground';
							endI = i;
							endJ = j - move;
						}
						else if(output[i][j - move] == '~') {
							landing = 'water';
							endI = i;
							endJ = j - move;
						}
						else if(output[i][j - move] == '/' || output[i][j - move] == '\\' || output[i][j - move] == '|') {
							landing = 'cliff';
							endI = i;
							endJ = j - move;
						}
						else
							output[i][j - move] = 'o'
					}
				}
				else {
					if(output[i][j] == '_') {
						landing = 'ground';
						endI = i;
						endJ = j
					}
					else if(output[i][j] == '~') {
						landing = 'water';
						endI = i;
						endJ = j;
					}
					else if(output[i][j] == '/' || output[i][j] == '\\' || output[i][j] == '|') {
						landing = 'cliff';
						endI = i;
						endJ = j;
					}
					else
						output[i][j] = 'o';
				}
			}
		}
	}
	if(landing == 'ground')
		console.log('Landed on the ground like a boss!\n' + endI + ' ' + endJ);
	else if(landing == 'water')
		console.log('Drowned in the water like a cat!\n' + endI + ' ' + endJ);
	else
		console.log('Got smacked on the rock like a dog!\n' + endI + ' ' + endJ);
		function blown(row) {
		var lessThanCount = 0;
		var greaterThanCount = 0;
		var direction = '';
		for(var i = 0; i < row.length; i++) {
			if(row[i] == '<')
				lessThanCount++;
			else if(row[i] == '>')
				greaterThanCount++;
		}
		if(lessThanCount > greaterThanCount) {
			direction = 'left';
			return [lessThanCount - greaterThanCount, direction];
		}
		else if(greaterThanCount > lessThanCount) {
			direction = 'right';
			return [greaterThanCount - lessThanCount, direction];
		}
		else
			return[0, ''];
	}
}

parachute(['--o----------------------',
'>------------------------',
'>------------------------',
'>-----------------/\\-----',
'-----------------/--\\----',
'>---------/\\----/----\\---',
'---------/--\\--/------\\--',
'<-------/----\\/--------\\-',
'\\------/----------------\\',
'-\\____/------------------'
]);

parachute(['-------------o-<<--------',
'-------->>>>>------------',
'---------------->-<---<--',
'------<<<<<-------/\\--<--',
'--------------<--/-<\\----',
'>>--------/\\----/<-<-\\---',
'---------/<-\\--/------\\--',
'<-------/----\\/--------\\-',
'\\------/--------------<-\\',
'-\\___~/------<-----------'
]);