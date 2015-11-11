BEGIN TRAN
INSERT INTO UserGameItems(ItemId, UserGameId)
VALUES
	((SELECT Id FROM Items WHERE Name = 'Blackguard'),
	(SELECT ug.Id FROM Games g
	JOIN UsersGames ug
	ON g.Id = ug.GameId
	JOIN Users u
	ON u.Id = ug.UserId
	WHERE g.Name = 'Edinburgh' AND u.Username = 'Alex')),
	((SELECT Id FROM Items WHERE Name = 'Bottomless Potion of Amplification'),
	(SELECT ug.Id FROM Games g
	JOIN UsersGames ug
	ON g.Id = ug.GameId
	JOIN Users u
	ON u.Id = ug.UserId
	WHERE g.Name = 'Edinburgh' AND u.Username = 'Alex')),
	((SELECT Id FROM Items WHERE Name = 'Eye of Etlich (Diablo III)'),
	(SELECT ug.Id FROM Games g
	JOIN UsersGames ug
	ON g.Id = ug.GameId
	JOIN Users u
	ON u.Id = ug.UserId
	WHERE g.Name = 'Edinburgh' AND u.Username = 'Alex')),
	((SELECT Id FROM Items WHERE Name = 'Gem of Efficacious Toxin'),
	(SELECT ug.Id FROM Games g
	JOIN UsersGames ug
	ON g.Id = ug.GameId
	JOIN Users u
	ON u.Id = ug.UserId
	WHERE g.Name = 'Edinburgh' AND u.Username = 'Alex')),
	((SELECT Id FROM Items WHERE Name = 'Golden Gorget of Leoric'),
	(SELECT ug.Id FROM Games g
	JOIN UsersGames ug
	ON g.Id = ug.GameId
	JOIN Users u
	ON u.Id = ug.UserId
	WHERE g.Name = 'Edinburgh' AND u.Username = 'Alex')),
	((SELECT Id FROM Items WHERE Name = 'Hellfire Amulet'),
	(SELECT ug.Id FROM Games g
	JOIN UsersGames ug
	ON g.Id = ug.GameId
	JOIN Users u
	ON u.Id = ug.UserId
	WHERE g.Name = 'Edinburgh' AND u.Username = 'Alex'))

	UPDATE UsersGames
	SET Cash -= 
		(SELECT Price FROM Items WHERE Name = 'Blackguard')
	WHERE Id = (SELECT ug.Id FROM Games g
			JOIN UsersGames ug
			ON g.Id = ug.GameId
			JOIN Users u
			ON ug.UserId = u.Id
			WHERE u.Username = 'Alex' AND g.Name = 'Edinburgh')
	UPDATE UsersGames
	SET Cash -= 
		(SELECT Price FROM Items WHERE Name = 'Bottomless Potion of Amplification')
	WHERE Id = (SELECT ug.Id FROM Games g
			JOIN UsersGames ug
			ON g.Id = ug.GameId
			JOIN Users u
			ON ug.UserId = u.Id
			WHERE u.Username = 'Alex' AND g.Name = 'Edinburgh')
	UPDATE UsersGames
	SET Cash -= 
		(SELECT Price FROM Items WHERE Name = 'Eye of Etlich (Diablo III)')
	WHERE Id = (SELECT ug.Id FROM Games g
			JOIN UsersGames ug
			ON g.Id = ug.GameId
			JOIN Users u
			ON ug.UserId = u.Id
			WHERE u.Username = 'Alex' AND g.Name = 'Edinburgh')
	UPDATE UsersGames
	SET Cash -= 
		(SELECT Price FROM Items WHERE Name = 'Gem of Efficacious Toxin')
	WHERE Id = (SELECT ug.Id FROM Games g
			JOIN UsersGames ug
			ON g.Id = ug.GameId
			JOIN Users u
			ON ug.UserId = u.Id
			WHERE u.Username = 'Alex' AND g.Name = 'Edinburgh')
	UPDATE UsersGames
	SET Cash -= 
		(SELECT Price FROM Items WHERE Name = 'Golden Gorget of Leoric')
	WHERE Id = (SELECT ug.Id FROM Games g
			JOIN UsersGames ug
			ON g.Id = ug.GameId
			JOIN Users u
			ON ug.UserId = u.Id
			WHERE u.Username = 'Alex' AND g.Name = 'Edinburgh')
	UPDATE UsersGames
	SET Cash -= 
		(SELECT Price FROM Items WHERE Name = 'Hellfire Amulet')
	WHERE Id = (SELECT ug.Id FROM Games g
			JOIN UsersGames ug
			ON g.Id = ug.GameId
			JOIN Users u
			ON ug.UserId = u.Id
			WHERE u.Username = 'Alex' AND g.Name = 'Edinburgh')

	SELECT u.Username, g.Name, ug.Cash, i.Name AS [Item Name] FROM Users u
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
COMMIT TRAN