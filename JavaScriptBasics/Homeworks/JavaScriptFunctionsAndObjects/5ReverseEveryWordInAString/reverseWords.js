function reverseWordsInString(str) {
	var words = str.split(' ');
	for(var i = 0; i < words.length; i++)
		words[i] = words[i].split('').reverse().join('');
	console.log(words.join(' '));
}

reverseWordsInString('Hello, how are you.');
reverseWordsInString('Life is pretty good, isn’t it?');