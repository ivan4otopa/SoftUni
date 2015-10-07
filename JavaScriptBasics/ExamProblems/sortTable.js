function sortTable(input) {
	var prices = [];
	for(var i = 2; i < input.length - 1; i++) {
		var regex = />([0-9]+\.?[0-9]+)/g;
		var extraction = regex.exec(input[i]);
		var price = Number(extraction[1]);
		var tableRow = {price: price, row: input[i]};
		prices.push(tableRow)
	}
	prices.sort(function(a, b) {
		if(a.price == b.price)
			return a.row > b.row;
		else
			return a.price > b.price;
	});
	console.log(input[0]);
	console.log(input[1]);
	for(var row in prices)
		console.log(prices[row].row);
	console.log(input[input.length - 1]);
}

sortTable(['<table>',
'<tr><th>Product</th><th>Price</th><th>Votes</th></tr>',
'<tr><td>Kamenitza Grapefruit 1 l</td><td>1.85</td><td>+7</td></tr>',
'<tr><td>Vodka Finlandia 1 l</td><td>19.35</td><td>+12</td></tr>',
'<tr><td>Laptop Lenovo IdeaPad B5400</td><td>929.00</td><td>0</td></tr>',
'<tr><td>Laptop ASUS ROG G550JK-CN268D</td><td>1939.00</td><td>+1</td></tr>',
'<tr><td>Ariana Radler 0.5 l</td><td>1.19</td><td>+33</td></tr>',
'<tr><td>Coffee Davidoff 250 gr.</td><td>11.99</td><td>+11</td></tr>',
'<tr><td>Kamenitza Lemon 1 l</td><td>1.65</td><td>+7</td></tr>',
'<tr><td>Vodka Absolute 1 l</td><td>22.00</td><td>+2</td></tr>',
'<tr><td>Laptop Dell Inspiron 3537</td><td>1199.0</td><td>+3</td></tr>',
'<tr><td>Laptop HP 250 G2</td><td>629</td><td>-10</td></tr>',
'<tr><td>Ariana Radler 1.5 l</td><td>2.79</td><td>+33</td></tr>',
'<tr><td>Coffee Lavazza 250 gr.</td><td>8.73</td><td>+10</td></tr>',
'</table>'

]);