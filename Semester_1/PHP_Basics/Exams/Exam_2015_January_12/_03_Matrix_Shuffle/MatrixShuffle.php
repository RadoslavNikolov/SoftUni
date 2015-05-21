<?php
$inputText = $_GET['text'];
$matrixSize = $_GET['size'];

$matrix = [];
$index = 0;
$minRow = 0;
$maxRow = $matrixSize;

$minCol = 0;
$maxCol = $matrixSize;

while($index < strlen($inputText)) {
//    var_dump($index++);
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

foreach($matrix as &$value) {
    ksort($value);
}

$white = '';
$black = '';

for ($i = 0; $i < count($matrix); $i++) {
    for ($j = 0; $j < count($matrix[$i]); $j++) {
        if($i % 2 === 0) {
            if($j % 2 === 0) {
                $white .= $matrix[$i][$j];
            } else {
                $black .= $matrix[$i][$j];
            }
        } else {
            if($j % 2 === 0) {
                $black .= $matrix[$i][$j];
            } else {
                $white .= $matrix[$i][$j];
            }
        }
    }
}
$concatString = $white . $black;
$tempString = preg_replace("/[^a-zA-Z]/", "", $concatString);
$color = "#E0000F";
if(strtolower($tempString) === strrev(strtolower($tempString))) {
    $color = "#4FE000";
}

echo "<div style='background-color:$color'>" . htmlspecialchars($white) . htmlspecialchars($black) . "</div>";
