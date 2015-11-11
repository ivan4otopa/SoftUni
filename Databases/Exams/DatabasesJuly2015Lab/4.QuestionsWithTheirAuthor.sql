SELECT q.Title AS [Question Title], u.Username AS Author FROM Users u
JOIN Questions q
ON u.Id = q.UserId
ORDER BY q.Title