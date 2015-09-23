INSERT INTO Users
SELECT 
	LEFT(FirstName, 1) + ' ' + LOWER(LastName) + CAST(EmployeeID as nvarchar(3)) AS Username,
	LEFT(FirstName, 1) + ' ' + LOWER(LastName) + 'sdsds' AS Password,
	FirstName + ' ' + LastName AS FullName,
	NULL AS LastLogin,
	2 AS GroupID
FROM Employees