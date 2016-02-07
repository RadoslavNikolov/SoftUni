<?php
$inputText = $_GET['text'];
$lineLength = (int)$_GET['lineLength'];

$charArr = str_split($inputText);
$tempIndex = 0;

while($tempIndex < count($charArr)) {
    $tempIndex += $lineLength;
}

while(count($charArr) < $tempIndex) {
    $charArr[] = " ";
}
$row = 0;
$charIndex = 0;
$matrix = array();

// Fill the characters in the matrix
while($charIndex < count($charArr)){
    for ($col = 0; $col < $lineLength; $col++) {
        $matrix[$row][$col] = $charArr[$charIndex];
        $charIndex++;
    }
    $row++;
}
//printMatrix($matrix);


// Fall down
for ($roll = 0; $roll < count($matrix); $roll++) {
    for ($row = count($matrix) - 2; $row >= 0  ; $row--) {
        for ($col = 0; $col < count($matrix[0]); $col++) {
            if($matrix[$row+1][$col] === ' ') {
                $matrix[$row+1][$col] = $matrix[$row][$col];
                $matrix[$row][$col] = ' ';
            }
        }
    }
}
//printMatrix($matrix);

printTable($matrix);

function printTable($matrix){
    echo "<table>";
    for ($row = 0; $row < count($matrix); $row++) {
        echo "<tr>";
        for ($col = 0; $col < count($matrix[0]); $col++) {
            echo "<td>" . htmlspecialchars($matrix[$row][$col]) . "</td>";
        }
        echo "</tr>";
    }
    echo "<table>";
}


function printMatrix($matrix) {
    for ($row = 0; $row < count($matrix); $row++) {
        for ($col = 0; $col < count($matrix[0]); $col++) {
            echo "<span>{$matrix[$row][$col]}</span>";
        }
        echo "</br>";
    }
}


