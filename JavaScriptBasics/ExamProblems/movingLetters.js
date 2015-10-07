function solve(input) {
	var words = input.split(' ');
	var letters = [];
	for(var i = 0; i < words.length; i++) {
		letters[i] = words[i].split('');
	}
	console.log(letters);
}

solve('Fun exam right');
solve('Hi exam');