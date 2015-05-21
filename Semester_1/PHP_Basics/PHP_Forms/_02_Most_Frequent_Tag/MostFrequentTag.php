<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Most Frequent Tag</title>
    <link rel="stylesheet" href="CSS/style.css" type="text/css"/>
</head>
<body>
    <div id="wrapper">
        <form action="MostFrequentTag.php" method="get">
            <h3>Enter Tags:</h3>
            <input type="text" id="input" name="input"/>
            <input type="submit" value="Submit"/>
        </form>
        <?php if (isset($_GET['input']) && $_GET['input'] != ''):
            $result = array();
            $tags_arr = array_map('trim', explode(', ',$_GET['input']));
            foreach($tags_arr as $tag) {
                $result[$tag] = array_key_exists($tag, $result) ? $result[$tag]+1 : 1;
            }
            arsort($result);
//            var_dump($result);
            $max = max(array_values($result));
//            var_dump($max);
            $output = array_keys($result, $max);
//            var_dump($output);
            ?>
        <ul>
            <?php foreach($result as $key => $value): ?>
                <li><?= htmlentities($key)?> : <?= htmlentities($value)?> times</li>
            <?php endforeach ?>
        </ul>
            <p>Most Frequent Tag is: <?= join(', ',$output) ?></p>
        <?php endif ?>
    </div>
</body>
</html>