SELECT 
	t1.TeamName AS [Home Team], 
	t2.TeamName AS [Away Team], 
	tm.MatchDate AS [Match Date] 
	FROM TeamMatches tm
JOIN Teams t1
ON tm.HomeTeamId = t1.Id
JOIN Teams t2
ON tm.AwayTeamId = t2.Id
UNION
SELECT t1.TeamName, t2.TeamName, fm.MatchDate AS [Match Date] FROM FriendlyMatches fm
JOIN Teams t1
ON fm.HomeTeamId = t1.Id
JOIN Teams t2
ON fm.AwayTeamId = t2.Id
ORDER BY [Match Date] DESC