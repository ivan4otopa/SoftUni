function filterMatrix(input) {
	var sequenceNumber = Number(input[input.length - 1]);
	var matrix = [];
	var breakPositions = [];
	var newMatrix = [];

	for (var i = 0; i < input.length - 1; i++) {
		matrix[i] = input[i].split(' ');
	}

	for (var i = 0; i < matrix.length; i++) {
		breakPositions[i] = matrix[i].length;
	}

	matrix = [].concat.apply([], matrix);

	for (var i = 0; i < matrix.length; i++) {		
		if (hasSequence(i)) {
			var counter = i;

			for (var j = 0; j < sequenceNumber; j++) {
				matrix[counter] = '';				

				counter++;
			}
		}
	}	
	
	newMatrix = matrix;
	
	for (var i = 0; i < breakPositions.length; i++) {
		matrix[i] = newMatrix.slice(0, breakPositions[i]);
		newMatrix = newMatrix.splice(breakPositions[i]);
	}

	for (var i = 0; i < matrix.length; i++) {
		if (matrix[i] instanceof Array) {
			if (isEmpty(matrix[i])) {
				console.log('(empty)');
			} else {
				matrix[i] = matrix[i].filter(function (element) {
					return element != '';
				});

				console.log(matrix[i].join(' '));
			}
		}
	}

	function hasSequence(position) {
		var counter = 1;

		for (var i = position; i < matrix.length; i++) {
			if (i != matrix.length - 1 && matrix[i] == matrix[i + 1]) {
				counter++;
			} else {
				break;
			}

			if (counter == sequenceNumber) {
				return true;
			}
		}

		return false;
	}

	function isEmpty(array) {
		for (var i = 0; i < array.length; i++) {
			if (array[i] != '') {
				return false;
			}
		}

		return true;
	}
}