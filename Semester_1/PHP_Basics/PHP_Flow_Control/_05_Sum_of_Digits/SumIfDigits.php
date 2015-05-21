<?php
if(!empty($_GET['inputField']) && isset($_GET['submit'])){
    $inputArr = explode(', ',$_GET['inputField']);
}
?>
<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Car Randomizer</title>
    <link rel="stylesheet" href="CSS/style.css" type="text/css"/>
</head>
<body>
    <div id="wrapper">
        <form action="">
            <label for="inputField">Enter cars </label>
            <input type="text" id="inputField" name="inputField"/>
            <input type="submit" name="submit"/>
        </form>
        <table>
            <tbody>
            <?php if(isset($inputArr)):
            foreach($inputArr as $value): ?>
                <tr>
                    <td><?= $value ?></td>
                    <?php if(preg_match("/^[\\d]+$/",$value)):
                        $sum = 0;
                        for($i =0; $i < strlen($value); $i++) {
                            $sum += (int)$value[$i];
                        }?>
                        <td><?= $sum ?></td>
                    <?php else: ?>
                        <td>I cannot sum that</td>
                    <?php endif ?>
                </tr>
            <?php endforeach; endif; ?>
            </tbody>
        </table>
    </div>
</body>
</html>