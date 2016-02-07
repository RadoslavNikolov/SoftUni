<?php
$inputText = $_GET['text'];
$size = $_GET['size'];
$matrix = [];
$index = 0;
$minRow = 0;
$maxRow = $size;
$minCol = 0;
$maxCol = $size;

//var_dump($inputText);

while($index < strlen($inputText)) {
    for ($col = $minCol; $col < $maxCol; $col++) {
        $matrix[$minRow][$col] = $inputText[$index++];
    }
    $minRow++;
    for ($row = $minRow; $row < $maxRow; $row++) {
        $matrix[$row][$maxCol-1] = $inputText[$index++];
    }
    $maxCol--;
    for ($col = $maxCol-1; $col >= $minCol ; $col--) {
        $matrix[$maxRow-1][$col] = $inputText[$index++];
    }
    $maxRow--;
    for ($row = $maxRow-1; $row >= $minRow ; $row--) {
        $matrix[$row][$minCol] = $inputText[$index++];
    }
    $minCol++;
}

//var_dump($matrix);
foreach($matrix as $line) {
    ksort($line);
}

$white = '';
$black = '';

for ($row = 0; $row < $size; $row++) {
    for ($col = 0; $col < $size; $col++) {
        if($row % 2 === 0) {
            if($col % 2 === 0) {
                $white .= $matrix[$row][$col];
            } else {
                $black .= $matrix[$row][$col];
            }
        } else {
            if($col % 2 === 0) {
                $black .= $matrix[$row][$col];
            } else {
                $white .= $matrix[$row][$col];
            }
        }
    }
}
$concatString = $white . $black;
$temString = preg_replace("/[^A-Za-z]/","",$concatString);
$color = "#E0000F";
if(strtolower($temString) === strrev(strtolower($temString))) {
    $color = "#4FE000";
}
echo "<div style='background-color:$color'>" . htmlspecialchars($concatString) . "</div>";