SELECT 
	LOWER(t1.TeamName + REVERSE(LEFT(t2.TeamName, LEN(t2.TeamName) - 1))) AS Mix 
	FROM Teams t1, Teams t2
WHERE RIGHT(t1.TeamName, 1) = RIGHT(t2.TeamName, 1)
ORDER BY Mix