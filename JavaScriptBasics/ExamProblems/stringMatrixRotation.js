function stringMatrixRotation(input) {
	var degrees = parseInt(input[0].match(/\d+/g));
	var length = 0;
	var maxLength = 0;
	for(var i = 1; i < input.length; i++) {
		if(input[i].length > maxLength)
			maxLength = input[i].length;
	}
	var matrix = [];
	for(var i = 1; i < input.length; i++) {
		var line = input[i] + Array(maxLength - input[i].length + 1).join(' ');
		matrix.push(line.split(''));
	}
	var rows = maxLength;
	var cols = matrix.length - 1;
	function rotateMatrix(matrix){
        var newMatrix = [];
        var rows = matrix[0].length;
        var cols = matrix.length - 1;
        for(var i = 0; i < rows; i++) {
            newMatrix[i] = [];
            for(var j = cols; j >= 0; j--)
                newMatrix[i].push(matrix[j][i]);
        }
        return newMatrix;
    }
	var times = (degrees / 90);
	for(var i = 0; i < times; i++)
		matrix = rotateMatrix(matrix);
	for(var i = 0; i < matrix.length; i++)
		console.log(matrix[i].join(''));
}

stringMatrixRotation(['Rotate(90)',
'hello',
'softuni',
'exam'
]);
stringMatrixRotation(['Rotate(180)',
'hello',
'softuni',
'exam'
]);
stringMatrixRotation(['Rotate(270)',
'hello',
'softuni',
'exam'
]);
stringMatrixRotation(['Rotate(720)',
'js',
'exam'
]);
stringMatrixRotation(['Rotate(810)',
'js',
'exam'
]);
stringMatrixRotation(['Rotate(0)',
'js',
'exam'
]);