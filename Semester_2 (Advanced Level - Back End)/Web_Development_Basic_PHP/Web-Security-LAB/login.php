<?php
require_once 'index.php';

if($app->isLogged()){
    header("Location: profile.php");
}

if(isset($_POST['username'], $_POST['password'])){
    try {
        $user = $_POST['username'];
        $pass = $_POST['password'];
        $app->login($user, $pass);
    } catch (Exception $e) {
        echo $e->getMessage();
    }

    header("Location: profile.php");

}

loadTemplate("login");