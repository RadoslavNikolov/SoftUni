<?php
if(isset($_GET['text'], $_GET['extractor'], $_GET['submit'])) {
    $inputStr = trim($_GET['text']);
    $extractor = $_GET['extractor'];
    $outputArr = [];
    preg_match_all("/([A-Z](.*?)[.!?])/m",$inputStr,$matches);
    foreach($matches[0] as $match){
//        var_dump($match);
        if(preg_match("/\\s+$extractor\\s+/em", $match)){
            $outputArr[] = $match;
        }
    }
//    var_dump($outputArr);
    $output = implode(" ",$outputArr);
}
?>

<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Sentence Extractor</title>
    <link rel="stylesheet" href="CSS/style.css" type="text/css"/>
</head>
<body>
<div id="wrapper">
    <form action="">
        <div>
            <label for="text">Text</label>
            <textarea id="text" name="text" placeholder="Enter text" required="required"></textarea>
            <input type="text" id="extractor" name="extractor" placeholder="Enter word" required/>
        </div>
        <input type="submit" name="submit" value="Extract sentence"/>
    </form>
    <?php if(!empty($output)):?>
    <p><?= htmlspecialchars($output) ?></p>
    <?php endif; ?>
</div>
</body>
</html>