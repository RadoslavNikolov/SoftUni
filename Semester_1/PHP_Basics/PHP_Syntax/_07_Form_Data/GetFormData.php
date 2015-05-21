<!DOCTYPE html>
<html>
<head lang="en">
    <meta charset="UTF-8">
    <title>Sum Two Numbers</title>
    <link rel="stylesheet" href="style.css" type="text/css"/>
</head>
<body>
<div id="wrapper">
    <form action="GetFormData.php" method="get">
        <input type="text" name="name" placeholder="Name..." required="true"/><br>
        <input type="number" name="age" placeholder="Age..." required="true"/><br>
        <input type="radio" id="male" name="gender" value="male" required="true"/>
        <label for="male">Male</label>
        <input type="radio" id="female" name="gender" value="female"/>
        <label for="female">Female</label>
        <input type="submit"/>
    </form>

    <?php if(isset($_GET['name'],$_GET['age'], $_GET['gender'])):
        $name = htmlentities($_GET["name"]);
        $age = htmlentities($_GET["age"]);
        $gender = htmlentities($_GET["gender"]);
        $output = "My name is $name. I am $age years old. I am $gender.";
        ?>
        <p><?= $output ?></p>
    <?php endif ?>
</div>
</body>
</html>