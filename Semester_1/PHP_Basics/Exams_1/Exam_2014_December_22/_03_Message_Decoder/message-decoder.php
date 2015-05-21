<?php
$inputArray = json_decode($_GET['jsonTable']);
$matrixSize = $inputArray[0];
$words = [];
$tempWord = '';
for ($i = 1; $i < count($inputArray[1]); $i++) {
    preg_match("/\\s+time=(\\d+)ms\\s+/",$inputArray[1][$i],$match);
    $char = chr($match[1]);
    if($char == '*') {
        $words[] = $tempWord;
        $tempWord = '';
    } else {
        $tempWord .= $char;
    }
    if($i === count($inputArray[1])-1 && $tempWord !== '' ) {
        $words[] = $tempWord;
    }
}
echo "<table border='1' cellpadding='5'>";
foreach($words as $word) {
    $tempIndex = strlen($word) % $matrixSize;
    if($tempIndex > 0) {
        while($tempIndex < $matrixSize) {
            $word .= ' ';
            $tempIndex++;
        }
    }
    $tempIndex = 0;
    while($tempIndex < strlen($word)) {
        echo "<tr>";
        for ($col = 0; $col < $matrixSize; $col++) {
            if($word[$tempIndex] !== ' ') {
                echo "<td style='background:#CAF'>" . htmlspecialchars($word[$tempIndex++]) . "</td>";
            }else {
                echo "<td></td>";
                $tempIndex++;
            }
        }
        echo "</tr>";
    }
}
echo "</table>";