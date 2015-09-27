<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Form Exercise</title>
</head>
<body>
<form action="forms.php" method="post">
    Username: <input type="text" name="username">
    Password: <input type="password" name="password">

    <select name="sex[]" id="sex">
        <option value="male">Male</option>
        <option value="female">Female</option>
        <option value="other">Other</option>
    </select>

    <input type="submit" name="submit">
</form>
</body>
</html>

<?php
echo "before SET<br>";
if (isset($_POST['submit'])) {
    echo "SET<br>";

    var_dump($_POST);
    $username = htmlentities($_POST['username']);
    $password = htmlentities($_POST['password']);
    $sex = $_POST['sex'];

    echo "Hallo, {$username}!<br>";
    echo "You password is: {$password}!<br>";
    echo "Sex: {$sex[0]}<br>";
}