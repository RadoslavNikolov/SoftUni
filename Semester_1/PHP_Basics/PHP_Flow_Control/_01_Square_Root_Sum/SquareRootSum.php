<?php $sum = 0; ?>
<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Square Root Sum</title>
    <link rel="stylesheet" href="CSS/style.css" type="text/css"/>
</head>
<body>
    <div id="wrapper">
        <table>
            <thead>
            <tr>
                <th>Number</th>
                <th>Square</th>
            </tr>
            </thead>
            <tbody>
            <?php for($i = 0; $i <= 100; $i += 2): ?>
            <tr>
                <td><?= $i ?></td>
                <?php $tempNumber = (float)number_format(sqrt($i),2,'.','');
                $sum += $tempNumber;
                ?>
                <td><?= $tempNumber ?></td>
            </tr>
            <?php endfor; ?>
            <tr>
                <td><strong>Total:</strong></td>
                <td><?= $sum ?></td>
            </tr>
            </tbody>
        </table>
    </div>
</body>
</html>