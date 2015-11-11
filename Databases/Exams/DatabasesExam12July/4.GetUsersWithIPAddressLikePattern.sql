SELECT Username, IpAddress AS [IP Address] FROM Users
WHERE CAST(IpAddress AS nvarchar(MAX)) LIKE '[0-9][0-9][0-9].1%.%[0-9][0-9][0-9]'
ORDER BY Username