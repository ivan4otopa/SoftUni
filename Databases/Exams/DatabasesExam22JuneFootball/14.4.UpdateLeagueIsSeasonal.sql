UPDATE Leagues
SET IsSeasonal = 1
WHERE LeagueName IN
	(SELECT l.LeagueName FROM Leagues l
	JOIN TeamMatches tm
	ON l.Id = tm.LeagueId
	GROUP BY l.LeagueName
	HAVING COUNT(tm.LeagueId) >= 1)