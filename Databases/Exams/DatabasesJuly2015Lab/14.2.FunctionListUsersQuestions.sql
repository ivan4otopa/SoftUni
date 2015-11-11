ALTER FUNCTION fn_ListUsersQuestions()
RETURNS @usersQuestions TABLE
(
	UserName nvarchar(MAX),
	Questions nvarchar(MAX)
)
AS
BEGIN
	DECLARE UsersCursor CURSOR FOR
	SELECT Id, Username FROM Users
	ORDER BY Username
	OPEN UsersCursor
	DECLARE @userId int
	DECLARE @username nvarchar(MAX)
	FETCH NEXT FROM UsersCursor INTO @userId, @username
	WHILE @@FETCH_STATUS = 0
	BEGIN
		DECLARE @userQuestions nvarchar(MAX) = NULL
		SELECT @userQuestions = CASE
			WHEN @userQuestions IS NULL THEN Title
			ELSE @userQuestions + ', ' + Title
		END
		FROM AllQuestions
		WHERE UserId = @userId
		ORDER BY Title DESC
		INSERT INTO @usersQuestions
		VALUES(@username, @userQuestions)
		FETCH NEXT FROM UsersCursor INTO @userId, @username
	END
	CLOSE UsersCursor
	DEALLOCATE UsersCursor
	RETURN
END

SELECT * FROM dbo.fn_ListUsersQuestions()