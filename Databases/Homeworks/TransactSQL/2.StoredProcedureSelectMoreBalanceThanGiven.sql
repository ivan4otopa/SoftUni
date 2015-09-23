CREATE PROCEDURE usp_ReturnPersonsWithHigherBalanceThanGiven @Balance numeric(18, 2)
AS
BEGIN
	SELECT p.FirstName, p.LastName, p.SSN, a.Balance FROM Persons p
	JOIN Accounts a
	ON a.PersonId = p.Id AND a.Balance > @Balance
END

EXEC usp_ReturnPersonsWithHigherBalanceThanGiven 10000