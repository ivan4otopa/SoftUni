function keepTheChange(input) {
	var bill = Number(input[0]);
	var mood = input[1];
	var tip = 0;
	if(mood == 'happy')
		tip = (0.1 * bill).toFixed(2);
	else if(mood == 'married')
		tip = (0.0005 * bill).toFixed(2);
	else if(mood == 'drunk') {
		tip = 0.15 * bill;
		splittedTip = tip.toString().split('');
		var firstDigit = Number(splittedTip[0]);
		for(var i = 0; i < firstDigit - 1; i++)
			tip *= tip;
		tip = tip.toFixed(2);
	}
	else
		tip = (0.05 * bill).toFixed(2);
	console.log(tip);
}

keepTheChange([120.44, 'happy']);

keepTheChange([1230.83, 'drunk']);

keepTheChange([716.00, 'married']);