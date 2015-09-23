SELECT e.FirstName, e.LastName, e.AddressID, a.AddressID, a.AddressText FROM Employees e
INNER JOIN Addresses a ON e.AddressID = a.AddressID
