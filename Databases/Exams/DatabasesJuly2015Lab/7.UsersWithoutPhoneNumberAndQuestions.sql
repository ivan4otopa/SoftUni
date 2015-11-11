SELECT u.Id, u.Username, u.FirstName, u.PhoneNumber, u.RegistrationDate, u.Email FROM Users u
LEFT JOIN Questions q
ON u.Id = q.UserId
WHERE u.PhoneNumber IS NULL AND q.Title IS NULL
ORDER BY u.RegistrationDate