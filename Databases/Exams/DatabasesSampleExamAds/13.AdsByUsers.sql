SELECT LOWER(u.Name) AS UserName, 
COUNT(a.Title) AS AdsCount, 
(CASE WHEN admins.Name IS NULL THEN 'no' ELSE 'yes' END) AS IsAdministrator FROM AspNetUsers u
LEFT JOIN Ads a
ON u.Id = a.OwnerId
LEFT JOIN 
	(SELECT u.Name FROM AspNetUsers u
	LEFT JOIN AspNetUserRoles ur
	ON u.Id = ur.UserId
	LEFT JOIN AspNetRoles r
	ON ur.RoleId = r.Id
	WHERE r.Name = 'Administrator') admins
	ON u.Name = admins.Name
GROUP BY u.Name, admins.Name
ORDER BY u.Name	