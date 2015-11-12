SELECT i.Name, CONVERT(NUMERIC(9,2),REPLACE(i.Price, ',', '.')) AS Price, i.MinLevel, s.Strength, s.Defence, s.Speed, s.Luck, s.Mind FROM Items i
JOIN [Statistics] s
ON i.StatisticId = s.Id
WHERE s.Mind > (SELECT AVG(Mind) FROM [Statistics]) AND s.Luck > (SELECT AVG(Luck) FROM [Statistics]) AND s.Speed > (SELECT AVG(Speed) FROM [Statistics])
ORDER BY i.Name