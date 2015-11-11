INSERT INTO TeamMatches(HomeTeamId, AwayTeamId, HomeGoals, AwayGoals, MatchDate, LeagueId)
VALUES(
	(SELECT Id FROM Teams WHERE TeamName = 'Internazionale'), 
	(SELECT Id FROM Teams WHERE TeamName = 'AC Milan'),
	0,
	0,
	'19-Apr-2015 21:45',
	(SELECT Id FROM Leagues WHERE LeagueName = 'Italian Serie A'))