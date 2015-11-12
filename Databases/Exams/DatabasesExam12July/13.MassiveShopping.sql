BEGIN TRAN
INSERT UserGameItems(ItemId, UserGameId)
SELECT Id, (
	SELECT Id FROM UsersGames 
	WHERE UserId = (
		SELECT Id FROM Users WHERE Username = 'Stamat') AND GameId = (
		SELECT Id FROM Games WHERE Name = 'Safflower')) 
FROM Items 
WHERE MinLevel BETWEEN 11 AND 12

UPDATE UsersGames
SET Cash -= (SELECT SUM(Price) FROM Items WHERE MinLevel BETWEEN 11 AND 12)
WHERE Id = (
	SELECT Id FROM UsersGames 
	WHERE UserId = (
		SELECT Id FROM Users WHERE Username = 'Stamat') AND GameId = (
		SELECT Id FROM Games WHERE Name = 'Safflower')) 
COMMIT TRAN
BEGIN TRAN
INSERT UserGameItems(ItemId, UserGameId)
SELECT Id, (
	SELECT Id FROM UsersGames 
	WHERE UserId = (
		SELECT Id FROM Users WHERE Username = 'Stamat') AND GameId = (
		SELECT Id FROM Games WHERE Name = 'Safflower')) 
FROM Items 
WHERE MinLevel BETWEEN 19 AND 21

UPDATE UsersGames
SET Cash -= (SELECT SUM(Price) FROM Items WHERE MinLevel BETWEEN 19 AND 21)
WHERE Id = (
	SELECT Id FROM UsersGames 
	WHERE UserId = (
		SELECT Id FROM Users WHERE Username = 'Stamat') AND GameId = (
		SELECT Id FROM Games WHERE Name = 'Safflower')) 
COMMIT TRAN
SELECT i.Name AS [Item Name] FROM Users u
JOIN UsersGames ug
ON u.Id = ug.UserId
JOIN Games g
ON ug.GameId = g.Id
JOIN UserGameItems ugi
ON ug.Id = ugi.UserGameId
JOIN Items i
ON ugi.ItemId = i.Id
WHERE g.Name = 'Safflower'
ORDER BY i.Name