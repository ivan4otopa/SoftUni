SELECT a.Id, a.Title, a.Date, ast.Status FROM Ads a
JOIN AdStatuses ast
ON a.StatusId = ast.Id
WHERE ast.Status <> 'Published' AND YEAR(a.Date) = (SELECT YEAR(MIN(Date)) FROM Ads) AND
	MONTH(a.Date) = (SELECT MONTH(MIN(Date)) FROM Ads)