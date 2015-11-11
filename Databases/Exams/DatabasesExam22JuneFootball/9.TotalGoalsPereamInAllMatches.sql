SELECT 
	t.TeamName, 
	ISNULL(SUM(tm1.HomeGoals), 0) + ISNULL(SUM(tm2.AwayGoals), 0) AS [Total Goals] 
	FROM Teams t
LEFT JOIN TeamMatches tm1
ON t.Id = tm1.HomeTeamId
LEFT JOIN TeamMatches tm2
ON t.Id = tm2.AwayTeamId
GROUP BY t.TeamName
ORDER BY [Total Goals] DESC, t.TeamName