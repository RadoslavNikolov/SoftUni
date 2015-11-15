<?php

namespace Framework\Controllers;

use Framework\Models\Todos;
use Framework\ViewModels\TodosInformation;

class TodosController extends BaseController
{
    public function home() {
        $viewModel = new TodosInformation();

        if (!$this->isLoggedIn()) {
            $this->render($viewModel);
            return true;
        }

        if (isset($_POST['Add'])){
            $this->add($_POST['todo-item']);
        }

        $todosModel = new Todos();
        $userModel = new \Framework\Models\User();
        $viewModel = new TodosInformation();
        $userRow = $userModel->getInfo($_SESSION['userId']);

        $user = new \Framework\ViewModels\User(
            $userRow['username'],
            $userRow['password'],
            $userRow['id']
        );
        $viewModel->setUser($user);

        $todos = $todosModel->getTodos($_SESSION['userId']);
        $viewModel->setTodos($todos);
        $this->render($viewModel);
        return true;
    }

    public function delete($id = null){
        $this->authorize('');

        if ($id != null) {
            $todosModel = new Todos();
            $todosModel->deleteTodo($_SESSION['userId'], $id);
        }

        $this->redirect('todos/');
    }

    public function add($todoItem){

        $this->authorize('');

        if (!empty($todoItem)) {
            $todosModel = new Todos();
            $todosModel->addTodo($_SESSION['userId'], $todoItem);
        }

        $this->redirect('todos/');
    }
}