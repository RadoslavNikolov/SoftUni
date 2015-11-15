<?php

namespace Framework\Models;

use Framework\Database\Database;

class User
{
    public function __construct(){

    }

    public function register($username, $password){
        $db = Database::getInstance('app');

        if ($this->exists($username)){
            throw new \Exception('User already registered');
        }

        $result = $db->prepare("INSERT INTO users (username, password)
          VALUES (?, ?)");

        $result->execute([
                $username,
                password_hash($password, PASSWORD_DEFAULT)
            ]
        );

        if ($result->rowCount() > 0){
            return true;
        }

        throw new \Exception('Cannot register user');
    }

    public function login($username, $password){
        $db = Database::getInstance('app');

        $result = $db->prepare("SELECT id, username, password FROM users WHERE username = ?");
        $result->execute([$username]);

        if ($result->rowCount() === 0){
            throw new \Exception("User does not exist");
        }

        $userRow = $result->fetch();

        if (password_verify($password, $userRow['password'])){
            return $userRow['id'];
        }

        throw new \Exception("Passwords does not match");
    }

    public function edit(\Framework\ViewModels\User $user){
        $db = Database::getInstance('app');

        $result = $db->prepare("UPDATE users SET password = ? WHERE id = ?");
        $result->execute([
            password_hash($user->getPass(), PASSWORD_DEFAULT),
            $user->getId()
        ]);

        return $result->rowCount() > 0;
    }

    public function getInfo($id){
        $db = Database::getInstance('app');

        $result = $db->prepare("SELECT id, username, password FROM users WHERE id = ?");
        $result->execute([$id]);

        return $result->fetch();
    }

    public function exists($username){
        $db = Database::getInstance('app');

        $result = $db->prepare("SELECT id FROM users WHERE username = ?");
        $result->execute([$username]);

        return $result->rowCount() > 0;
    }
}