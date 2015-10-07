function biggestTableRow(input) {
	var regex = /[^a-zA-Z](-*[0-9.0-9]+|-)/g;
	var maxPrice = -100000;
	var value1 = 0;
	var value2 = 0;
	var value3 = 0;
	for(var i = 2; i < input.length - 1; i++) {
		var matches = input[i].match(regex);
		var a = 0;
		var b = 0;
		var c = 0;
		if(matches[0].substr(1) != '-')
			a = Number(matches[0].substr(1));
		else
			a = 0;
		if(matches[1].substr(1) != '-')
			b = Number(matches[1].substr(1));
		else
			b = 0;
		if(matches[2].substr(1) != '-')
			c = Number(matches[2].substr(1));
		else
			c = 0;
		var price = a + b + c;
		if(maxPrice < price) {
			maxPrice = price;
			value1 = matches[0].substr(1);
			value2 = matches[1].substr(1);
			value3 = matches[2].substr(1);
		}
	}
	if(maxPrice != 0) {
		if(value1 == '-' && value2 != '-' && value3 != '-')
			console.log(maxPrice + ' = ' + value2 + ' + ' + value3);
		else if(value2 == '-' && value1 != '-' && value3 != '-')
			console.log(maxPrice + ' = ' + value1 + ' + ' + value3);
		else if(value3 == '-' && value1 != '-' && value2 != '-')
			console.log(maxPrice + ' = ' + value1 + ' + ' + value2);
		else if(value1 == '-' && value2 == '-')
			console.log(maxPrice + ' = ' + value3);
		else if(value1 == '-' && value3 == '-')
			console.log(maxPrice + ' = ' + value2);
		else if(value2 == '-' && value3 == '-')
			console.log(maxPrice + ' = ' + value1);
		else
			console.log(maxPrice + ' = ' + value1 + ' + ' + value2 + ' + ' + value3);
	}
	else
		console.log('no data');
}

biggestTableRow(['<table>',
'<tr><th>Town</th><th>Store1</th><th>Store2</th><th>Store3</th></tr>',
'<tr><td>Sofia</td><td>26.2</td><td>8.20</td><td>-</td></tr>',
'<tr><td>Varna</td><td>11.2</td><td>18.00</td><td>36.10</td></tr>',
'<tr><td>Plovdiv</td><td>17.2</td><td>12.3</td><td>6.4</td></tr>',
'<tr><td>Bourgas</td><td>-</td><td>24.3</td><td>-</td></tr>',
'</table>'
]);

biggestTableRow(['<table>',
'<tr><th>Town</th><th>Store1</th><th>Store2</th><th>Store3</th></tr>',
'<tr><td>Sofia</td><td>-</td><td>-</td><td>-</td></tr>',
'</table>'
]);

biggestTableRow(['<table>',
'<tr><th>Town</th><th>Store1</th><th>Store2</th><th>Store3</th></tr>',
'<tr><td>Sofia</td><td>12850</td><td>-560</td><td>20833</td></tr>',
'<tr><td>Rousse</td><td>-</td><td>50000.0</td><td>-</td></tr>',
'<tr><td>Bourgas</td><td>25000</td><td>25000</td><td>-</td></tr>',
'</table>'
]);