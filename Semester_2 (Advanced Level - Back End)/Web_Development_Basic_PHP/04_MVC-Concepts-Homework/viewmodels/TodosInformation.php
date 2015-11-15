<?php

namespace Framework\ViewModels;

class TodosInformation
{
    public $error = false;
    public $success = false;
    private $todos = [];

    /**
     * @var \Framework\ViewModels\User
     */
    private $user = null;


    public function setUser(\Framework\ViewModels\User $user){
        $this->user = $user;
    }

    /**
     * @return \Framework\ViewModels\User
     */
    public function getUser(){
        return $this->user;
    }

    public function setTodos($todos) {
        $this->todos = $todos;
    }

    public function getTodos() {
        return $this->todos;
    }
}