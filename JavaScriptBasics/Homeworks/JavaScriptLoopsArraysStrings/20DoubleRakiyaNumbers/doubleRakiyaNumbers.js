function doubleRakiyaNumbers(arr) {
	var start = parseInt(arr[0]);
	var end = parseInt(arr[1]);
	console.log('<ul>');
	for(var i = start; i <= end; i++) {
		if(!isRakiyaNumber(i))
			console.log('<li><span class=\'num\'>' + i + '</span></li>');
		else
			console.log('<li><span class=\'rakiya\'>' + i + '</span><a href=\"view.php?id=' + i + '>View</a></li>');
	}
	console.log('</ul>');
	function isRakiyaNumber(num) {
		var digits = num.toString().split('');
		for(var i = 0; i < digits.length - 2; i++) {
			for(var j = i + 2; j < digits.length - 1; j++) {
				var a = digits[i];
				var b = digits[i + 1];
				var c = digits[j];
				var d = digits[j + 1];
				var firstCouple = '' + a + b;
				var secondCouple = '' + c + d;
				if(firstCouple == secondCouple)
					return true;
			}
		}
	}
}



doubleRakiyaNumbers([5, 8]);
doubleRakiyaNumbers([11210, 11215]);
doubleRakiyaNumbers([55555,55560])