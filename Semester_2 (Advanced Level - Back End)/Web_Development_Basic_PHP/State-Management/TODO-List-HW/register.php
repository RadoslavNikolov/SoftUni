<?php
namespace Todo;
include_once('Db.php');

if(isset($_POST['register'])){
    if(isset($_POST['username'], $_POST['password'])){
        $username = $_POST['username'];
        $password = $_POST['password'];
        $success = Db::getInstance()->createUser($username, $password);

        if(!$success) {
            if(Db::getInstance()->containsUser($username)){
                echo "Username: {$username} already exists.";
            }else {
                echo "You were not registered successfully.";
            }
        }else{
            echo "You were successfully registered with username: {$username}";
        }
    }

//    header("Location: register.php");
}
?>


<form action="" method="POST">
    <table border="1">
        <tr>
            <td>Username</td>
            <td>
                <input type="text" placeholder="Username"
                       name="username" required="true"/>
            </td>
        </tr>
        <tr>
            <td>Password</td>
            <td>
                <input type="password" placeholder="Password"
                       name="password" required="true" />
            </td>
        </tr>
        <tr>
            <td>Action</td>
            <td>
                <input type="submit"
                       name="register"
                       value="Register!"
                    />
            </td>
        </tr>
        <tr>
            <td>Login</td>
            <td>
                <a href="login.php">[Login]</a>
            </td>
        </tr>
    </table>
</form>