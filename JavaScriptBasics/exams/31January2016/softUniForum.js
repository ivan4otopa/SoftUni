function softUniForum(input) {
	var regex = /#([a-zA-Z][a-zA-Z0-9-_]{3,})/g;
	var bannedNames = input[input.length - 1].split(' ');
	var codeStarted = false;
	var match = [];
	var username = '';

	for (var i = 0; i < input.length - 1; i++) {
		if (input[i].indexOf('<code>') != -1) {
			codeStarted = true;
		} 

		if (!codeStarted) {
			match = input[i].match(regex);

			if (match != null) {
				if (match.length > 1) {
					for (var j = 0; j < match.length; j++) {
						if (checkLastCharacter(match[j])) {
							username = match[j].substr(1);

							transformText(username);
						}
					}
				} else {
					if (checkLastCharacter(match[0])) {
						username = match[0].substr(1);

						transformText(username);
					}
				}
			}
		}

		if(input[i].indexOf('</code>') != -1) {
			codeStarted = false;
		}
	}

	for (var i = 0; i < input.length - 1; i++) {
		console.log(input[i]);
	}

	function checkLastCharacter(username) {
		var regex = /[a-z0-9]/i;
		var match = username[username.length - 1].match(regex);

		return match != null;
	}

	function transformText(username) {
		if (bannedNames.indexOf(username) == -1) {
			if (input[i].indexOf(username) == 1) {
				input[i] = '<a href="/users/profile/show/' +
					username +
					'">' +
					username +
					'</a>' +
					input[i].substr(input[i].indexOf('#' + username) + username.length + 1);	
			} else {
				input[i] = input[i].substr(0, input[i].indexOf('#' + username)) +
					'<a href="/users/profile/show/' +
					username +
					'">' +
					username +
					'</a>' +
					input[i].substr(input[i].indexOf('#' + username) + username.length + 1);
			}
		} else {
			if (input[i].indexOf('#' + username) == 0) {
				input[i] = Array(username.length + 1).join('*') +
					input[i].substr(input[i].indexOf('#' + username) + username.length + 1);
			} else {
				input[i] = input[i].substr(0, input[i].indexOf('#' + username)) +
					Array(username.length + 1).join('*') +
					input[i].substr(input[i].indexOf('#' + username) + username.length + 1);
			}
		}		
	}
}

softUniForum([
	'<code>',
	'#lele',
	'#pochna se </code>',
	'<code> #mani_begai #gosho <code>',
	'gosho'
]);