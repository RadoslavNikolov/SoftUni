<?php
if(isset($_GET['inputField'], $_GET['submit'])) {
    // Return the number of words in a string.

    $string= strtolower(str_replace("&#039;", "'", $_GET['inputField']));
    $t= array(' ', "\t", '=', '+', '-', '*', '/', '\\', ',', '.', ';', ':', '[', ']', '{', '}', '(', ')', '<', '>', '&', '%', '$', '@', '#', '^', '!', '?', '~'); // separators
    $string= str_replace($t, " ", $string);
    $string= trim(preg_replace("/\\s+/", " ", $string));
    if (strlen(myStrlen($string))>0) {
        $word_array= explode(" ", $string);
    }
    $result = array();
    foreach($word_array as $word) {
        $result[$word] = array_key_exists($word, $result) ? $result[$word]+1 : 1;
    }
    arsort($result);
//            var_dump($result);
//    $max = max(array_values($result));
//            var_dump($max);
//    $output = array_keys($result, $max);
}
function myStrlen($str) {
    // Return mb_strlen with encoding UTF-8.
    return mb_strlen($str, "UTF-8");

}
?>
<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Word Mapping</title>
    <link rel="stylesheet" href="CSS/style.css" type="text/css"/>
</head>
<body>
    <div id="wrapper">
        <form action="">
            <textarea id="input-field" name="inputField" required="required"></textarea>
            <input type="submit" name="submit" value="Count words"/>
        </form>
        <table>
            <?php if(isset($result)):
                foreach($result as $key => $value): ?>
                <tr>
                    <td><?= htmlentities($key)?></td>
                    <td><?= htmlentities($value)?></td>
                </tr>
            <?php endforeach; endif; ?>
        </table>


    </div>
</body>
</html>