<?php
namespace Todo;
include_once('Db.php');
session_start();

if (isset($_GET, $_SESSION)) {
    $todo_id = $_GET['todo_id'];
    $todo = Db::getInstance()->getTodo($todo_id);
    if (isset($_POST['delete'], $_POST['password'])) {
        if (Db::getInstance()->isUserValid($_SESSION['username'], $_POST['password'])) {
            $success = Db::getInstance()->deleteTodoItem($todo_id);

            if ($success) {
                header('Location: todo.php');
                die;
            }
        } else{
            echo "Invalid password!";
        }
    }
} else {
    header('Location: login.php');
    die;
}
?>

<h3><i><?=$_SESSION['username']?></i>, please enter password to confirm deletion!</h3>
<h4>Deleting Todo item with id: <?=$todo_id?> and text: <i><?=$todo['todo_item']?></i></h4>
<form action="" method="POST">
    <table border="1">
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
                       name="delete"
                       value="Delete!"
                    />
            </td>
        </tr>
        <tr>
            <td>Back</td>
            <td>
                <a href="todo.php">[Back]</a>
            </td>
        </tr>

    </table>
</form>
<div class="logout"><a href="logout.php">[Logout]</a></div>
