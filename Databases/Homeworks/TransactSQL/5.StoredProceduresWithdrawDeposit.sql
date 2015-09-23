BEGIN TRAN
CREATE PROC usp_WithdrawMoney(@accountId int, @money money)
AS
BEGIN
	UPDATE Accounts
	SET  Balance -= @money
	WHERE Id = @accountId
END

EXEC usp_WithdrawMoney 1, 200

SELECT * FROM Accounts
WHERE Id = 1
COMMIT TRAN

BEGIN TRAN
CREATE PROC usp_DepositMoney(@accountId int, @money money)
AS
BEGIN
	UPDATE Accounts
	SET  Balance += @money
	WHERE Id = @accountId
END

EXEC usp_DepositMoney 1, 200

SELECT * FROM Accounts
WHERE Id = 1
COMMIT TRAN