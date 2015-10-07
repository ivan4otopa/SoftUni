function solve(str) {
	var words = [];
	var  cognateWordsArray = [];
	words = str[0].match(/[a-zA-Z]+/g);
	if(words != null) {
		for(var i = 0; i < words.length; i++) {
			for(var j = 0; j < words.length; j++) {
				for(var k = 2; k < words.length; k++) {
					var a = words[i];
					var b = words[j];
					var c = words[k];
					var cognateWords = a + b == c;
					if(cognateWords) {
						var string = a + '|' + b + '=' + c;
						cognateWordsArray.push(string);
					}
				}
			}
		}
		if(cognateWordsArray.length == 0)
	  		console.log('No');
	  	else {
	  		var cognateWordsUniqueArray
			cognateWordsUniqueArray = cognateWordsArray.filter(function(elem, pos) {
		    return cognateWordsArray.indexOf(elem) == pos;
		  	});
			for(var i = 0; i < cognateWordsUniqueArray.length; i++)
				console.log(cognateWordsUniqueArray[i]);
		}
	}
	else
		console.log('No');
}

solve('java..?|basics/*-+=javabasics');
solve('Hi, Hi, Hihi');
solve('Uni(lo,.ve=I love SoftUni (Soft)');
solve('a a aa a');
solve('x a ab b aba a hello+java a b aaaaa');
solve('aa bb bbaa');
solve('ho hoho');