<?php

namespace Framework\Models;

use Framework\Database\Database;

class Todos
{
    public function getTodos($userId){
        $db = Database::getInstance('app');

        $result = $db->prepare("SELECT id, todo_item FROM todos WHERE user_id = ?");

        $result->execute([$userId]);

        return $result->fetchAll();
    }

    public function deleteTodo($userId, $todoId){
        $db = Database::getInstance('app');

        $result = $db->prepare("Delete FROM todos WHERE user_id = ? AND id = ? ");

        $result->execute([$userId, $todoId]);

        return $result->rowCount() > 0;
    }

    public function addTodo($userId, $todoItem){
        $db = Database::getInstance('app');

        $result = $db->prepare("INSERT INTO todos(user_id, todo_item) VALUES(?, ?)");

        $result->execute([$userId, $todoItem]);

        return $result->rowCount() > 0;
    }
}