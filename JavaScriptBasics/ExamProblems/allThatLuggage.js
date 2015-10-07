function allThatLuggage(input) {
	var result = {};
	var criterion = input[input.length - 1];
	for(var i = 0; i < input.length - 1; i++) {
		var matches = input[i].split(/\.*\*\.*/g);
		var name = matches[0];
		var type = matches[1];
		var isFood = matches[2];
		var isDrink = matches[3];
		var isFragile = true;
		if(matches[4] == 'true')
			isFragile = true;
		else
			isFragile = false;
		var weight = Number(matches[5]);
		var transfer = matches[6];
		if(!result[name])
			result[name] = {};
		if(isFood == 'true')
			result[name][type] = { 'kg': weight, 'fragile': isFragile, 'type': 'food', 'transferredWith': transfer };
		else if(isDrink == 'true')
			result[name][type] = { 'kg': weight, 'fragile': isFragile, 'type': 'drink', 'transferredWith': transfer };
		else if(isFood == 'false' && isDrink == 'false')
			result[name][type] = { 'kg': weight, 'fragile': isFragile, 'type': 'other', 'transferredWith': transfer };
	}
	var sortedObject = {};
	for(var name in result) {
		sortedObject[name] = {};
		var sortedKeys = Object.keys(result[name]).sort(function (a, b) {
			if(criterion == 'luggage name')
				return a.localeCompare(b);
			else if(criterion == 'weight')
				return result[name][a].kg > result[name][b].kg;
		});
		for(var i = 0; i < sortedKeys.length; i++)
			sortedObject[name][sortedKeys[i]] = result[name][sortedKeys[i]];
	}
	console.log(JSON.stringify(sortedObject));
}

allThatLuggage(['Yana Slavcheva.*.clothes.*.false.*.false.*.false.*.2.2.*.backpack',
'Kiko.*.socks.*.false.*.false.*.false.*.0.2.*.backpack',
'Kiko.*.banana.*.true.*.false.*.false.*.3.2.*.backpack',
'Kiko.*.sticks.*.false.*.false.*.false.*.1.6.*.ATV',
'Kiko.*.glasses.*.false.*.false.*.true.*.3.*.ATV',
'Manov.*.socks.*.false.*.false.*.false.*.0.3.*.ATV',
'weight'
]);