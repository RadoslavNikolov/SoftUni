<?php

namespace Todo;
include_once('Db.php');
session_start();

if (isset($_SESSION['username'])) : ?>
    <?php if(!Db::getInstance()->containsUser($_SESSION['username'])):
        header('Location: login.php');
        die;
    endif; ?>
    <h1>Welcome  <?= htmlspecialchars($_SESSION['username'])?> </h1>
    <div class="logout"><a href="logout.php">[Logout]</a></div>
    <div class="addTodo"><a href="addTodo.php">[Add Todo]</a></div>
    <br>

    <?php $todos = Db::getInstance()->getTodoItems($_SESSION['user_id']);
        if(count($todos) > 0) :?>
        <div class="todos">
           <h3>List ot todos</h3>
           <ul>
                <?php foreach($todos as $todo) : ?>
                <li class="todo"><?=$todo['todo_item']?>  <a href="delete.php?todo_id=<?=$todo['id']?>">[Delete Todo]</a></li>
                <?php endforeach; ?>
           </ul>
        </div>

        <?php endif;?>

<?php else :
    header('Location: login.php');
    die;
endif; ?>
