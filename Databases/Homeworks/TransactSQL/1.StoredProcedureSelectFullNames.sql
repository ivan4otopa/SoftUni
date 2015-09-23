CREATE PROCEDURE usp_SelectFullNameOfAllPersons
AS
BEGIN
	SELECT FirstName + ' ' + LastName AS FullName FROM Persons
END

EXEC usp_SelectFullNameOfAllPersons