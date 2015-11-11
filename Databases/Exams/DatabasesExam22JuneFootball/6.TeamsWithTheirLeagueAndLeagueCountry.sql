SELECT 
	t.TeamName AS [Team Name], 
	l.LeagueName AS League, 
	ISNULL(c.CountryName, 'International') AS [League Country] 
	FROM Teams t
LEFT JOIN Leagues_Teams lt
ON t.Id = lt.TeamId
JOIN Leagues l
ON lt.LeagueId = l.Id
LEFT JOIN Countries c
ON l.CountryCode = c.CountryCode
ORDER BY t.TeamName