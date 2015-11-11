SELECT 
	u.username, 
    u.fullname, 
    ja.title AS `Job`, 
    TRUNCATE(s.from_value, 2) AS `From Value`, 
    TRUNCATE(s.to_value, 2) AS `To Value` 
FROM `users` u
JOIN `job_ad_applications` jaa
ON u.id = jaa.user_id
JOIN `job_ads` ja
ON jaa.job_ad_id = ja.id
JOIN `salaries` s
ON ja.salary_id = s.id
ORDER BY u.username, ja.title