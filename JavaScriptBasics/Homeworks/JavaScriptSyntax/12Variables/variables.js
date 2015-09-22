function variablesTypes(arr) {
	var name = arr[0];
	var age = arr[1];
	var isMale = arr[2];
	var foods = arr[3];
	console.log('\"My name: ' + name + ' // type is ' + typeof(name) + '\nMy age: ' + age + ' // type is ' + typeof(age)
		+ '\nI am male: ' + isMale + ' // type is ' + typeof(isMale) + '\nMy favourite foods are: ' + foods + ' // type is ' + typeof(foods) + '\"');
}

variablesTypes(['Pesho', 22, true, ['fries', 'banana', 'cake']]);