ALTER TRIGGER tr_SumChanges ON Accounts FOR UPDATE
AS
	IF UPDATE(Balance)
	BEGIN
	INSERT INTO Logs(AccountId, OldSum, NewSum)
	SELECT d.Id, d.Balance, i.Balance FROM DELETED d, INSERTED i
	END

EXEC usp_WithdrawMoney 1, 200

EXEC usp_DepositMoney 1, 200

SELECT * FROM Logs