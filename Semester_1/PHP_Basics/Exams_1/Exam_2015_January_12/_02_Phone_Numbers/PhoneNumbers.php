<?php
preg_match_all("/(\\b[A-Z][A-Za-z]*)[^0-9A-Za-z+]*([+]?[0-9]+[0-9\\(\\)\\/.\\- ]*[0-9]+)/",$_GET['numbersString'], $numbesArray);
//var_dump($numbesArray);
if(!empty($numbesArray[1])) {
    echo "<ol>";
    for ($i = 0; $i < count($numbesArray[1]); $i++) {
        $name = $numbesArray[1][$i];
        $phoneNumber = preg_replace("/[\\(\\)\\/.\\- ]/","",$numbesArray[2][$i]);
        echo "<li><b>" . htmlspecialchars($name) . ":</b> " . htmlspecialchars($phoneNumber) . "</li>";
    }

    echo "</ol>";

}else {
    echo "<p>No matches!</p>";
}