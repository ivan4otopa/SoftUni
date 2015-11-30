function captainObvious(input) {
	var splittedSentence = input[0].split(' ');
	var wordsCounts = {};
	var splittedText = input[1].match(/[^\.!\?]+[\.!\?]+/g);
	var hasWords = true;

	for(var word in splittedSentence) {
		splittedSentence[word] = splittedSentence[word].replace(/[^a-zA-Z]/, '');
	}

	for(var word in splittedSentence) {
		var caseInsensitiveWord = splittedSentence[word].toLowerCase();

		if (wordsCounts[caseInsensitiveWord] == null) {
			wordsCounts[caseInsensitiveWord] = 0;
		}

		if (caseInsensitiveWord in wordsCounts) {
			wordsCounts[caseInsensitiveWord]++;
		}
	}	

	for(var word in wordsCounts) {
		if (wordsCounts[word] < 3) {
			delete wordsCounts[word];
		}
	}

	if (Object.keys(wordsCounts).length == 0) {
		hasWords = false;
		console.log('No words');
	}

	for(var sentence in splittedText) {
		if (splittedText[sentence].charAt(0) == ' ') {
			splittedText[sentence] = splittedText[sentence].slice(1);
		}
	}	

	var hasSentences = false;

	for(var sentence in splittedText) {
		var containCount = 0;
		var sentenceWords = splittedText[sentence].split(' ');
		
		for(var word in sentenceWords) {
			sentenceWords[word] = sentenceWords[word].replace(/[^a-zA-Z]/, '').toLowerCase();
		}
	
		for(var word in wordsCounts) {
			if(sentenceWords.indexOf(word) > -1) {
				containCount++;
			}
		}
		
		if(containCount >= 2) {
			hasSentences = true;
			console.log(splittedText[sentence]);
		}
	}

	if (!hasSentences && hasWords) {
		console.log('No sentences');
	}
}