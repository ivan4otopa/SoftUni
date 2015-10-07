function useYourChainsBuddy(input) {
	var regex = /<p>(.*?)<\/p>/g;
	var matches = input[0].match(regex);
	var output = '';
	for(var i = 0; i < matches.length; i++) {
		var text = matches[i].substr(3).substr(0, matches[i].length - 7);
		text = text.replace(/[^a-z0-9]/g, ' ');
		var result = text.split('');
		for(var j = 0; j < text.length; j++) {
			if(isaTom(text[j]))
				result[j] = String.fromCharCode(text[j].charCodeAt(0) + 13);
			else if(isnToz(text[j]))
				result[j] = String.fromCharCode(text[j].charCodeAt(0) - 13);
		}
		result = result.join('');
		result = result.replace(/\s{2,}/g, ' ');
		output += result;
	}
	console.log(output);
	function isaTom(chr) {
		if(chr.charCodeAt(0) >= 97 && chr.charCodeAt(0) <= 109)
			return true;
		return false;
	}
	function isnToz(chr) {
		if(chr.charCodeAt(0) >= 110 && chr.charCodeAt(0) <= 122)
			return true;
	}
}

useYourChainsBuddy(['<html><head><title></title></head><body><h1>hello</h1><p>znahny!@#%&&&&****</p><div><button>dsad</button></div><p>grkg^^^^%%%)))([]12</p></body></html>']);

useYourChainsBuddy(['<html><head><title></title></head><body><h1>Intro</h1><ul><li>Item01</li><li>Item02</li><li>Item03</li></ul><p>jura qevivat va jrg fyvccrel fabjl</p><div><button>Click me, baby!</button></div><p> pbaqvgvbaf fabj  qpunvaf ner nofbyhgryl rffragvny sbe fnsr unaqyvat nygubhtu fabj punvaf znl ybbx </p><span>This manual is false, do not trust it! The illuminati wrote it down to trick you!</span><p>vagvzvqngvat gur onfvp vqrn vf ernyyl fvzcyr svg gurz bire lbhe gverf qevir sbejneq fybjyl naq gvtugra gurz hc va pbyq jrg</p><p> pbaqvgvbaf guvf vf rnfvre fnvq guna qbar ohg vs lbh chg ba lbhe gverf</p></body>']);