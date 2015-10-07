function daggersAndSwords(input) {
	var lengths = input;
	for(var i = 0; i < lengths.length; i++)
		lengths[i] = Math.floor(lengths[i]);
	console.log('<table border="1">\n<thead>\n<tr><th colspan="3">Blades</th></tr>\n<tr><th>Length [cm]</th><th>Type</th><th>Application</th></tr>\n</thead>\n<tbody>');
	for(var i = 0; i < lengths.length; i++) {
		var blade = lengths[i];
		var bladeString = '';
		var bladeType = '';
		if(blade > 10 && blade <= 40) {
			bladeType = 'dagger';
			bladeString = bladeToString(blade);
			console.log('<tr><td>' + blade + '</td><td>' + bladeType + '</td><td>' + bladeString + '</td></tr>');
		}
		else if(blade > 40) {
			bladeString = bladeToString(blade);
			bladeType = 'sword';
			console.log('<tr><td>' + blade + '</td><td>' + bladeType + '</td><td>' + bladeString + '</td></tr>');
		}
	}
	console.log('</tbody>\n</table>');
	function bladeToString(blade) {
		var splittedBlade = blade.toString().split('');
		var lastDigit = splittedBlade[splittedBlade.length - 1];
		var bladeString = '';
		if(lastDigit == 1 || lastDigit == 6)
			bladeString = 'blade';
		else if(lastDigit == 2 || lastDigit == 7)
			bladeString = 'quite a blade';
		else if(lastDigit == 3 || lastDigit == 8)
			bladeString = 'pants-scraper';
		else if(lastDigit == 4 || lastDigit == 9)
			bladeString = 'frog-butcher';
		else if(lastDigit == 5 || lastDigit == 0)
			bladeString = '*rap-poker'
		return bladeString;
	}
}

daggersAndSwords(['17.8',
'19.4',
'13',
'55.8',
'126.96541651',
'3'
])