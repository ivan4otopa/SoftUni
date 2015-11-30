function magicGrid(input) {
	var encryptedMessage = input[0];	
	var magicNumber = Number(input[1]);
	var matrix = [];
	var key = 0;
	var result = '';

	for (var i = 2; i < input.length; i++) {
		matrix.push(input[i].split(' '));
	}

	for (var i = 0; i < matrix.length; i++) {
		for (var j = 0; j < matrix[i].length; j++) {
			var number = Number(matrix[i][j]);

			for (var k = 0; k < matrix.length; k++) {			
				for (var l = 0; l < matrix[k].length; l++) {
					var compareNumber = Number(matrix[k][l]);

					if ((i != k || j != l) && number + compareNumber == magicNumber) {
						key = i + j + k + l;
					}
				}
			}		
		}
	}

	for (var i = 0; i < encryptedMessage.length; i++) {		
		if (i % 2 == 0) {
			result += String.fromCharCode(encryptedMessage.charCodeAt(i) + key);
		} else {
			result += String.fromCharCode(encryptedMessage.charCodeAt(i) - key);
		}	
	}

	console.log(result);
}