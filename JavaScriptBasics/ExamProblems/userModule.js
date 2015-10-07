function userModule(input) {
	var sortTypes = input[0].split('^');
	var studentSort = sortTypes[0];
	var trainerSort = sortTypes[1];
	var module = { 'students': [], 'trainers': [] };
	for(var i = 1; i < input.length; i++) {
		var user = JSON.parse(input[i]);
		if(user.role == 'student') {
			module.students.push(user);
		}
		else
			module.trainers.push(user);
	}
	for(var user in module) {
		if(module[user] == module.students) {
			for(var student in module[user]) {
				module[user][student].averageGrade = average(module.students[student].grades);
				delete module[user][student].grades;
				delete module[user][student].role;
				delete module[user][student].town;
				var certif = module[user][student].certificate;
				delete module[user][student].certificate;
				module[user][student].certificate = certif;
			}
			if(studentSort == 'name') {
				module[user].sort(function (a, b) {
					if(a.firstname.localeCompare(b.firstname) != 0)
						return a.firstname.localeCompare(b.firstname);
					else
						return a.lastname.localeCompare(b.lastname);
				});
				for(var student in module[user])
					delete module[user][student].level;
			}
			else if(studentSort == 'level') {
				module[user].sort(function (a, b) {
					if(a.level - b.level == 0)
						return a.id - b.id;
					else
						return a.level - b.level;
				});
				for(var student in module[user])
					delete module[user][student].level;
			}
		}
		else if(module[user] == module.trainers) {
			for(var trainer in module[user]) {
				delete module[user][trainer].town;
				delete module[user][trainer].role;
			}
			if(trainerSort == 'courses') {
				module[user].sort(function (a, b) {
					if(a.courses.length - b.courses.length == 0)
						return a.lecturesPerDay - b.lecturesPerDay;
					else
						return a.courses.length - b.courses.length;
				})
			}
		}
	}
	console.log(JSON.stringify(module));
	function average(input) {
		var sum = 0;
		for(var i = 0; i < input.length; i++)
			sum += Number(input[i]);
		var average = sum / input.length;
		return average.toFixed(2);
	}
}

userModule(['level^courses',
'{"id":0,"firstname":"Angel","lastname":"Ivanov","town":"Plovdiv","role":"student","grades":["5.89"],"level":2,"certificate":false}',
'{"id":1,"firstname":"Mitko","lastname":"Nakova","town":"Dimitrovgrad","role":"trainer","courses":["PHP","Unity Basics"],"lecturesPerDay":6}',
'{"id":2,"firstname":"Bobi","lastname":"Georgiev","town":"Varna","role":"student","grades":["5.59","3.50","4.54","5.05","3.45"],"level":4,"certificate":false}',
'{"id":3,"firstname":"Ivan","lastname":"Ivanova","town":"Vidin","role":"trainer","courses":["JS","Java","JS OOP","Database","OOP","C#"],"lecturesPerDay":7}',
'{"id":4,"firstname":"Mitko","lastname":"Petrova","town":"Sofia","role":"trainer","courses":["Database","JS Apps","Java"],"lecturesPerDay":2}'
]);