DROP DATABASE IF EXISTS `todo`;

CREATE DATABASE `todo` 
CHARACTER SET utf8 
COLLATE utf8_general_ci;

USE `todo`;

CREATE TABLE `users` (
    id INT AUTO_INCREMENT PRIMARY KEY,
    username VARCHAR(255) NOT NULL UNIQUE,
    password VARCHAR(255) NOT NULL);
    
CREATE TABLE `todos` (
    id INT AUTO_INCREMENT PRIMARY KEY,
    user_id INT NOT NULL,
    todo_item TEXT NOT NULL,
    FOREIGN KEY (user_id) REFERENCES users(id));
    