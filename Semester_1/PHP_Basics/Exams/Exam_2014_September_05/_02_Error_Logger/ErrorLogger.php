<?php
$inputText = $_GET['errorLog'];
preg_match_all('/Exception in thread ".*" java.*\.(.*):.*\n.*?\.(.*?)\((.*?):(\d+)\)/',$inputText,$matches);
//var_dump($matches);

echo "<ul>";
for ($i = 0; $i < count($matches[1]) ; $i++) {
    $line = trim($matches[4][$i]);
    $exception = trim($matches[1][$i]);
    $fileName = trim($matches[3][$i]);
    $method = trim($matches[2][$i]);

    echo "<li>line <strong>" . htmlspecialchars($line) . "</strong> - <strong>" . htmlspecialchars($exception) . "</strong> in <em>" . htmlspecialchars($fileName) . ":" . htmlspecialchars($method) . "</em></li>";

}
echo "</ul>";