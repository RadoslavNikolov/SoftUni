<?php

namespace Framework\Controllers;

use Framework\View;
use Framework\ViewModels\LoginInformation;
use Framework\ViewModels\RegisterInformation;
use SoftUni\ViewModels\ProfileInformation;

class UsersController extends  BaseController
{
    public function __construct()
    {
    }

    private function initLogin($user, $pass){
        $userModel = new \Framework\Models\User();

        $userId = $userModel->login($user, $pass);
        $_SESSION['userId'] = $userId;
        $this->redirect();
    }

    public function register(){
        $viewModel = new RegisterInformation();

        if (isset($_POST['username'], $_POST['password'])){
            try {
                $user = $_POST['username'];
                $pass = $_POST['password'];

                $userModel = new \Framework\Models\User();
                $userModel->register($user, $pass);
                $this->initLogin($user, $pass);
            } catch (\Exception $e) {
                $viewModel->error = $e->getMessage();
                $this->render($viewModel);
                return true;
            }
        }

        $this->render($viewModel);
        return true;
    }


    public function login(){
        $viewModel = new LoginInformation();

        if (isset($_POST['username'], $_POST['password'])){
            if (!empty($_POST['username'] && !empty($_POST['password']))) {
                try {
                    $user = $_POST['username'];
                    $pass = $_POST['password'];
                    $this->initLogin($user, $pass);
                } catch (\Exception $e) {
                    $viewModel->error = $e->getMessage();
                    $this->render($viewModel);
                    return true;
                }
            }else {
                $viewModel->error = 'Empty username or password';
            }
        }

        $this->render($viewModel);
        return true;
    }

    public function logout(){
        if ($this->isLoggedIn()) {
            unset($_SESSION['userId']);
        }

        $this->redirect();
    }

    public function profile(){
        $this->authorize('');

        $userModel = new \Framework\Models\User();
        $viewModel = new ProfileInformation();
        $userRow = $userModel->getInfo($_SESSION['userId']);

        $user = new \Framework\ViewModels\User(
            $userRow['username'],
            $userRow['password'],
            $userRow['id']
        );
        $viewModel->setUser($user);

        if (isset($_POST['edit'])){
            try {
                if ($_POST['password'] != $_POST['confirm'] || empty($_POST['password'])){
                    throw new \Exception('Empty password or passwords does not match');
                }

                $user = new \Framework\ViewModels\User(
                    '123',
                    $_POST['password'],
                    $_SESSION['userId']
                );
                if ($userModel->edit($user)){
                    $viewModel->success = 'Edit successful';
                }
            } catch (\Exception $e) {
                $viewModel->error = $e->getMessage();
                $this->render($viewModel);
                return true;
            }
        }

        $this->render($viewModel);
        return true;
    }
}