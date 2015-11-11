CREATE DATABASE `job_portal`;

CREATE TABLE `users`
(
	`id` int NOT NULL AUTO_INCREMENT,
	`username` nvarchar(100) NOT NULL,
    `fullname` nvarchar(100),
    PRIMARY KEY (`id`)
);

CREATE TABLE `job_ads`
(
	`id` int NOT NULL AUTO_INCREMENT,
	`title` nvarchar(1000) NOT NULL,
	`description` nvarchar(2000),
    `author_id` int NOT NULL,
    `salary_id` int NOT NULL,
    CONSTRAINT `fk_jobs_ads_author` FOREIGN KEY (`author_id`) REFERENCES `users` (`id`),
    CONSTRAINT `fk_jobs_ads_salary` FOREIGN KEY (`salary_id`) REFERENCES `salaries` (`id`),
    PRIMARY KEY (`id`)
);

CREATE TABLE `job_ad_applications`
(
	`id` int NOT NULL AUTO_INCREMENT,
	`user_id` int NOT NULL,
    `job_ad_id` int NOT NULL,
    CONSTRAINT `fk_jobs_ads_user` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`),
    CONSTRAINT `fk_jobs_ads_ad` FOREIGN KEY (`job_ad_id`) REFERENCES `job_ads` (`id`),
    PRIMARY KEY (`id`)
);

CREATE TABLE `salaries`
(
	`id` int NOT NULL AUTO_INCREMENT,
	`from_value` decimal NOT NULL,
    `to_value` decimal NOT NULL,
    PRIMARY KEY (`id`)
);