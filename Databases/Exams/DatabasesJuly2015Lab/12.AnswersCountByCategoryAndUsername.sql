SELECT c.Name AS Category, u.Username, u.PhoneNumber, COUNT(a.Id) AS [Answers Count] FROM Categories c
JOIN Questions q
ON c.Id = q.CategoryId
JOIN Answers a
ON q.Id = a.QuestionId
JOIN Users u
ON a.UserId = u.Id AND u.PhoneNumber IS NOT NULL
GROUP BY c.Name, u.Username, u.PhoneNumber
ORDER BY [Answers Count] DESC, u.Username