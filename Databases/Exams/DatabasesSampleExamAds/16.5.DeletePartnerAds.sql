DELETE FROM Ads
FROM Ads a
JOIN AspNetUsers u
ON a.OwnerId = u.Id
JOIN AspNetUserRoles ur
ON u.Id = ur.UserId
JOIN AspNetRoles r
ON ur.RoleId = r.Id
WHERE r.Name = 'Partner'