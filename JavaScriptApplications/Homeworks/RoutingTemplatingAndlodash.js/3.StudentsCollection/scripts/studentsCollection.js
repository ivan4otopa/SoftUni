var students = [{"gender":"Male","firstName":"Joe","lastName":"Riley","age":22,"country":"Russia"},
{"gender":"Female","firstName":"Lois","lastName":"Morgan","age":41,"country":"Bulgaria"},
{"gender":"Male","firstName":"Roy","lastName":"Wood","age":33,"country":"Russia"},
{"gender":"Female","firstName":"Diana","lastName":"Freeman","age":40,"country":"Argentina"},
{"gender":"Female","firstName":"Bonnie","lastName":"Hunter","age":23,"country":"Bulgaria"},
{"gender":"Male","firstName":"Joe","lastName":"Young","age":16,"country":"Bulgaria"},
{"gender":"Female","firstName":"Kathryn","lastName":"Murray","age":22,"country":"Indonesia"},
{"gender":"Male","firstName":"Dennis","lastName":"Woods","age":37,"country":"Bulgaria"},
{"gender":"Male","firstName":"Billy","lastName":"Patterson","age":24,"country":"Bulgaria"},
{"gender":"Male","firstName":"Willie","lastName":"Gray","age":42,"country":"China"},
{"gender":"Male","firstName":"Justin","lastName":"Lawson","age":38,"country":"Bulgaria"},
{"gender":"Male","firstName":"Ryan","lastName":"Foster","age":24,"country":"Indonesia"},
{"gender":"Male","firstName":"Eugene","lastName":"Morris","age":37,"country":"Bulgaria"},
{"gender":"Male","firstName":"Eugene","lastName":"Rivera","age":45,"country":"Philippines"},
{"gender":"Female","firstName":"Kathleen","lastName":"Hunter","age":28,"country":"Bulgaria"}],
	studentsAgeBetweenEighteenAndTwentyFour,
	studentsFirstNameAlphabeticallyBeforeLastName,
	studentsFromBulgariaOnlyNames,
	lastFiveStudents,
	maleStudentsNotFromBulgaria,
	firstThreeMaleStudentsNotFromBulgaria;

studentsAgeBetweenEighteenAndTwentyFour = _.filter(students, function (student) {
	return 18 <= student.age && student.age <= 24;
});
console.log('Students whose age is betwen 18 and 24:');

for(var i = 0; i < studentsAgeBetweenEighteenAndTwentyFour.length; i++) {
	console.log('First name: ' + studentsAgeBetweenEighteenAndTwentyFour[i].firstName + ', last name: ' +
		studentsAgeBetweenEighteenAndTwentyFour[i].lastName + ', gender: ' +
		studentsAgeBetweenEighteenAndTwentyFour[i].gender + ', age: ' + studentsAgeBetweenEighteenAndTwentyFour[i].age +
		', country: ' + studentsAgeBetweenEighteenAndTwentyFour[i].country);
}

studentsFirstNameAlphabeticallyBeforeLastName = _.filter(students, function (student) {
	return student.firstName.localeCompare(student.lastName) === -1;
});
console.log('\nStudents whose first name is alphbetically before their last name:');

for(var i = 0; i < studentsFirstNameAlphabeticallyBeforeLastName.length; i++) {
	console.log('First name: ' + studentsFirstNameAlphabeticallyBeforeLastName[i].firstName + ', last name: ' +
		studentsFirstNameAlphabeticallyBeforeLastName[i].lastName + ', gender: ' +
		studentsFirstNameAlphabeticallyBeforeLastName[i].gender + ', age: ' +
		studentsFirstNameAlphabeticallyBeforeLastName[i].age + ', country: ' +
		studentsFirstNameAlphabeticallyBeforeLastName[i].country);
}

studentsFromBulgariaOnlyNames = _.map(_.where(students, { 'country': 'Bulgaria' }), function (student) {
	return { 'name': student.firstName + ' ' + student.lastName }
});
console.log('\nNames of students from Bulgaria:');

for(var i = 0; i < studentsFromBulgariaOnlyNames.length; i++) {
	console.log('Name: ' + studentsFromBulgariaOnlyNames[i].name);
}

lastFiveStudents = _.slice(students, students.length - 5, students.length);
console.log('\nLast five students:');

for(var i = 0; i < lastFiveStudents.length; i++) {
	console.log('First name: ' + lastFiveStudents[i].firstName + ', last name: ' +
		lastFiveStudents[i].lastName + ', gender: ' + lastFiveStudents[i].gender + ', age: ' +
		lastFiveStudents[i].age + ', country: ' + lastFiveStudents[i].country);
}

maleStudentsNotFromBulgaria = _.filter(students, function (student) {
	return student.gender === 'Male' && student.country !== 'Bulgaria';
});
firstThreeMaleStudentsNotFromBulgaria = _.slice(maleStudentsNotFromBulgaria, 0, 3);
console.log('\nFirst three male students not from Bulgaria:');

for(var i = 0; i < firstThreeMaleStudentsNotFromBulgaria.length; i++) {
	console.log('First name: ' + firstThreeMaleStudentsNotFromBulgaria[i].firstName + ', last name: ' +
		firstThreeMaleStudentsNotFromBulgaria[i].lastName + ', gender: ' + firstThreeMaleStudentsNotFromBulgaria[i].gender + ', age: ' +
		firstThreeMaleStudentsNotFromBulgaria[i].age + ', country: ' + firstThreeMaleStudentsNotFromBulgaria[i].country);
}