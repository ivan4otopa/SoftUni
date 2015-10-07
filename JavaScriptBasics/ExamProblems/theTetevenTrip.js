function theTetevenTrip(input) {
	for(var i = 0; i < input.length; i++) {
		var matches = input[i].split(' ');
		var car = matches[0];
		var fuel = matches[1];
		var route = matches[2];
		var luggageWeight = Number(matches[3]);
		var consumption = 0;
		if(fuel == 'gas')
			consumption = 12;
		else if(fuel == 'petrol')
			consumption = 10;
		else if(fuel == 'diesel')
			consumption = 8;
		var extraFuel = luggageWeight * 0.01;
		consumption += extraFuel;
		var result = 0;
		if(route == '1') {
			var totalConsumption = (consumption / 100) * 110;
			var extraConsumption = 0.3 * (10 * (consumption / 100));
			result = totalConsumption + extraConsumption;
		}
		else if(route == '2') {
			var totalConsumption = (consumption / 100) * 95;
			var extraConsumption = 0.3 * (30 * (consumption / 100));
			result = totalConsumption + extraConsumption;
		}
		console.log(car + ' ' + fuel + ' ' + route + ' ' + Math.round(result));
	}
}

console.log(theTetevenTrip(['BMW petrol 1 320.5',
'Golf petrol 2 150.75',
'Lada gas 1 202',
'Mercedes diesel 2 312.54']
));