function theNumbers(input) {
	var text = input[0];
	var numbers = text.match(/[0-9]+/g);
	for(var i = 0; i < numbers.length; i++) {
		numbers[i] = Number(numbers[i]).toString(16).toUpperCase();
		if(numbers[i].length < 4)
			numbers[i] = Array(5 - numbers[i].length).join('0') + numbers[i];
		numbers[i] = '0x' + numbers[i];
	}
	console.log(numbers.join('-'));
}

theNumbers(['5tffwj(//*7837xzc2---34rlxXP%$”.']);

theNumbers(['482vMWo(*&^%$213;k!@41341((()&^>><///]42344p;e312']);

theNumbers(['20']);