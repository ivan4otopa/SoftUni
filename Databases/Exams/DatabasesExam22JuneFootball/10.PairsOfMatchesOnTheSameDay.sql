SELECT 
	tm1.MatchDate AS [First Date], 
	tm2.MatchDate AS [Second Date] 
	FROM TeamMatches tm1, TeamMatches tm2
WHERE DAY(tm1.MatchDate) = DAY(tm2.MatchDate) AND tm1.Id <> tm2.Id AND tm1.MatchDate < tm2.MatchDate
ORDER BY tm1.MatchDate DESC, tm2.MatchDate DESC