<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Print Tags</title>
    <link rel="stylesheet" href="CSS/style.css" type="text/css"/>
</head>
<body>
    <div id="wrapper">
        <form action="PrintTags.php" method="get">
            <h3>Enter Tags:</h3>
            <input type="text" id="input" name="input"/>
            <input type="submit" value="Submit"/>
        </form>
        <?php if (isset($_GET['input']) && $_GET['input'] != ''): ?>
        <ul>
            <?php $tags = explode(', ',$_GET['input']); ?>
            <?php for($i = 0; $i < count($tags); $i++): ?>
                <li><?= htmlentities($i)?> : <?= htmlentities($tags[$i])?></li>
            <?php endfor ?>
        </ul>
        <?php endif ?>
    </div>
</body>
</html>