<!DOCTYPE html>
<html>
<head lang="en">
    <meta charset="UTF-8">
    <title>Sum Two Numbers</title>
    <link rel="stylesheet" href="style.css" type="text/css"/>
</head>
<body>
<div id="wrapper">
    <form action="SumTwoNumbers.php" method="get">
        First Number: <input type="text" name="firstNumber" placeholder="Number 1" required="true"/><br>
        Second Number: <input type="text" name="secondNumber" placeholder="Number 2" required="true"/><br>
        <input type="hidden" name="submitted"/>
        <input type="submit"/>
    </form>

    <?php
        if(isset($_GET['firstNumber'],$_GET['secondNumber'])):
        $num1 = (float)htmlspecialchars($_GET["firstNumber"]);
        $num2 = (float)htmlspecialchars($_GET["secondNumber"]);
        $result = $num1 + $num2;
        ?>
        <p>Sum: <?php printf('%.2f',$result); ?></p>
    <?php endif ?>
</div>
</body>
</html>