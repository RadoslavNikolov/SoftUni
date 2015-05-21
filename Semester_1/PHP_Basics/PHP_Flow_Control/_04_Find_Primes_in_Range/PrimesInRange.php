<?php
if(!empty($_GET['startIndex'])&& !empty($_GET['endIndex']) && isset($_GET['submit'])){
    $startIndex = (int)$_GET['startIndex'];
    $endIndex = (int)$_GET['endIndex'];
}

function isPrime($num) {
    $isNumPrime = true;
    if($num < 2) {
        $isNumPrime = false;
    } else {
        for ($i = 2; $i <= (int)sqrt($num); $i++) {
            if($num % $i === 0) {
                $isNumPrime = false;
                break;
            }
        }
    }
    return $isNumPrime;
}
?>

<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Show Annual Expenses</title>
    <link rel="stylesheet" href="CSS/style.css" type="text/css"/>
</head>
<body>
<div id="wrapper">
    <form action="">
        <label for="startIndex">Starting Index:</label>
        <input type="number" id="startIndex" name="startIndex"/>
        <label for="endIndex">End:</label>
        <input type="number" id="endIndex" name="endIndex"/>
        <input type="submit" name="submit"/>
    </form>
    <?php if(isset($startIndex, $endIndex)):
        for($i = $startIndex; $i <= $endIndex; $i++):
            if( isPrime($i)): ?>
                <span><strong><?= $i ?>, </strong></span>
            <?php else: ?>
                <span><?= $i ?>, </span>
            <?php endif; ?>
        <?php endfor; endif; ?>
</div>
</body>
</html>