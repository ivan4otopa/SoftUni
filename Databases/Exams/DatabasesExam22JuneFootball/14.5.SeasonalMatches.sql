SELECT 
	t1.TeamName AS [Home Team], 
	ISNULL(tm.HomeGoals, 0) AS [Home Goals],
	t2.TeamName AS [Away Team], 
	ISNULL(tm.AwayGoals, 0) AS [Away Goals], 
	l.LeagueName AS [League Name]
	FROM TeamMatches tm
LEFT JOIN Leagues l
ON tm.LeagueId = l.Id
JOIN Teams t1
ON tm.HomeTeamId = t1.Id
JOIN Teams t2
ON tm.AwayTeamId = t2.Id
WHERE tm.MatchDate > '10-Apr-2015' AND l.IsSeasonal = 1
ORDER BY l.LeagueName, tm.HomeGoals DESC, tm.AwayGoals DESC