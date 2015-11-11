SELECT 
	l.LeagueName AS [League Name], 
	COUNT(DISTINCT lt.TeamId) AS Teams, 
	COUNT(DISTINCT tm.Id) AS Matches, 
	ISNULL(AVG(tm.HomeGoals + tm.AwayGoals), 0) AS [Average Goals]
	FROM Leagues l
LEFT JOIN Leagues_Teams lt
ON l.Id = lt.LeagueId
LEFT JOIN TeamMatches tm
ON l.Id = tm.LeagueId
GROUP BY l.LeagueName
ORDER BY Teams DESC, Matches DESC