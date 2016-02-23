function rollandGarros(input) {
	var regex = /([a-zA-Z\s]+)\s*vs.\s*([a-zA-Z\s]+)\s*:\s*([\d-\d\s]+)/;
	var players = [];

	for (var line in input) {
		var match = input[line].match(regex);
		var playerOneName = match[1].trim();
		var playerTwoName = match[2].trim();
		var results = match[3].split(/\s+/);
		var playerOneNames = playerOneName.split(/\s+/);
		var playerTwoNames = playerTwoName.split(/\s+/);

		playerOneName = playerOneNames[0] + ' ' + playerOneNames[1];
		playerTwoName = playerTwoNames[0] + ' ' + playerTwoNames[1];

		var playerOneMatchesWon = 0;
		var playerOneMatchesLost = 0;
		var playerOneSetsWon = 0;
		var playerOneSetsLost = 0;
		var playerOneGamesWon = 0;
		var playerOneGamesLost = 0;
		var playerTwoMatchesWon = 0;
		var playerTwoMatchesLost = 0;
		var playerTwoSetsWon = 0;
		var playerTwoSetsLost = 0;
		var playerTwoGamesWon = 0;
		var playerTwoGamesLost = 0;

		for (var result in results) {
			var resultMatch = results[result].match(/(\d)-(\d)/);
			var gamesForPlayerOne = Number(resultMatch[1]);
			var gamesForPlayerTwo = Number(resultMatch[2]);

			playerOneGamesWon += gamesForPlayerOne;
			playerOneGamesLost += gamesForPlayerTwo;
			playerTwoGamesWon += gamesForPlayerTwo;
			playerTwoGamesLost += gamesForPlayerOne;

			if (gamesForPlayerOne > gamesForPlayerTwo) {
				playerOneSetsWon++;
				playerTwoSetsLost++;
			} else if (gamesForPlayerOne < gamesForPlayerTwo) {
				playerOneSetsLost++;
				playerTwoSetsWon++;
			}
		}

		if (playerOneSetsWon > playerTwoSetsWon) {
			playerOneMatchesWon++;
			playerTwoMatchesLost++;
		} else if (playerOneSetsWon < playerTwoSetsWon) {
			playerOneMatchesLost++;
			playerTwoMatchesWon++;
		}

		players.push({ 
			'name': playerOneName, 
			'matchesWon': playerOneMatchesWon, 
			'matchesLost': playerOneMatchesLost, 
			'setsWon': playerOneSetsWon, 
			'setsLost': playerOneSetsLost, 
			'gamesWon': playerOneGamesWon, 
			'gamesLost': playerOneGamesLost });
		players.push({ 
			'name': playerTwoName, 
			'matchesWon': playerTwoMatchesWon, 
			'matchesLost': playerTwoMatchesLost, 
			'setsWon': playerTwoSetsWon, 
			'setsLost': playerTwoSetsLost, 
			'gamesWon': playerTwoGamesWon, 
			'gamesLost': playerTwoGamesLost });
	}

	for (var i = 0; i < players.length - 1; i++) {
		var playerName = players[i].name;

		for (var j = i + 1; j < players.length; j++) {
			if (players[j].name == playerName) {
				players[i].matchesWon += players[j].matchesWon;
				players[i].matchesLost += players[j].matchesLost;
				players[i].setsWon += players[j].setsWon;
				players[i].setsLost += players[j].setsLost;
				players[i].gamesWon += players[j].gamesWon;
				players[i].gamesLost += players[j].gamesLost;
				players.splice(j, 1);
				j--;
			}
		}
	}

	players.sort(function (a, b) {
		if (a.matchesWon === b.matchesWon) {
			if (a.setsWon === b.setsWon) {
				if (a.gamesWon === b.gamesWon) {
					return a.name.localeCompare(b.name);
				}

				return b.gamesWon - a.gamesWon;
			}

			return b.setsWon - a.setsWon;
		}

		return b.matchesWon - a.matchesWon;
	})

	function containsObjectWithName(playerName, list) {
	    var i;

	    for (i = 0; i < list.length; i++) {
	        if (list[i].name === playerName) {
	            return true;
	        }
	    }

	    return false;
	}

	console.log(JSON.stringify(players));
}

rollandGarros([
	'Novak Djokovic vs. Roger Federer : 6-3 6-3',
	'Roger    Federer    vs.        Novak Djokovic    :         6-2 6-3',
	'Rafael Nadal vs. Andy Murray : 4-6 6-2 5-7',
	'Andy Murray vs. David     Ferrer : 6-4 7-6',
	'Tomas   Bedrych vs. Kei Nishikori : 4-6 6-4 6-3 4-6 5-7',
	'Grigor Dimitrov vs. Milos Raonic : 6-3 4-6 7-6 6-2',
	'Pete Sampras vs. Andre Agassi : 2-1',
	'Boris Beckervs.Andre        Agassi:2-1'
]);