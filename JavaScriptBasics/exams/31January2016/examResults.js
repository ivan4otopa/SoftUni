function examResults(input) {
	var coursePoints = [];
	var courseName = input[input.length - 1].trim();
	var regex = /(.+?)\s+(.+?)\s+(\d+)\s+(\d+)/;
	var match = [];
	var student = '';
	var course = '';
	var examPoints = 0;
	var bonusPoints = 0;
	var studentCoursePoints = 0;
	var grade = 0;

	for (var i = 0; i < input.length - 1; i++) {
		match = input[i].trim().match(regex);
		student = match[1];
		course = match[2];
		examPoints = Number(match[3]);
		bonusPoints = Number(match[4]);

		if (course == courseName) {
			coursePoints.push(examPoints);
		}

		if (examPoints < 100) {
			console.log(student + ' failed at "' + course + '"');
		} else {
			studentCoursePoints = examPoints - 80 / 100 * examPoints + bonusPoints;
			grade = studentCoursePoints / 80 * 4 + 2;

			if (grade > 6) {
				grade = 6;
			}

			console.log(
				student +
				': Exam - "' +
				course +
				'"; Points - ' +
				parseFloat(studentCoursePoints.toFixed(2)) +
				'; Grade - ' +
				grade.toFixed(2)
			);
		}
	}

	console.log('"' + courseName + '" average points -> ' + parseFloat(average(coursePoints).toFixed(2)));

	function average(array) {
		var sum = 0;

		for (var i = 0; i < array.length; i++) {
			sum += array[i];
		};

		return sum / array.length;
	}
}