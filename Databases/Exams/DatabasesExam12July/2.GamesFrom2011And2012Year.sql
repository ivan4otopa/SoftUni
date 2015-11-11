SELECT TOP 50 Name AS Game, LEFT(CONVERT(nvarchar(MAX), Start, 20), 10) AS Start FROM Games
WHERE YEAR(Start) IN (2011, 2012)
ORDER BY Start, Name