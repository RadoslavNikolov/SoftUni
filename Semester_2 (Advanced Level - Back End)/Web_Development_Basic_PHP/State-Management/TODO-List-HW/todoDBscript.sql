DROP DATABASE IF EXISTS `todolist`;
CREATE DATABASE IF NOT EXISTS `todolist`;
USE `todolist`;


-- Dumping structure for table uniwars.players
DROP TABLE IF EXISTS `users`;
CREATE TABLE IF NOT EXISTS `users` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(250) NOT NULL DEFAULT '0',
  `passwordHash` varchar(250) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  UNIQUE KEY `username` (`username`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8;


-- Dumping structure for table uniwars.player_stages
DROP TABLE IF EXISTS `todos`;
CREATE TABLE IF NOT EXISTS `todos` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` int(11) NOT NULL DEFAULT '0',
  `todo_item` varchar(250) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `FK__user_id` (`user_id`),
  CONSTRAINT `FK__user_id` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;