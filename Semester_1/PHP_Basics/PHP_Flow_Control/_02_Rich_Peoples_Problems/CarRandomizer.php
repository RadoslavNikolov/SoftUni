<?php
$carArr = [];
$colors = array("red", "green", "blue", "yellow", "purple");
if(!empty($_GET['inputField']) && isset($_GET['submit'])){
    $inputArr = explode(', ',$_GET['inputField']);
    foreach($inputArr as $car) {
        if(!in_array($car, $carArr)) {
            $carArr[] = $car;
        }
    }
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
        <p>"<?= $_GET['inputField'] ?>"</p>
        <form action="">
            <label for="inputField">Enter cars </label>
            <input type="text" id="inputField" name="inputField"/>
            <input type="submit" name="submit"/>
        </form>
        <table>
            <thead>
            <tr>
                <th>Car</th>
                <th>Color</th>
                <th>Count</th>
            </tr>
            </thead>
            <tbody>
            <?php foreach($carArr as $value): ?>
                <tr>
                    <td><?= $value ?></td>
                    <td><?= $colors[rand(0,count($colors)-1)] ?></td>
                    <td><?= rand(1,5) ?></td>
                </tr>
            <?php endforeach; ?>
            </tbody>
        </table>
    </div>


</body>
</html>