function soccerResults(input) {
	var results = {};
	for(var i = 0; i < input.length; i++) {
		var regex = /([a-zA-Z\s]+)\/([a-zA-Z\s]+):([0-9\s]+)-([0-9\s]+)/g;
		var matches = regex.exec(input[i]);
		var homeTeam = matches[1].trim();
		var awayTeam = matches[2].trim();
		var homeGoals = Number(matches[3].trim());
		var awayGoals = Number(matches[4].trim());
		if(!results[homeTeam])
			results[homeTeam] = {goalsScored: 0, goalsConceded: 0, matchesPlayedWith: []};
		results[homeTeam].goalsScored += homeGoals;
		results[homeTeam].goalsConceded += awayGoals;
		if(results[homeTeam].matchesPlayedWith.indexOf(awayTeam) == -1)
			results[homeTeam].matchesPlayedWith.push(awayTeam);
		if(!results[awayTeam])
			results[awayTeam] = {goalsScored: 0, goalsConceded: 0, matchesPlayedWith: []};
		results[awayTeam].goalsScored += awayGoals;
		results[awayTeam].goalsConceded += homeGoals;
		if(results[awayTeam].matchesPlayedWith.indexOf(homeTeam) == -1)
			results[awayTeam].matchesPlayedWith.push(homeTeam);
	}
	var sortedResults = {};
	keys = Object.keys(results).sort();
	for(var i = 0; i < keys.length; i++)
		sortedResults[keys[i]] = results[keys[i]];
	for(var team in results)
		results[team].matchesPlayedWith.sort();
	console.log(JSON.stringify(sortedResults));
}

soccerResults(['Germany / Argentina: 1-0',
'Brazil / Netherlands: 0-3',
'Netherlands / Argentina: 0-0',
'Brazil / Germany: 1-7',
'Argentina / Belgium: 1-0',
'Netherlands / Costa Rica: 0-0',
'France / Germany: 0-1',
'Brazil / Colombia: 2-1'
])