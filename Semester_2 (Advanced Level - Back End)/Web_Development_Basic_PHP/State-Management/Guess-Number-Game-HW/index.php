<?php
    session_start();

    if (isset($_POST['start'])) {
        $secret_num = rand(0,1000);
        if(!isset($_SESSION['username'])){
            $_SESSION['username'] = $_POST['username'];
            $_SESSION['secret_num'] = $secret_num;
            $_SESSION['turns'] = 0;
            $_SESSION['navigation'] = '';
            $_SESSION['guess_num'] = '';
        }

        header('Location: play.php'); die;
    } else if(isset($_POST['start'])) {
        echo "Invalid username!";
    }

?>

<?php if(!isset($_SESSION['username'])): ?>
<h2>Enter name and press button to start game.</h2>
<form action="" method="post">
    <input type="text" name="username" required="true"/>
    <input type="submit" name="start" value="[Start Game]"/>
</form>
<?php else: ?>
    <form action="" method="post">
        <input type="submit" name="start" value="[Start Game]"/>
    </form>
<?php  endif ?>
