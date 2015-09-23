SELECT e.FirstName, e.LastName, e.AddressID, a.AddressID, a.AddressText FROM Employees e, Addresses a
WHERE e.AddressID = a.AddressID