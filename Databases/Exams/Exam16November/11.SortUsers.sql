SELECT Username, FullName FROM Users
ORDER BY LEN(Username) + LEN(FullName), BirthDate DESC