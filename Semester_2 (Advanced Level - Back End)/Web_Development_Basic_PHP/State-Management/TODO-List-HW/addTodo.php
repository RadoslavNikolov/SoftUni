<?php
namespace Todo;
include_once('Db.php');
session_start();

if(isset($_POST['addTodo'], $_POST['todo'])){
    $user_id = $_SESSION['user_id'];
    $todo_text = $_POST['todo'];

    if (!Db::getInstance()->containsTodo($user_id, $todo_text)) {
        $success = Db::getInstance()->addTodoItem($user_id,$todo_text);

        if ($success) {
            header('Location: todo.php');
            die;
        }
    }

    header("Location: addTodo.php"); die;
}


if (isset($_SESSION['username'])) : ?>
    <?php if(!Db::getInstance()->containsUser($_SESSION['username'])):
        header('Location: login.php');
        die;
    endif; ?>
    <h1>Welcome  <?= htmlspecialchars($_SESSION['username'])?> </h1>
    <div class="logout"><a href="logout.php">[Logout]</a></div>
    <div class="todos"><a href="todo.php">[List Todos]</a></div>
    <br>

    <div class="addTodo">
        <form action="" method="POST">
            <table border="1">
                <tr>
                    <td>Todo info</td>
                    <td>
                        <textarea name="todo" id="todo" cols="30" rows="10" placeholder="todo info" required="true"></textarea>
                    </td>
                </tr>
                <tr>
                    <td>Add Todo</td>
                    <td>
                        <input type="submit"
                               name="addTodo"
                               value="Add!"
                            />
                    </td>
                </tr>
            </table>
        </form>
    </div>

<?php else :
    header('Location: login.php');
    die;
endif; ?>