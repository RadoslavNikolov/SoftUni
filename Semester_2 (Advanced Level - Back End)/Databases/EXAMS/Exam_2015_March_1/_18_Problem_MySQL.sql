DROP DATABASE IF EXISTS `trainings`;

CREATE DATABASE `trainings`
CHARACTER SET utf8 COLLATE utf8_unicode_ci;

USE `trainings`;

DROP TABLE IF EXISTS `training_centers`;

CREATE TABLE `training_centers` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  `description` text,
  `url` varchar(2000),
  PRIMARY KEY (`id`)
);

DROP TABLE IF EXISTS `courses`;

CREATE TABLE `courses` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `description` text,
  PRIMARY KEY (`id`)
);

DROP TABLE IF EXISTS `timetable`;

CREATE TABLE `timetable` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `course_id` int(11) NOT NULL,
  `training_center_id` int(11) NOT NULL,
  `start_date` date NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_courses_timetable_courses` (`course_id`),
  KEY `fk_courses_timetable_training_centers` (`training_center_id`),
  CONSTRAINT `fk_courses_timetable_courses` FOREIGN KEY (`course_id`) REFERENCES `courses` (`id`),
  CONSTRAINT `fk_courses_timetable_training_centers` FOREIGN KEY (`training_center_id`) REFERENCES `training_centers` (`id`)
);

INSERT INTO `training_centers` VALUES
(1, 'Sofia Learning', NULL, 'http://sofialearning.org'),
(2, 'Varna Innovations & Learning', 'Innovative training center, located in Varna. Provides trainings in software development and foreign languages', 'http://vil.edu'),
(3, 'Plovdiv Trainings & Inspiration', NULL, NULL),
(4, 'Sofia West Adult Trainings', 'The best training center in Lyulin', 'https://sofiawest.bg'),
(5, 'Software Trainings Ltd.', NULL, 'http://softtrain.eu'),
(6, 'Polyglot Language School', 'English, French, Spanish and Russian language courses', NULL),
(7, 'Modern Dances Academy', 'Learn how to dance!', 'http://danceacademy.bg');

INSERT INTO `courses` VALUES
(101, 'Java Basics', 'Learn more at https://softuni.bg/courses/java-basics/'),
(102, 'English for beginners', '3-month English course'),
(103, 'Salsa: First Steps', NULL),
(104, 'Avancée Français', 'French language: Level III'),
(105, 'HTML & CSS', NULL),
(106, 'Databases', 'Introductionary course in databases, SQL, MySQL, SQL Server and MongoDB'),
(107, 'C# Programming', 'Intro C# corse for beginners'),
(108, 'Tango dances', NULL),
(109, 'Spanish, Level II', 'Aprender Español');

INSERT INTO `timetable`(course_id, training_center_id, start_date) VALUES
(101, 1, '2015-01-31'), (101, 5, '2015-02-28'),
(102, 6, '2015-01-21'), (102, 4, '2015-01-07'), (102, 2, '2015-02-14'), (102, 1, '2015-03-05'), (102, 3, '2015-03-01'),
(103, 7, '2015-02-25'), (103, 3, '2015-02-19'),
(104, 5, '2015-01-07'), (104, 1, '2015-03-30'), (104, 3, '2015-04-01'),
(105, 5, '2015-01-25'), (105, 4, '2015-03-23'), (105, 3, '2015-04-17'), (105, 2, '2015-03-19'),
(106, 5, '2015-02-26'),
(107, 2, '2015-02-20'), (107, 1, '2015-01-20'), (107, 3, '2015-03-01'), 
(109, 6, '2015-01-13');

SET SQL_SAFE_UPDATES = 0;

UPDATE `timetable` t
  JOIN `courses` c ON t.course_id = c.id
SET t.start_date = DATE_SUB(t.start_date, INTERVAL 7 DAY)
WHERE c.name REGEXP '^[a-j]{1,5}.*s$';

SELECT 
  tc.name AS `traning center`,
  t.start_date AS `start date`,
  c.name AS `course name`,
  ifnull(c.description, 'NULL') AS `more info`
FROM timetable t
  JOIN courses c ON t.course_id = c.id
  JOIN training_centers tc ON t.training_center_id = tc.id
ORDER BY t.start_date, t.id