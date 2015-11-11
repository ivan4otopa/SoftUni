CREATE FUNCTION fn_MountainsPeaksJSON()
RETURNS nvarchar(MAX)
AS 
BEGIN 
	DECLARE @json nvarchar(MAX) = '{"mountains":['
	DECLARE MountainsCursor CURSOR FOR
	SELECT Id, MountainRange FROM Mountains
	OPEN MountainsCursor
	DECLARE @mountainName nvarchar(MAX)
	DECLARE @mountainId int
	FETCH NEXT FROM MountainsCursor INTO @mountainId, @mountainName
	WHILE @@FETCH_STATUS = 0
	BEGIN
		SET @json += '{"name":"' + @mountainName + '","peaks":['
		DECLARE PeaksCursor CURSOR FOR
		SELECT PeakName, Elevation FROM Peaks
		WHERE MountainId = @mountainId
		OPEN PeaksCursor  
		DECLARE @peakName nvarchar(MAX)
		DECLARE @peakElevation int
		FETCH NEXT FROM PeaksCursor INTO @peakName, @peakElevation
		WHILE @@FETCH_STATUS = 0
		BEGIN
			SET @json += '{"name":"' + @peakName + '","elevation":' + 
				CAST(@peakElevation as nvarchar(MAX)) + '}'
			FETCH NEXT FROM PeaksCursor INTO @peakName, @peakElevation
			IF @@FETCH_STATUS = 0
			BEGIN
				SET @json += ','
			END
		END
		CLOSE PeaksCursor
		DEALLOCATE PeaksCursor
		SET @json += ']}'
		FETCH NEXT FROM MountainsCursor INTO @mountainId, @mountainName
		IF @@FETCH_STATUS = 0
		BEGIN
			SET @json += ','
		END
	END
	CLOSE MountainsCursor
	DEALLOCATE MountainsCursor
	SET @json += ']}'
	RETURN @json
END

SELECT dbo.fn_MountainsPeaksJSON()