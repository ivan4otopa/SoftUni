function findPalindromes(str) {
	var words = str.replace(/[,\.]/g, '').toLowerCase().split(' ');
	var reversed = '';
	var output = [];
	for(var i = 0; i < words.length; i++) {
		reversed = words[i].split('').reverse().join('');
		if(reversed == words[i])
			output.push(words[i])
	}
	console.log(output.join(', '));
}

findPalindromes('There is a man, his name was Bob.');