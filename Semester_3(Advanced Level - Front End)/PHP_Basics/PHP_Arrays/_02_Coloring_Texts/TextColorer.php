<?php
if(isset($_GET['inputField'], $_GET['submit'])) {
    $strArr = str_split($_GET['inputField']);
}
?>

<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Coloring Text</title>
    <link rel="stylesheet" href="CSS/style.css" type="text/css"/>
</head>
<body>
<div id="wrapper">
    <form action="">
        <textarea id="input-field" name="inputField" placeholder="Enter text" required="required"></textarea>
        <input type="submit" name="submit" value="Color text"/>
    </form>
    <?php if(isset($strArr)):
    foreach($strArr as $char):
    if($char !== ' '): ?>
        <span class="<?= ord($char) % 2 !== 0 ? "blue" : "red" ?>"><?= htmlentities($char)?> </span>
    <?php endif; endforeach; endif; ?>
</div>
</body>
</html>