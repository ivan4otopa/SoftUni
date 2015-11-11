CREATE FUNCTION fn_TeamsJSON()
RETURNS nvarchar(MAX)
AS
BEGIN
	DECLARE @json nvarchar(MAX)
	SET @json = '{"teams":['
	DECLARE TeamsCursor CURSOR FOR
	SELECT Id, TeamName FROM Teams
	WHERE CountryCode = 'BG'
	ORDER BY TeamName
	OPEN TeamsCursor
	DECLARE @teamId int
	DECLARE @teamName nvarchar(MAX)
	FETCH NEXT FROM TeamsCursor INTO @teamId, @teamName
	WHILE @@FETCH_STATUS = 0
	BEGIN
		SET @json += '{"name":"' + @teamName + '","matches":['
		DECLARE MatchesCursor CURSOR FOR
		SELECT t1.TeamName, tm.HomeGoals, t2.TeamName, tm.AwayGoals, tm.MatchDate FROM TeamMatches tm
		LEFT JOIN Teams t1
		ON tm.HomeTeamId = t1.Id
		LEFT JOIN Teams t2
		ON tm.AwayTeamId = t2.Id
		WHERE @teamId = t1.Id OR @teamId = t2.Id
		ORDER BY tm.MatchDate DESC
		DECLARE @homeTeamName nvarchar(MAX)
		DECLARE @homeGoals int
		DECLARE @awayTeamName nvarchar(MAX)
		DECLARE @awayGoals int
		DECLARE @matchDate datetime
		OPEN MatchesCursor
		FETCH NEXT FROM MatchesCursor INTO 
			@homeTeamName, 
			@homeGoals, 
			@awayTeamName, 
			@awayGoals, 
			@matchDate
		WHILE @@FETCH_STATUS = 0
		BEGIN
			SET @json += '{"' + @homeTeamName +'":' + CAST(@homeGoals AS nvarchar(MAX)) + ',"' +
				+ @awayTeamName + '":' + CAST(@awayGoals AS nvarchar(MAX)) + ',"date":' +
				+ CONVERT(nvarchar(MAX), @matchDate, 103) + '}'
			FETCH NEXT FROM MatchesCursor INTO 
			@homeTeamName, 
			@homeGoals, 
			@awayTeamName, 
			@awayGoals, 
			@matchDate
			IF @@FETCH_STATUS = 0
			BEGIN
				SET @json += ','
			END
		END
		CLOSE MatchesCursor
		DEALLOCATE MatchesCursor
		SET @json += ']}'
		FETCH NEXT FROM TeamsCursor INTO @teamId, @teamName
		IF  @@FETCH_STATUS = 0
		BEGIN
			SET @json += ','
		END
	END
	CLOSE TeamsCursor
	DEALLOCATE TeamsCursor
	SET @json += ']}'
	RETURN @json
END

SELECT dbo.fn_TeamsJSON()