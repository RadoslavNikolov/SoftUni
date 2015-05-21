<?php
$colTitles = array ('Year', 'January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December', 'Total');
if(!empty($_GET['inputField']) && isset($_GET['submit'])){
    $numOfYears = (int)$_GET['inputField'];
    if($numOfYears > 100) {
        die ("Too many years");
    }
    $year = date("Y")-1;
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
            <label for="inputField">Enter number of years (<=100):</label>
            <input type="number" id="inputField" name="inputField"/>
            <input type="submit" name="submit"/>
        </form>
        <table>
            <thead>
            <tr>
                <?php foreach($colTitles as $title): ?>
                <th><?= $title ?></th>
                <?php endforeach; ?>
            </tr>
            </thead>
            <tbody>
            <?php if(isset($numOfYears)):
            for($i = 0; $i < $numOfYears; $i++):
                $sum = 0; ?>
                <tr>
                    <td><?= $year ?></td>
                    <?php for($j = 1; $j <= 12; $j++):
                        $monthExpense = rand(0,999);
                        $sum += $monthExpense; ?>
                    <td><?=  $monthExpense ?></td>
                    <?php endfor; ?>
                    <td><?= $sum ?></td>
                </tr>

            <?php $year--; endfor; endif ?>
            </tbody>
        </table>

    </div>
</body>
</html>