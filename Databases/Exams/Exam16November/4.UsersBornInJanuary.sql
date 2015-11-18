SELECT u.Username, u.FullName, u.BirthDate, CASE
	WHEN p.Title IS NULL THEN 'No photos' 
	ELSE p.Title END AS Photo
FROM Users u
LEFT JOIN Photographs p
ON u.Id = p.UserId
WHERE DATEPART(MONTH, u.BirthDate) = 1
ORDER BY u.FullName