function studentsCoursesGradesVisits(input) {
	var courses = {};
	for(var i = 0; i < input.length; i++) {
		var matches = input[i].split('|');
		var student = matches[0].trim();
		var course = matches[1].trim();
		var grade = Number(matches[2].trim());
		var visits = Number(matches[3].trim());
		if(!courses[course])
			courses[course] = {'avgGrade': [], 'avgVisits': [], 'students': []};
		courses[course].avgGrade.push(grade);
		courses[course].avgVisits.push(visits);
		if(courses[course].students.indexOf(student) == -1)
			courses[course].students.push(student);
	}
	var sortedObject = {}
	var sortedKeys = Object.keys(courses).sort();
	for(var i = 0; i < sortedKeys.length; i++)
		sortedObject[sortedKeys[i]] = courses[sortedKeys[i]];
	for(course in sortedObject) {
		sortedObject[course].students.sort();
		sortedObject[course].avgGrade = avarage(sortedObject[course].avgGrade);
		sortedObject[course].avgVisits = avarage(sortedObject[course].avgVisits);
	}
	function avarage(arr) {
		var sum = 0;
		for(var i = 0; i < arr.length; i++)
			sum += arr[i];
		var avarage = sum / arr.length;
		avarage = Number(avarage.toFixed(2));
		return avarage;
	}
	console.log(JSON.stringify(sortedObject));
}

studentsCoursesGradesVisits(['Peter Nikolov | PHP  | 5.50 | 8',
'Maria Ivanova | Java | 5.83 | 7',
'Ivan Petrov   | PHP  | 3.00 | 2',
'Ivan Petrov   | C#   | 3.00 | 2',
'Peter Nikolov | C#   | 5.50 | 8',
'Maria Ivanova | C#   | 5.83 | 7',
'Ivan Petrov   | C#   | 4.12 | 5',
'Ivan Petrov   | PHP  | 3.10 | 2',
'Peter Nikolov | Java | 6.00 | 9'
]);