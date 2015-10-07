function queryMess(input) {
	for(var i = 0; i < input.length; i++) {
		var result = {}
		var matches = input[i].match(/([^&=?]+)=([^=?&]+)/g);
		for(var j = 0; j < matches.length; j++) {
			var matches1 = matches[j].split('=');
			var field = matches1[0].replace(/(%20|\+)+/g, ' ').trim();
			var value = matches1[1].replace(/(%20|\+)+/g, ' ').trim();
			if(!result[field])
				result[field] = [];
			result[field].push(value);
		}
		var output = '';
		for(var field in result)
			output += field + '=[' + result[field].join(', ') + ']';
		console.log(output);
	}
}

queryMess(['login=student&password=student']);

queryMess(['field=value1&field=value2&field=value3',
'http://example.com/over/there?name=ferret'
]);

queryMess(['foo=%20foo&value=+val&foo+=5+%20+203',
'foo=poo%20&value=valley&dog=wow+',
'url=https://softuni.bg/trainings/coursesinstances/details/1070',
'https://softuni.bg/trainings.asp?trainer=nakov&course=oop&course=php'
]);