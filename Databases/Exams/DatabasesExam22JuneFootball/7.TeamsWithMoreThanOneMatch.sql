SELECT t.TeamName AS Team, COUNT(t.Id) AS [Matches Count] FROM TeamMatches tm
JOIN Teams t
ON tm.HomeTeamId = t.Id OR tm.AwayTeamId = t.Id
GROUP BY t.TeamName
HAVING COUNT(t.Id) > 1
ORDER BY t.TeamName