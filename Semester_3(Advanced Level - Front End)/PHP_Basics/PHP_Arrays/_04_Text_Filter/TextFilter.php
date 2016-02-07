<?php
if(isset($_GET['text'], $_GET['banlist'], $_GET['submit'])) {
    $inputStr = trim($_GET['text']);
    $output = $inputStr;
    $banListArr = explode(', ', $_GET['banlist']);
    foreach($banListArr as $banWord){
        $asterisks = '';
        $asterisks = str_pad($asterisks,strlen($banWord),"*",STR_PAD_RIGHT);
        $output = str_replace($banWord,$asterisks,$output);
    }
}
?>
<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Text Filter</title>
    <link rel="stylesheet" href="CSS/style.css" type="text/css"/>
</head>
<body>
<div id="wrapper">
    <form action="">
        <div>
            <label for="text"></label>
            <textarea id="text" name="text" placeholder="Enter text" required="required"></textarea>
        </div>
        <div>
            <label for="banlist"></label>
            <input type="text" id="banlist" name="banlist" placeholder="Enter Banlist" required="required"/>
        </div>
        <input type="submit" name="submit" value="Filter text"/>
    </form>
    <?php if(!empty($output)):?>
    <p><?= htmlspecialchars($output) ?></p>
    <?php endif; ?>
</div>
</body>
</html>