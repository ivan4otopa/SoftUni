INSERT INTO UserGameItems(ItemId, UserGameId)
VALUES
	(
		(SELECT Id FROM Items WHERE Name = 'Blackguard'),
		(SELECT Id FROM UsersGames WHERE
			UserId = (SELECT Id FROM Users WHERE Username = 'Alex')
			AND GameId = (SELECT Id FROM Games WHERE Name = 'Edinburgh')
		)
	),
	(
		(SELECT Id FROM Items WHERE Name = 'Bottomless Potion of Amplification'),
		(SELECT Id FROM UsersGames WHERE
			UserId = (SELECT Id FROM Users WHERE Username = 'Alex')
			AND GameId = (SELECT Id FROM Games WHERE Name = 'Edinburgh')
		)
	),
	(
		(SELECT Id FROM Items WHERE Name = 'Eye of Etlich (Diablo III)'),
		(SELECT Id FROM UsersGames WHERE
			UserId = (SELECT Id FROM Users WHERE Username = 'Alex')
			AND GameId = (SELECT Id FROM Games WHERE Name = 'Edinburgh')
		)
	),
	(
		(SELECT Id FROM Items WHERE Name = 'Gem of Efficacious Toxin'),
		(SELECT Id FROM UsersGames WHERE
			UserId = (SELECT Id FROM Users WHERE Username = 'Alex')
			AND GameId = (SELECT Id FROM Games WHERE Name = 'Edinburgh')
		)
	),
	(
		(SELECT Id FROM Items WHERE Name = 'Golden Gorget of Leoric'),
		(SELECT Id FROM UsersGames WHERE
			UserId = (SELECT Id FROM Users WHERE Username = 'Alex')
			AND GameId = (SELECT Id FROM Games WHERE Name = 'Edinburgh')
		)
	),
	(
		(SELECT Id FROM Items WHERE Name = 'Hellfire Amulet'),
		(SELECT Id FROM UsersGames WHERE
			UserId = (SELECT Id FROM Users WHERE Username = 'Alex')
			AND GameId = (SELECT Id FROM Games WHERE Name = 'Edinburgh')
		)
	)

UPDATE UsersGames
SET Cash -= (SELECT Price FROM Items WHERE Name = 'Blackguard')
WHERE Id = (SELECT Id FROM UsersGames WHERE
				UserId = (SELECT Id FROM Users WHERE Username = 'Alex')
				AND GameId = (SELECT Id FROM Games WHERE Name = 'Edinburgh')
			)
UPDATE UsersGames
SET Cash -= (SELECT Price FROM Items WHERE Name = 'Bottomless Potion of Amplification')
WHERE Id = (SELECT Id FROM UsersGames WHERE
				UserId = (SELECT Id FROM Users WHERE Username = 'Alex')
				AND GameId = (SELECT Id FROM Games WHERE Name = 'Edinburgh')
			)
UPDATE UsersGames
SET Cash -= (SELECT Price FROM Items WHERE Name = 'Eye of Etlich (Diablo III)')
WHERE Id = (SELECT Id FROM UsersGames WHERE
				UserId = (SELECT Id FROM Users WHERE Username = 'Alex')
				AND GameId = (SELECT Id FROM Games WHERE Name = 'Edinburgh')
			)
UPDATE UsersGames
SET Cash -= (SELECT Price FROM Items WHERE Name = 'Gem of Efficacious Toxin')
WHERE Id = (SELECT Id FROM UsersGames WHERE
				UserId = (SELECT Id FROM Users WHERE Username = 'Alex')
				AND GameId = (SELECT Id FROM Games WHERE Name = 'Edinburgh')
			)
UPDATE UsersGames
SET Cash -= (SELECT Price FROM Items WHERE Name = 'Golden Gorget of Leoric')
WHERE Id = (SELECT Id FROM UsersGames WHERE
				UserId = (SELECT Id FROM Users WHERE Username = 'Alex')
				AND GameId = (SELECT Id FROM Games WHERE Name = 'Edinburgh')
			)
UPDATE UsersGames
SET Cash -= (SELECT Price FROM Items WHERE Name = 'Hellfire Amulet')
WHERE Id = (SELECT Id FROM UsersGames WHERE
				UserId = (SELECT Id FROM Users WHERE Username = 'Alex')
				AND GameId = (SELECT Id FROM Games WHERE Name = 'Edinburgh')
			)

SELECT u.Username, g.Name, CONVERT(NUMERIC(9,2),REPLACE(ug.Cash, ',', '.')) AS Cash, i.Name AS [Item Name] FROM Users u
JOIN UsersGames ug
ON u.Id = ug.UserId
JOIN Games g
ON ug.GameId = g.Id
JOIN UserGameItems ugi
ON ug.Id = ugi.UserGameId
JOIN Items i
ON ugi.ItemId = i.Id
WHERE g.Name = 'Edinburgh'
ORDER BY i.Name