INSERT INTO TeamMatches(HomeTeamId, AwayTeamId, HomeGoals, AwayGoals, MatchDate, LeagueId)
VALUES(
	(SELECT Id FROM Teams WHERE TeamName = 'Empoli'), 
	(SELECT Id FROM Teams WHERE TeamName = 'Parma'),
	2,
	2,
	'19-Apr-2015 16:00',
	(SELECT Id FROM Leagues WHERE LeagueName = 'Italian Serie A'))