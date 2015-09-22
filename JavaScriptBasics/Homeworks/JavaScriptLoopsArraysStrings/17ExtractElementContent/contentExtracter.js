function extractContent(str) {
	var matcher = str.match(/>\w+</g);
	var output = [];
	for(var match in matcher)
		output.push(matcher[match].substring(1, matcher[match].length - 1));
	console.log(output.join(''));
}

extractContent('<p>Hello</p><a href=\'http://w3c.org\'>W3C</a>')