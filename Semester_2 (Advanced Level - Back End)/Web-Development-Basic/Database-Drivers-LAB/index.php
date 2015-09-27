<?php
require_once 'translations.php';
?>

<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Translation Class Exercise</title>
</head>
<header>
    <a href="?lang=bg">BG</a> | <a href="?lang=en">EN</a>
    <h1>
        <?= Localization::__('greeting_header_hello'); ?>
<!--        --><?php //var_dump(Localization::getLang())?>
    </h1>
</header>
<body>
    <div id="content">
        <p>
            <?= Localization::__('welcome_message'); ?>
        </p>
    </div>
    <a href="admin.php">Edit</a>
</body>
</html>

