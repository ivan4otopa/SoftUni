CREATE VIEW AllQuestions AS
SELECT 
	u.Id AS [UId], 
	u.Username, 
	u.FirstName, 
	u.LastName, 
	u.Email, 
	u.PhoneNumber, 
	u.RegistrationDate, 
	q.Id AS [QId],
	q.Title,
	q.Content,
	q.CategoryId,
	q.UserId,
	q.CreatedOn
FROM Users u
RIGHT JOIN Questions q
ON u.Id = q.UserId