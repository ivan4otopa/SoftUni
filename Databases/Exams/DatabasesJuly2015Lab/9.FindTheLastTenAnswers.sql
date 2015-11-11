SELECT TOP 10 a.Content AS Answer, a.CreatedOn, u.Username FROM Answers a
JOIN Users u 
ON a.UserId = u.Id
ORDER BY a.CreatedOn DESC