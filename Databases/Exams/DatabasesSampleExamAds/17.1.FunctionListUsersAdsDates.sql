CREATE FUNCTION ufn_ListUsersAdsDates()
RETURNS @usersAdsDates TABLE
(
	UserName nvarchar(15),
	AdDates nvarchar(MAX) 
)
AS
BEGIN 
	DECLARE UsersCursor CURSOR FOR
	SELECT UserName FROM AspNetUsers
	ORDER BY UserName DESC
	OPEN UsersCursor
	DECLARE @username nvarchar(15)
	FETCH NEXT FROM UsersCursor INTO @username
	WHILE @@FETCH_STATUS = 0
	BEGIN 
		DECLARE @adsDates nvarchar(MAX) = NULL
		SELECT @adsDates = CASE
			WHEN @adsDates IS NULL THEN CONVERT(nvarchar(MAX), Date, 112)
			ELSE @adsDates + '; ' + CONVERT(nvarchar(MAX), Date, 112) 
		END
		FROM AllAds
		WHERE Author = @username
		ORDER BY Date

		INSERT INTO @usersAdsDates
		VALUES(@username, @adsDates)

		FETCH NEXT FROM UsersCursor INTO @username
	END
	CLOSE UsersCursor
	DEALLOCATE UsersCursor
	RETURN
END

SELECT * FROM ufn_ListUsersAdsDates()