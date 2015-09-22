function soothsayer(numsArr, langsArr, citiesArr, carsArr) {
	var years = Math.floor(Math.random() * 4);
	var lang = Math.floor(Math.random() * 4);
	var city = Math.floor(Math.random() * 4);
	var car = Math.floor(Math.random() * 4);
	var result = [
		numsArr[years],
		langsArr[lang],
		citiesArr[city],
		carsArr[car]
	];
	console.log('You will work ' + result[0] + ' years on ' + result[1] + '. You will live in ' + result[2] + ' and drive ' + result[3] + '.');
}


soothsayer([3, 5, 2, 7, 9], ['Java', 'Python', 'C#', 'JavaScript', 'Ruby'], ['Silicon Valley', 'London', 'Las Vegas', 'Paris', 'Sofia'],
	['BMW', 'Audi', 'Lada', 'Skoda', 'Opel']);