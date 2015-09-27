<?php
namespace ShoppingCart\Controllers;

use ShoppingCart\Helpers\HelpFunctions;
use ShoppingCart\Helpers\Partials\PartialHeader;
use ShoppingCart\Repositories\CategoryRepository;
use ShoppingCart\Repositories\UserRepository;
use ShoppingCart\ViewModels\LoginInformation;
use ShoppingCart\ViewModels\ProfileInformation;
use ShoppingCart\ViewModels\RegisterInformation;
use ShoppingCart\Models\User;
use ShoppingCart\View;

class UsersController extends Controller
{

    public function isLogged() {
        return isset($_SESSION['id']);
    }


//    public function buildings($id = null){
//        if(!$this->isLogged()){
//            header("Location: login");
//        }
//
//
//        $viewModel = new ProfileInformation();
//
//        $userModel = new User();
//        $userInfo = $userModel->getUserInfo($_SESSION['id']);
//
//        $viewModel->username = $userInfo['username'];
//        $viewModel->gold = $userInfo['gold'];
//        $viewModel->food = $userInfo['food'];
//        $viewModel->userId = $_SESSION['id'];
//        $viewModel->buildings = $userModel->getBuildings();
//
//        if($id != null){
//
//            if($userModel->evolve($id, $viewModel)){
//                header("Location: " . HelpFunctions::generateUrl() . "users/buildings");
//                exit;
//            }
//
//        }
//
//
//        return new View($viewModel);
//    }
//
    public function profile(){
//        if(!$this->isLogged()){
//            header("Location: " . HelpFunctions::generateUrl() . "users/login");
//            exit;
//        }

        $userRepository = UserRepository::create();
        $user = $userRepository->getUserById($_SESSION['user_id']);
        $catRepo = CategoryRepository::create();
        $_SESSION['nestedCategories'] = $catRepo->getNestedCategories();
        $_SESSION['categories'] = $catRepo->getAllCategories();





//        if(isset($_POST['edit'])){
//
//            if($_POST['password'] != $_POST['confirm'] || empty($_POST['password'])){
//                $viewModel->error = "Difference between password and confirm password";
//                return new View($viewModel);
//            }
//
//            $success = $this->editUser($viewModel);
//
//            if($success){
//                $viewModel->success = "Successfully changed password";
//
//            } else {
//                $viewModel->error = "The password was not changed successfully";
//            }
//
//        }

        return new View($this->escapeAll($user));
    }


    public function register(){
        $viewModel = new RegisterInformation();

        if (isset($_POST['username'], $_POST['password'], $_POST['email'], $_POST['conf-password'])) {
            try {
                if ($_POST['password'] != $_POST['conf-password']) {
                    $viewModel->error = 'diff between password and confirm password';
                    return new View($this->escapeAll($viewModel));
                }



                $username = $_POST['username'];
                $password = $_POST['password'];
                $email = $_POST['email'];
                $cash = null;


                if (!filter_var($email, FILTER_VALIDATE_EMAIL)) {
                    $viewModel->error = "This {$email} email is not valid";
                    return new View($this->escapeAll($viewModel));
                }

                $userRepository = UserRepository::create();
                if($userRepository->userExists($username)){
                    $viewModel->error = "Username: {$username} already exists";
                    return new View($this->escapeAll($viewModel));
                }

                if($userRepository->emailExists($email)){
                    $viewModel->error = "Email: {$email} already taken";
                    return new View($this->escapeAll($viewModel));
                }

                if (isset($_POST['cash'])) {
                    $cash = $_POST['cash'];
                    if ($cash < 1 || $cash > 15000) {
                        $viewModel->error = "Initial cash must be in range [1 - 15000] not {$cash}";
                        return new View($this->escapeAll($viewModel));
                    }
                }

                $user = new User(
                    $username,
                    $email,
                    $password,
                    $cash
                );

                if ($user->save()) {
                    header("Location: " . HelpFunctions::generateUrl() . "users/login");
                    exit;
                }

            } catch (\Exception $e){
                $viewModel->error = $e->getMessage();
                return new View($this->escapeAll($viewModel));
            }
        }

        return new View();
    }


    /**
     * @return View
     */
    public function login(){
//        var_dump($_SESSION);
        $viewModel = new LoginInformation();

        if (isset($_POST['username'], $_POST['password'])) {
            try {
                $username = $_POST['username'];
                $password = $_POST['password'];

                $this->initLogin($username, $password);
            } catch (\Exception $e){
                $viewModel->error = $e->getMessage();
                return new View($this->escapeAll($viewModel));
            }
        }

        return new View($this->escapeAll($viewModel));
    }


    /**
     * @param $username
     * @param $password
     * @throws \Exception
     */
    private function initLogin($username, $password){
        $userRepository = UserRepository::create();

        $user = $userRepository->login($username, $password);
        $userRole = $userRepository->getUserRole($user->getRoleId());

        $_SESSION['user_id'] = $user->getUserId();
        $_SESSION['username'] = $user->getUsername();
        $_SESSION['user_role'] = $userRole->getRoleName();
        $_SESSION['formToken'] = uniqid(mt_rand(), true);
        $_SESSION['user_model'] = $user;

        header("Location: " . HelpFunctions::generateUrl() . "users/profile");
        die;
    }

//    public function editUser($viewModel){
//        if(!$this->isLogged()){
//            header("Location: login");
//        }
//
//        $userModel = new User();
//        $success = $userModel->editUser($viewModel->userId, $viewModel->username,  $_POST['password']);
//
//        return $success;
//    }

    public function logout(){
        session_destroy(); // Delete all data in $_SESSION[]
                            // Remove the PHPSESSID cookie
        $params = session_get_cookie_params();
        setcookie(session_name(), '', time() - 42000,
            $params["path"], $params["domain"],
            $params["secure"], $params["httponly"]
        );
        PartialHeader::clearHeader();
        header("Location: " . HelpFunctions::generateUrl() . "users/login");
        die;
    }

}