<?php
require_once 'index.php';

if($app->isLogged()){
    header("Location: profile.php");
}

if(isset($_POST['username'], $_POST['password'])){
    try {
        $user = $_POST['username'];
        $pass = $_POST['password'];

        if ($app->register($user, $pass)) {
            header("Location: login.php");
        }

    } catch (Exception $e) {
        echo $e->getMessage();
    }

}

loadTemplate("register");