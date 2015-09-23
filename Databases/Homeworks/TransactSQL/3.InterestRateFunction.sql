CREATE FUNCTION ufn_CalculateInterestRate(@sum money, @yearlyInterestRate money, @numberOfMonths int)
RETURNS money
AS
BEGIN
	DECLARE @monthlyInterestRate money = @yearlyInterestRate / 12
	RETURN @sum * (1 + @numberOfMonths * @monthlyInterestRate / 100)	
END

SELECT p.FirstName, p.LastName, dbo.ufn_CalculateInterestRate(a.Balance, 4, 15) AS InterestRate 
FROM Persons p
JOIN Accounts a
ON a.PersonId = p.Id