<?php
$input = trim($_GET['fruit']);
$sumOfDigits = 0;;
for ( $i = 0; $i < strlen($input); $i++) {
    $char = $input[$i];
    $sumOfDigits += ord($char);
}
$output = ">>";
$numAsString = (strval($sumOfDigits));
if(strlen($numAsString)>=2) {
    $leftIndex = $numAsString[0] + 2;
    $rightIndex = 2 + $leftIndex + strlen($input) + $numAsString[strlen($sumOfDigits)-1];
    $output = str_pad($output,$leftIndex,'-');
    $output .= '(' . $input . ')';
    $output = str_pad($output,$rightIndex,'-');
    $output .= '>';
} elseif(strlen($numAsString) == 1) {
    $leftIndex = $numAsString[0];
    $output = str_pad($output,$leftIndex,'-');
    $output .= '(' . $input . ')>';
} else {
    $output .= '(' . $input . ')>';
}
echo $output;