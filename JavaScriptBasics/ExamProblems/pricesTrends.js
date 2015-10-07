function pricesTrends(input) {
	input[0] = Number(input[0]);
	input[0] = input[0].toFixed(2);
	console.log('<table>\n<tr><th>Price</th><th>Trend</th></tr>');
	console.log('<tr><td>' + input[0] + '</td><td><img src="fixed.png"/></td></td>');
	for(var i = 1; i < input.length; i++) {
		input[i - 1] = Number(input[i - 1]);
		input[i - 1] = input[i - 1].toFixed(2);
		input[i] = Number(input[i]);
		input[i] = input[i].toFixed(2);
		if(input[i] < input[i - 1])
			console.log('<tr><td>' + input[i] + '</td><td><img src="down.png"/></td></td>');
		else if(input[i] == input[i - 1])
			console.log('<tr><td>' + input[i] + '</td><td><img src="fixed.png"/></td></td>');
		else
			console.log('<tr><td>' + input[i] + '</td><td><img src="up.png"/></td></td>');
	}
	console.log('</table>');
}

pricesTrends(['50',
'60'
]);

pricesTrends(['36.333',
'36.5',
'37.019',
'35.4',
'35',
'35.001',
'36.225'
])