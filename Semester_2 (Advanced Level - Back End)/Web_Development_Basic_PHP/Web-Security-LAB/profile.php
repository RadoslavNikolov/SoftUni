<?php
require_once 'index.php';

if(!$app->isLogged()){
    header("Location: login.php");
}

//var_dump($_SESSION);

if(isset($_POST['edit'])){
    if (!isset($_POST['formToken']) || !$app->isFormSecured($_POST['formToken'])) {
        header("Location: logout.php");
        exit;
    }
//    else {
//        echo "token OK";
//    }



    if($_POST['password'] != $_POST['confirm'] || empty($_POST['password'])){
        header("Location: profile.php?error=1");
        exit;
    }

    $user = new \Core\User(
        $_POST['username'],
        $_POST['password'],
        $_SESSION['id']
    );

    if($app->editUser($user)){
        header("Location: profile.php?success=1");
        exit;
//        var_dump($_POST['formToken']);
    }

    header("Location: profile.php?error=1");
    exit;
}

loadTemplate("profile", $app->getUser());
