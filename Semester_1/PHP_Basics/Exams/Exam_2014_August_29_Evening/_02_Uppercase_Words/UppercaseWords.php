<?php
$inputText = $_GET['text'];
//$inputText = "Companies like  HP, ORACLE and IBM target their platforms for cloud-based environment. IList<T> implements IEnumerable<T>. GoPHP is a PHP library.";
preg_match_all("/(?<![a-zA-Z])[A-Z]+(?![A-Za-z])/",$inputText,$matches, PREG_OFFSET_CAPTURE);
//var_dump($matches);

if (!empty($matches[0])) {
    $output = substr($inputText, 0, $matches[0][0][1]);
//    var_dump($output);
    for ($i = 0; $i < count($matches[0]); $i++) {
        $match = $matches[0][$i];
        $replacer = strrev($match[0]);
//        var_dump($replacer);

        if($match[0] ===  $replacer) {
            $replacer = '';

            for ($j = 0; $j < strlen($match[0]); $j++) {
                $replacer .= $match[0][$j];
                if (ctype_alpha($match[0][$j])) {
                    $replacer .= $match[0][$j];
                }
            }
        }

        $output .= $replacer;
        if ($i < count($matches[0]) - 1) {
            $len = $matches[0][$i + 1][1] - $match[1] - strlen($match[0]);
            $output .= substr($inputText, $match[1] + strlen($match[0]), $len);
        }

        if ($i == count($matches[0]) - 1) {
            $output .= substr($inputText, $match[1] + strlen($match[0]));
        }

    }
    echo "<p>" . htmlspecialchars($output) . "</p>";
} else {
    echo "<p>" . htmlentities($inputText) . "</p>";
}
