<?php
namespace ShoppingCart\Controllers;

use ShoppingCart\Config\UserConfig;
use ShoppingCart\Helpers\HelpFunctions;
use ShoppingCart\Helpers\Partials\PartialHeader;
use ShoppingCart\Repositories\CategoryRepository;
use ShoppingCart\Repositories\UserRepository;
use ShoppingCart\ViewModels\CategoriesViewModel;
use ShoppingCart\ViewModels\LoginInformation;
use ShoppingCart\ViewModels\ProfileInformation;
use ShoppingCart\ViewModels\RegisterInformation;
use ShoppingCart\Models\User;
use ShoppingCart\View;

class UsersController extends Controller
{


    /**
     * @return View
     * @throws \Exception
     * @Authorize
     */
    public function delete()
    {
        if(!$this->isLogged()){
            header("Location: " . HelpFunctions::url() . "users/login");
            exit;
        }

        $user_id = null;

        if(!isset($_GET['user_id'])){
            $user_id = $_SESSION['user_id'];

        } else {
            $user_id = $_GET['user_id'];

        }

        $userRepository = UserRepository::create();
        $user = $userRepository->getUserById($_SESSION['user_id']);

        if(isset($_POST['delete'])){
            if($_POST['formToken'] != $_SESSION['formToken']){
                header("Location: " . HelpFunctions::url() . "users/logout");
                exit;
            }

            if($userRepository->login($_SESSION['username'], $_POST['password'])){
                if ($userRepository->deleteUser($user_id)) {
                    header("Location: " . HelpFunctions::url() . "users/logout");
                    exit;
                }
            }else{
                $user->setError("Password is incorrect.");
            }

            $user->setError("Cannot delete profile");
        }

//        $this->render($this->escapeAll($user), "profile/delete");
        return new View("profile/delete", $this->escapeAll($user));
    }


    /**
     * @return View
     * @throws \Exception
     * @Authorize
     * @admin
     */
    public function edit(){

        if(!$this->isLogged()){
            header("Location: " . HelpFunctions::url() . "users/login");
            exit;
        }

        $userRepository = UserRepository::create();
        $user = $userRepository->getUserById($_SESSION['user_id']);


        if(isset($_POST['edit'])){

            if (isset($_POST['new-username']) && (!empty($_POST['new-username']) || !empty($_POST['confirm-username']))) {

                if($_POST['new-username'] != $_POST['confirm-username'] || empty($_POST['new-username'])){
                $user->setError("Difference between username and confirm username");
//                    $this->render($this->escapeAll($user), "profile/edit");
                    return new View("profile/edit", $this->escapeAll($user));
                }

                $user->setUsername($_POST['new-username']);
            }


            if (isset($_POST['new-email']) && (!empty($_POST['new-email']) || !empty($_POST['confirm-email']))) {

                if( empty($_POST['new-email']) || filter_var($_POST['new-email'], FILTER_VALIDATE_EMAIL) === false){
                    $user->setError("Email is not valid");
//                    $this->render($this->escapeAll($user), "profile/edit");
                    return new View("profile/edit", $this->escapeAll($user));
                }

                if($_POST['new-email'] != $_POST['confirm-email'] || empty($_POST['new-email'])){
                    $user->setError("Difference between email and confirm email");
//                    $this->render($this->escapeAll($user), "profile/edit");
                    return new View("profile/edit", $this->escapeAll($user));
                }

                $user->setEmail($_POST['new-email']);
            }

            $user->save();

//
        }

        return new View("profile/edit", $this->escapeAll($user));
    }


    /**
     * @Route("users/penka/show")
     * @Authorize
     */
    public function show(){
        if(!$this->isLogged()){
            header("Location: " . HelpFunctions::url() . "users/login");
            exit;
        }

        $userRepository = UserRepository::create();
        $user = $userRepository->getUserById($_SESSION['user_id']);

//        $this->render($this->escapeAll($user));
//        $test = new CategoriesViewModel();
        return new View($this->escapeAll($user));
    }


    /**
     * @return View
     */
    public function register(){
        $viewModel = new RegisterInformation();

        if (isset($_POST['username'], $_POST['password'], $_POST['email'], $_POST['conf-password'])) {
            try {
                if ($_POST['password'] != $_POST['conf-password']) {
                    $viewModel->error = 'diff between password and confirm password';
//                    $this->render($this->escapeAll($viewModel));
                    return new View($this->escapeAll($viewModel));
                }

                $username = $_POST['username'];
                $password = $_POST['password'];
                $email = $_POST['email'];
                $cash = null;

                if (!filter_var($email, FILTER_VALIDATE_EMAIL)) {
                    $viewModel->error = "This {$email} email is not valid";
//                    $this->render($this->escapeAll($viewModel));
                    return new View($this->escapeAll($viewModel));
                }

                $userRepository = UserRepository::create();
                if($userRepository->userExists($username)){
                    $viewModel->error = "Username: {$username} already exists";
//                    $this->render($this->escapeAll($viewModel));
                    return new View($this->escapeAll($viewModel));
                }

                if($userRepository->emailExists($email)){
                    $viewModel->error = "Email: {$email} already taken";
//                    $this->render($this->escapeAll($viewModel));
                    return new View($this->escapeAll($viewModel));
                }

                if (!empty($_POST['cash'])) {
                    $cash = $_POST['cash'];
                    if ($cash < 1 || $cash > 15000) {
                        $viewModel->error = "Initial cash must be in range [1 - 15000] not {$cash}";
//                        $this->render($this->escapeAll($viewModel));
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
                    header("Location: " . HelpFunctions::url() . "users/login");
                    exit;
                }

            } catch (\Exception $e){
                $viewModel->error = $e->getMessage();
//                $this->render($this->escapeAll($viewModel));
                return new View($this->escapeAll($viewModel));
            }
        }

//        $this->render();
        return new View();
    }


    /**
     * @return View
     * @Admin
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
//                $this->render($this->escapeAll($viewModel));
                return new View($this->escapeAll($viewModel));
            }
        }

//        $this->render($this->escapeAll($viewModel));
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
//        $_SESSION['user_model'] = $user;

        $this->updateCategoriesInJson();

        header("Location: " . HelpFunctions::url() . "users/show");
        die;
    }


    public function logout(){
        session_destroy(); // Delete all data in $_SESSION[]
                            // Remove the PHPSESSID cookie
        $params = session_get_cookie_params();
        setcookie(session_name(), '', time() - 42000,
            $params["path"], $params["domain"],
            $params["secure"], $params["httponly"]
        );
        PartialHeader::clearHeader();
        header("Location: " . HelpFunctions::url() . "users/login");
        die;
    }

}