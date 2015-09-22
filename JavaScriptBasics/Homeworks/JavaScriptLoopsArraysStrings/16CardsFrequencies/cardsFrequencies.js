function findCardFrequency(str) {
	var tempFaces = str.split(/\W+/g);
    var cardFaces = tempFaces.filter(function(v){return v!==''});
	var freq = {};
	for(var i = 0; i < cardFaces.length; i++) {
		if(!freq[cardFaces[i]])
			freq[cardFaces[i]] = 1;
		else
			freq[cardFaces[i]] += 1;
	}
	for(var i = 0; i < cardFaces.length; i++) {
		if(freq[cardFaces[i]]) {
			var frequency = ((freq[cardFaces[i]] / cardFaces.length) * 100).toFixed(2);
			console.log(cardFaces[i] + ' -> ' + frequency + '%');
			delete freq[cardFaces[i]];
		}
	}
}

findCardFrequency('8♥ 2♣ 4♦ 10♦ J♥ A♠ K♦ 10♥ K♠ K♦');
findCardFrequency('J♥ 2♣ 2♦ 2♥ 2♦ 2♠ 2♦ J♥ 2♠');
findCardFrequency('10♣ 10♥');