<?php
$numbersString = $_GET['numbersString'];
preg_match_all("/(\\b[A-Z][A-Za-z]*)[^0-9A-Za-z+]*([+]?[0-9]+[0-9\\- \\.\\/\\)\\(]*[0-9]+)/",$numbersString,$numbersList);
//var_dump($numbersList);

if(!empty($numbersList[1])) {
    echo "<ol>";
    for ($i = 0; $i < count($numbersList[1]) ; $i++) {
        $phoneNumber = $numbersList[2][$i];
        $phoneNumber = preg_replace("/[\\- \\.\\/\\)\\(]/","",$phoneNumber);
        echo "<li><b>" . htmlspecialchars($numbersList[1][$i]) . ":</b> " . htmlspecialchars($phoneNumber) . "</li>";
    }
    echo "</ol>";
} else {
    echo "<p>No matches!</p>";
}
