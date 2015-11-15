<?php
include('auth_header.php');
var_dump($_SESSION['secret_num']);
printStatistic();

$isFinished = false;

if(isset($_POST['guess_btn'])){
    $guess_num = ctype_digit($_POST['guess_num']) ? intval($_POST['guess_num']) : null;


if ($guess_num < 1 || $guess_num > 1000 || $guess_num == null) {
    echo "Invalid number";
}

    $_SESSION['turns']++;
    $_SESSION['guess_num'] = $guess_num;

    switch(checkNum($guess_num)){
        case 1 : $_SESSION['navigation'] = 'DOWN   &#8681'; break;
        case -1: $_SESSION['navigation'] = 'UP   &#8679'; break;
        case 0 : $isFinished = true; break;
    }

    printStatistic();

    if($isFinished){
        echo "Congratulations, " . htmlspecialchars($_SESSION['username']) . "<br>";
        echo "The secret number is: " . $guess_num . "<br>";
        resetSession();
        echo '<br><a href="index.php">[Play Again]</a><br><br>';
        die;
    }

    header("Location: play.php");
}

function printStatistic(){
    if(isset($_SESSION)){
        echo $_SESSION['navigation'] . "<br>";
        echo "Entered number: " . htmlspecialchars($_SESSION['guess_num']) . "<br>";
        echo "Turns: " . htmlspecialchars($_SESSION['turns']) . "<br>";
    }
}

function checkNum($num1){
    $num2 = $_SESSION['secret_num'];
    return ($num1-$num2) ? ($num1-$num2)/abs($num1-$num2) : 0;
}

function resetSession(){
    if(isset($_SESSION)){
        $_SESSION['secret_num'] = rand(0,1000);
        $_SESSION['turns'] = 0;
        $_SESSION['navigation'] = "";
        $_SESSION['guess_num'] = "";
    }
}

//    if(!isset($_SESSION['secret_num'])){
//        $ivs = mcrypt_get_iv_size(MCRYPT_DES,MCRYPT_MODE_CBC);
//        $iv = mcrypt_create_iv($ivs,MCRYPT_RAND);
//        $key = rand(10000000,100000000); //not sure what best way to generate this is!
//        $_SESSION['key'] = $key;
//
//        $secret_num = rand(0,100);
//        var_dump($secret_num);
//        $crypt_num = mcrypt_encrypt(MCRYPT_DES, $key, $secret_num, MCRYPT_MODE_CBC, $iv);
//        $_SESSION['secret_num'] = $crypt_num;
//    }
//
//    if(isset($_POST['guess_btn'])){
//        var_dump($_POST['guess_num']);
//        $ivs = mcrypt_get_iv_size(MCRYPT_DES,MCRYPT_MODE_CBC);
//        $iv = mcrypt_create_iv($ivs,MCRYPT_RAND);
//        $num =  mcrypt_decrypt (MCRYPT_DES, $_SESSION['key'], $_SESSION['secret_num'], MCRYPT_MODE_CBC, $iv);
//        var_dump($num);
//    }

?>

<form action="" method="post">
    <input type="number" required="true" name="guess_num" min="0" max="1000"/>
    <input type="submit" name="guess_btn" value="Guess"/>
</form>
