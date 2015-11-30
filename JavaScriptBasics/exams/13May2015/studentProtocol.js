function studentProtocol(input) {
	var regex = /([a-zA-Z\s]+)\s*-\s*(.+)\s*:\s*(\d+)/;
	var exams = {};
	var studentNames = [];
	
	for (var line in input) {
		var match = input[line].match(regex);
		var studentName = match[1].trim();
		var exam = match[2].trim();
		var result = Number(match[3]);

		if (!(exam in exams)) {
			exams[exam] = [];
		}

		if (0 <= result && result <= 400) {
			exams[exam].push({ 'name': studentName, 'result': result, 'makeUpExams': 0 });
		}
	}

	for (var exam in exams) {
		exams[exam].sort(function (a, b) {						
			return b.result - a.result;
		});
	}

	for (var exam in exams) {
		for (var i = 0; i < exams[exam].length; i++) {
			var makeUpExams = -1;
			var studentName = exams[exam][i].name;			
				
			if (studentNames.indexOf(studentName) < 0) {
				for (var j = 0; j < exams[exam].length; j++) {
					if (exams[exam][j].name == studentName) {
						makeUpExams++;
					}
				}

				exams[exam][i].makeUpExams = makeUpExams;
			}

			studentNames.push(studentName);
		}

		studentNames = [];
	}

	for (var exam in exams) {
		for (var i = 0; i < exams[exam].length; i++) {
			var studentName = exams[exam][i].name;

			for (var j = 0; j < exams[exam].length; j++) {
				if (studentName == exams[exam][j].name && exams[exam][j].makeUpExams == 0 && j != 0 && j != i) {
					exams[exam][j]['shouldBeRemoved'] = true;
				}
			}
		}
	}

	for (var exam in exams) {
		for (var i = 0; i < exams[exam].length; i++) {
			if (exams[exam][i].shouldBeRemoved) {
				var index = exams[exam].indexOf(exams[exam][i]);

				exams[exam].splice(index, 1);
				i--;
			}
		}
	}

	for (var exam in exams) {
		exams[exam].sort(function (a, b) {
			if (a.result == b.result) {
				if (a.makeUpExams == b.makeUpExams) {
					return a.name.localeCompare(b.name);
				}

				return a.makeUpExams - b.makeUpExams;				
			}

			return b.result - a.result;
		})
	}

	console.log(JSON.stringify(exams));
}