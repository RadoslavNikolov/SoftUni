<?php
namespace Todo;
include_once('Db.php');
session_start();

if (!isset($_SESSION['username'])) {
    if(isset($_POST['login'])){
        if(isset($_POST['username'], $_POST['password'])){
            $username = $_POST['username'];
            $password = $_POST['password'];
            $success = Db::getInstance()->isUserValid($username, $password);

            if($success) {
                $user = Db::getInstance()->getUser($username, $password);
                $_SESSION['username'] = $user['username'];
                $_SESSION['user_id'] = $user['id'];
            }
        }
    }
}
?>


<?php if(!isset($_SESSION['username'])): ?>
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
                           name="login"
                           value="Login!"
                        />
                </td>
            </tr>
            <tr>
                <td>Register</td>
                <td>
                    <a href="register.php">[Register]</a>
                </td>
            </tr>

        </table>
    </form>
<?php else :
    header("Location: todo.php");
    die;
endif ?>



