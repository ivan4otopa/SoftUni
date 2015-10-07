function buildATable(input) {
	var start = parseInt(input[0]);
	var end = parseInt(input[1]);
	console.log('<table>\n<tr><th>Num</th><th>Square</th><th>Fib</th></tr>');
	for(var i = start; i <= end; i++) {
		if(isFibonacci(i))
			console.log('<tr><td>' + i + '</td><td>' + i * i + '</td><td>yes</td></tr>');
		else
			console.log('<tr><td>' + i + '</td><td>' + i * i + '</td><td>no</td></tr>');
	}
	console.log('</table>');
	function isFibonacci(num) {
		var fib = [];
		fib[0] = 0;
		fib[1] = 1;
		for(var i = 2; i <= 30; i++) {
			fib[i] = fib[i - 2] + fib[i - 1];
			if(num == fib[i])
				return true;
		}
		return false;
	}
}

buildATable([2, 6]);
buildATable([55, 56]);