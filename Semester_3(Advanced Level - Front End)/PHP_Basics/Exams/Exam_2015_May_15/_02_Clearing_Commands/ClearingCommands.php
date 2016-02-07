<?php
$inputArray = preg_split("/\r?\n/",$_GET['array'],-1,PREG_SPLIT_NO_EMPTY);
$maxRow = count($inputArray);
$maxCol = strlen($inputArray[0]);

$outputMatrix = $inputArray;
$removal = ['>','<','v','^'];

for ( $row = 0; $row < $maxRow; $row++) {
    for ( $col = 0; $col < $maxCol; $col++) {
        $char = $inputArray[$row][$col];
        if(!in_array($char,$removal)) continue;
        switch($char) {
            case '>' : $outputMatrix = clearRight($row,$col,$outputMatrix,$removal); break;
            case 'v' : $outputMatrix = clearDown($row,$col,$outputMatrix,$removal); break;
            case '<' : $outputMatrix = clearLeft($row,$col,$outputMatrix,$removal); break;
            case '^' : $outputMatrix = clearUp($row,$col,$outputMatrix,$removal); break;
            default: break;
        }
    }
}
//var_dump($outputMatrix);
//print
foreach($outputMatrix as $line) {
    $output = '<p>';
    for ( $i = 0; $i < strlen($line); $i++) {
        $output .= htmlspecialchars($line[$i]);
    }
    $output .= "</p>\n";
    echo $output;
}

function clearUp($row,$col,$matrix,$removal) {
//    echo 'in method';
    if($row > 0) {
        for ( $j = $row-1; $j >= 0; $j--) {
            if(in_array($matrix[$j][$col],$removal)) {
                break;
            }
            $matrix[$j][$col] = ' ';
        }
    }
    return $matrix;
}
function clearLeft($row,$col,$matrix,$removal) {
//    echo 'in method';
    if($col > 0) {
        for ( $j = $col-1; $j >= 0; $j--) {
            if(in_array($matrix[$row][$j],$removal)) {
                break;
            }
            $matrix[$row][$j] = ' ';
        }
    }
    return $matrix;
}

function clearRight($row,$col,$matrix,$removal) {
//    echo 'in method';
    for ( $j = $col+1; $j < strlen($matrix[$row]); $j++) {
        if(in_array($matrix[$row][$j],$removal)) {
            break;
        }
        $matrix[$row][$j] = ' ';
    }
    return $matrix;
}
function clearDown($row,$col,$matrix,$removal) {
//    echo 'in method';
    for ( $j = $row+1; $j < count($matrix); $j++) {
        if(in_array($matrix[$j][$col],$removal)) {
            break;
        }
        $matrix[$j][$col] = ' ';
    }
    return $matrix;
}