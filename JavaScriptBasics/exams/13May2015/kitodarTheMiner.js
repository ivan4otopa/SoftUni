function kitodarTheMiner(input) {
	var regex = /mine\s+.*\s*-\s+(gold|silver|diamonds):\s+(\d+)/;
	var oresQuantities = { 'silver': 0, 'gold': 0, 'diamonds': 0 };
	
	for(var line in input) {
		var match = input[line].match(regex);

		if (match != null) {
			var ore = match[1].trim();
			var quantity = parseInt(match[2].trim());

			oresQuantities[ore] += quantity;
		}
	}

	for(var ore in oresQuantities) {
		console.log('*' + ore.charAt(0).toUpperCase() + ore.slice(1) + ': ' + oresQuantities[ore]);
	}
}