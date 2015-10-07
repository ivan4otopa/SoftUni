function uncleScroogesBag (input) {
		numberOfInputs = input.length,
		line = [],
		typeOfValue = '',
		value = 0,
		totalCoins = 0;

	for(var i = 0; i < numberOfInputs; i++) {
		line = input[i].split(' ');
		typeOfValue = line[0].toLowerCase();
		value = Number(line[1]);

		if(typeOfValue === 'coin' && !isNaN(value) && isInteger(value) && value > 0) {
			totalCoins += value;
		}
	}

	console.log('gold : ' + Math.floor(totalCoins / 100) + '\nsilver : ' + Math.floor((totalCoins % 100) / 10)
		+ '\nbronze : ' + totalCoins % 10);

	function isInteger (value) {
		return parseFloat(value) % 1 === 0;
	};
}

uncleScroogesBag(['coin 1','coin 2', 'coin 5', 'coin 10', 'coin 20', 'coin 50', 'coin 100', 'coin 200', 'coin 500','cigars 1']);

uncleScroogesBag(['coin one', 'coin two', 'coin five', 'coin ten', 'coin twenty', 'coin fifty', 'coin hundred', 'cigars 1']);

uncleScroogesBag(['coin 1', 'coin two', 'coin 5', 'coin 10.50', 'coin 20', 'coin 50', 'coin hundred', 'cigars 1']);