SELECT Title, Date, dbo.ufn_CheckHasImage(ImageDataURL) AS [Has Image] FROM Ads

CREATE FUNCTION ufn_CheckHasImage(@imageDataUrl nvarchar(MAX))
RETURNS varchar(3)
AS
BEGIN
	IF @imageDataUrl IS NULL
	BEGIN
		RETURN 'no'
	END
	ELSE
	BEGIN
		RETURN 'yes'
	END
	RETURN ''
END