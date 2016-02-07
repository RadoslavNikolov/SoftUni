<?php
$name = 'Gosho';
$mobile = '0882-321-423';
$age = 24;
$address = 'Hadji Dimitar';
?>

<!DOCTYPE html>
<html>
<head lang="en">
    <meta charset="UTF-8">
    <title>Information Table</title>
    <link rel="stylesheet" href="style.css" type="text/css"/>
</head>
<body>
    <div id="wrapper">
        <table>
            <tr>
                <td class="title">Name</td>
                <td class="info"><?= $name ?></td>
            </tr>
            <tr>
                <td class="title">Phone number</td>
                <td class="info"><?= $mobile ?></td>
            </tr>
            <tr>
                <td class="title">Age</td>
                <td class="info"><?= $age ?></td>
            </tr>
            <tr>
                <td class="title">Address</td>
                <td class="info"><?= $address ?></td>
            </tr>
        </table>
    </div>
</body>
</html>