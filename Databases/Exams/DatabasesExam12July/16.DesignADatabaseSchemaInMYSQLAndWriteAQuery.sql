CREATE DATABASE `job_portal`;

CREATE TABLE `users`
(
	`id` INT AUTO_INCREMENT PRIMARY KEY,
    `username` NVARCHAR(300) NOT NULL,
    `fullname` NVARCHAR(300)
);

CREATE TABLE `salaries`
(
	`id` INT AUTO_INCREMENT PRIMARY KEY,
	`from_value` DECIMAL(11, 2) NOT NULL,
    `to_value` DECIMAL(11, 2) NOT NULL
);

CREATE TABLE `job_ads`
(
	`id` INT AUTO_INCREMENT PRIMARY KEY,
    `title` NVARCHAR(300) NOT NULL,
    `description` NVARCHAR(300),
    `author_id` INT NOT NULL,
    `salary_id` INT NOT NULL,
    CONSTRAINT `fk_job_ads_author` FOREIGN KEY(`author_id`)  REFERENCES `users`(`id`),
    CONSTRAINT `fk_job_ads_salary` FOREIGN KEY(`salary_id`)  REFERENCES `salaries`(`id`)
);

CREATE TABLE `job_ad_applications`
(
	`id` INT AUTO_INCREMENT PRIMARY KEY,
    `user_id` INT NOT NULL,
    `job_ad_id` INT NOT NULL,
    CONSTRAINT `fk_job_applications_user` FOREIGN KEY(`user_id`)  REFERENCES `users`(`id`),
    CONSTRAINT `fk_job_applications_job_ad` FOREIGN KEY(`job_ad_id`)  REFERENCES `job_ads`(`id`)
);

insert into users (username, fullname)
values ('pesho', 'Peter Pan'),
('gosho', 'Georgi Manchev'),
('minka', 'Minka Dryzdeva'),
('jivka', 'Jivka Goranova'),
('gago', 'Georgi Georgiev'),
('dokata', 'Yordan Malov'),
('glavata', 'Galin Glavomanov'),
('petrohana', 'Peter Petromanov'),
('jubata', 'Jivko Jurandov'),
('dodo', 'Donko Drozev'),
('bobo', 'Bay Boris');

insert into salaries (from_value, to_value)
values (300, 500),
(400, 600),
(550, 700),
(600, 800),
(1000, 1200),
(1300, 1500),
(1500, 2000),
(2000, 3000);

insert into job_ads (title, description, author_id, salary_id)
values ('PHP Developer', NULL, (select id from users where username = 'gosho'), (select id from salaries where from_value = 300)),
('Java Developer', 'looking to hire Junior Java Developer to join a team responsible for the development and maintenance of the payment infrastructure systems', (select id from users where username = 'jivka'), (select id from salaries where from_value = 1000)),
('.NET Developer', 'net developers who are eager to develop highly innovative web and mobile products with latest versions of Microsoft .NET, ASP.NET, Web services, SQL Server and related applications.', (select id from users where username = 'dokata'), (select id from salaries where from_value = 1300)),
('JavaScript Developer', 'Excellent knowledge in JavaScript', (select id from users where username = 'minka'), (select id from salaries where from_value = 1500)),
('C++ Developer', NULL, (select id from users where username = 'bobo'), (select id from salaries where from_value = 2000)),
('Game Developer', NULL, (select id from users where username = 'jubata'), (select id from salaries where from_value = 600)),
('Unity Developer', NULL, (select id from users where username = 'petrohana'), (select id from salaries where from_value = 550));

insert into job_ad_applications(job_ad_id, user_id)
values 
	((select id from job_ads where title = 'C++ Developer'), (select id from users where username = 'gosho')),
	((select id from job_ads where title = 'Game Developer'), (select id from users where username = 'gosho')),
	((select id from job_ads where title = 'Java Developer'), (select id from users where username = 'gosho')),
	((select id from job_ads where title = '.NET Developer'), (select id from users where username = 'minka')),
	((select id from job_ads where title = 'JavaScript Developer'), (select id from users where username = 'minka')),
	((select id from job_ads where title = 'Unity Developer'), (select id from users where username = 'petrohana')),
	((select id from job_ads where title = '.NET Developer'), (select id from users where username = 'jivka')),
	((select id from job_ads where title = 'Java Developer'), (select id from users where username = 'jivka'));

SELECT u.username, u.fullname, ja.title AS `Job`, s.from_value AS `From Value`, s.to_value  AS `To Value` FROM job_ad_applications jaa
JOIN users u
ON u.id = jaa.user_id
JOIN job_ads ja
ON ja.id = jaa.job_ad_id
JOIN salaries s
ON ja.salary_id = s.id
ORDER BY u.username, ja.title