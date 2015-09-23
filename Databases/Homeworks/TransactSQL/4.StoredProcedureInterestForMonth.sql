CREATE PROCEDURE usp_GiveAccountInterestPerMonth(@accountId int, @interestRate money)
AS
BEGIN
	DECLARE @balance money
	SELECT 	@balance = Balance FROM Accounts
	WHERE Id = @accountId

	DECLARE @newBalance MONEY
	SET @newBalance = dbo.ufn_CalculateInterestRate(@balance, @interestRate, 1)

	SELECT @newBalance - @balance AS InterestForMonth 
END

EXEC usp_GiveAccountInterestPerMonth 1, 3