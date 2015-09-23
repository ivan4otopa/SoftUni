CREATE FUNCTION ufn_GetEmployeesAndTownsNamesThatAreComprisedByGivenSetOfLetters(@letterSet nvarchar(50))
RETURNS @EmployeesAndTownNames TABLE
	(
		EmployeesFirstNameAndTownsName nvarchar(50)
	)
AS
BEGIN
	INSERT INTO @EmployeesAndTownNames
	SELECT FirstName FROM Employees
	WHERE dbo.ufn_CheckString(@letterSet, FirstName) = 1
	UNION
	SELECT Name FROM Towns
	WHERE dbo.ufn_CheckString(@letterSet, Name) = 1
	RETURN
END

CREATE FUNCTION ufn_CheckString(@letterSet nvarchar(50), @string nvarchar(50))
RETURNS BIT
AS
BEGIN
	DECLARE @n int = 1,
		@currentCharacter nchar(1),
		@successfulLettersCount int = 0
	WHILE @n <= LEN(@string)
	BEGIN
		SET @currentCharacter = SUBSTRING(@string, @n, 1)
		IF CHARINDEX(@currentCharacter, @letterSet) > 0
		BEGIN
			SET @successfulLettersCount += 1
		END
		SET @n += 1
	END
	IF @successfulLettersCount = LEN(@string)
	BEGIN 
		RETURN 1
	END
	ELSE
	BEGIN
		RETURN 0
	END
	RETURN 0
END

SELECT DISTINCT * FROM dbo.ufn_GetEmployeesAndTownsNamesThatAreComprisedByGivenSetOfLetters('oistmiahf')