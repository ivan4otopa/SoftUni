SELECT 
	u.Username,
	g.Name AS Game,
	c.Name AS [Character],
	SUM(s.Strength) AS Strength,
	SUM(s.Defence) AS Defence,
	SUM(s.Speed) AS Speed,
	SUM(s.Mind) AS Mind,
	SUM(s.Luck) AS Luck
FROM Users u
JOIN UsersGames ug
ON u.Id = ug.UserId
JOIN Games g
ON ug.GameId = g.Id
JOIN Characters c
ON ug.CharacterId = c.Id
JOIN GameTypes gt
ON g.GameTypeId = gt.Id
JOIN UserGameItems ugi
ON ugi.UserGameId = ug.Id
JOIN Items i
ON ugi.ItemId = i.Id
JOIN [Statistics] s
ON c.StatisticId = s.Id OR i.StatisticId = s.Id OR gt.BonusStatsId = s.Id
GROUP BY u.Username, g.Name, c.Name