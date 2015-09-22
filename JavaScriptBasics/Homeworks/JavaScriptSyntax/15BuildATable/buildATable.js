function buildATable(input) {
	var start = parseInt(input[0]);
    var end = parseInt(input[1]);

	function isFibonacci(number) {
		var count = 0;
		var fib = [];

		for(var i = 2; i < 36; i++) {
			fib[0] = 0;
			fib[1] = 1;
			fib[i] = fib[i - 2] + fib[i - 1];
			if(fib[i] == number)
				count++;
		}

		if(count == 1)
			return 'yes';
		else
			return 'no';
	}
	console.log('<table>\n<tr><th>Num</th><th>Square</th><th>Fib</th></tr>');

	for(var num = start; num <= end; num++) {
		console.log('<tr><td>' + num + '</td><td>' + num * num + '</td><td>' + isFibonacci(num) + '</td></tr>');
	}
	console.log('</table>');
}