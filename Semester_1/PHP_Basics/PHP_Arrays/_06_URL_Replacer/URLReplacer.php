<?php
if(isset($_GET['text'], $_GET['submit'])) {
    $inputStr = trim($_GET['text']);
    $output = $inputStr;
    preg_match_all("/(<a.*?<\\/a>)/m",$inputStr,$matches);
//    var_dump($matches);
    foreach($matches[0] as $match){

        preg_match_all("/<a\\s*href=['\"]?(.*?)['\"]?>/",$match,$newMatch);
//        var_dump($newMatch);
        $replStr = "[URL=" . $newMatch[1][0] . "]";
        $output = str_replace($newMatch[0],$replStr,$output);
    }

    $output = str_replace("</a>","[/URL]",$output);
}
?>
<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>URL Replacer</title>
    <link rel="stylesheet" href="CSS/style.css" type="text/css"/>
</head>
<body>
<div id="wrapper">
    <form action="">
        <div>
            <label for="text">Text</label>
            <textarea id="text" name="text" placeholder="Enter text" required="required"></textarea>
        </div>
        <input type="submit" name="submit" value="Replace link tag"/>
    </form>
    <?php if(!empty($output)):?>
        <p><?= htmlspecialchars($output) ?></p>
    <?php endif; ?>
</div>
</body>
</html>