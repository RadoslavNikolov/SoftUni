<?php
namespace SoftUni\Controllers;

use SoftUni\Helpers\HelpFunctions;
use SoftUni\ViewModels\LoginInformation;
use SoftUni\ViewModels\ProfileInformation;
use SoftUni\ViewModels\RegisterInformation;
use SoftUni\Models\User;
use SoftUni\View;

class UsersController extends Controller
{

    public function isLogged() {
        return isset($_SESSION['id']);
    }

    private function initLogin($user, $pass){
        $userModel = new User();
        
        $userId = $userModel->login($user, $pass);

        $_SESSION['id'] = $userId;
        $_SESSION['formToken'] = uniqid(mt_rand(), true);
        
        header("Location: profile");
    }

    public function buildings($id = null){
        if(!$this->isLogged()){
            header("Location: login");
        }

        $viewModel = new ProfileInformation();

        $userModel = new User();
        $userInfo = $userModel->getUserInfo($_SESSION['id']);

        $viewModel->username = $userInfo['username'];
        $viewModel->gold = $userInfo['gold'];
        $viewModel->food = $userInfo['food'];
        $viewModel->userId = $_SESSION['id'];
        $viewModel->buildings = $userModel->getBuildings();

        if($id != null){

            if($userModel->evolve($id, $viewModel)){
                header("Location: " . HelpFunctions::generateUrl() . "users/buildings");
                exit;
            }

        }


        return new View($viewModel);
    }

    public function profile(){
        if(!$this->isLogged()){
            header("Location: login");
        }
        $viewModel = new ProfileInformation();

        $userModel = new User();
        $userInfo = $userModel->getUserInfo($_SESSION['id']);

        $viewModel->username = $userInfo['username'];
        $viewModel->gold = $userInfo['gold'];
        $viewModel->food = $userInfo['food'];
        $viewModel->userId = $_SESSION['id'];

        if(isset($_POST['edit'])){

            if($_POST['password'] != $_POST['confirm'] || empty($_POST['password'])){
                $viewModel->error = "Difference between password and confirm password";
                return new View($viewModel);
            }

            $success = $this->editUser($viewModel);

            if($success){
                $viewModel->success = "Successfully changed password";

            } else {
                $viewModel->error = "The password was not changed successfully";
            }

        }

        return new View($viewModel);
    }
    
    public function register(){
        $viewModel = new RegisterInformation();

        if (isset($_POST['username'], $_POST['password'])) {
            try {
                $user = $_POST['username'];
                $pass = $_POST['password'];

                $userModel = new User();
                $userModel->register($user, $pass);
            } catch (\Exception $e){
                $viewModel->error = $e->getMessage();
                return new View($viewModel);
            }
        }

        return new View();
    }


    public function login(){
        $viewModel = new LoginInformation();

        if (isset($_POST['username'], $_POST['password'])) {
            try {
                $user = $_POST['username'];
                $pass = $_POST['password'];

                $this->initLogin($user, $pass);
            } catch (\Exception $e){
                $viewModel->error = $e->getMessage();
                return new View($viewModel);
            }
        }

        return new View($viewModel);
    }

    public function editUser($viewModel){
        if(!$this->isLogged()){
            header("Location: login");
        }

        $userModel = new User();
        $success = $userModel->editUser($viewModel->userId, $viewModel->username,  $_POST['password']);

        return $success;
    }

    public function logout(){
        if(!$this->isLogged()){
            header("Location: login");
        }

        session_destroy(); // Delete all data in $_SESSION[]
                            // Remove the PHPSESSID cookie
        $params = session_get_cookie_params();
        setcookie(session_name(), '', time() - 42000,
            $params["path"], $params["domain"],
            $params["secure"], $params["httponly"]
        );
        header("Location: " . HelpFunctions::generateUrl() . "users/login");
        die;
    }


}