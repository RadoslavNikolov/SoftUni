<?php
$inputArray = json_decode($_GET['jsonTable']);

$calculatedNumbers = [];
$fibonacciArray = fibonacci(100);

if(!empty($inputArray)) {
    foreach($inputArray as $lineArray) {
        foreach($lineArray as $cell) {
            preg_match_all("/(\\d+)/",$cell,$matches);
            $numberAsString = '';
            foreach($matches[1] as $match) {
                $numberAsString .= $match;
            }
            if(!empty($numberAsString)) {
                $calculatedNumbers[] = (int)$numberAsString;
            }
        }
    }
}
//print
echo "<ul>";
foreach($calculatedNumbers as $number) {
    if(in_array($number,$fibonacciArray)) {
        echo '<li style="color: #3DD459">' . htmlspecialchars($number) . ' - is a Fibonacci number</li>';
    } else {
        echo '<li style="color: #FF5900">' . htmlspecialchars($number) . ' - is not a Fibonacci number</li>';
    }
}
echo "</ul>";

function fibonacci($n,$first = 0,$second = 1)
{
    $fib = [$first,$second];
    for($i=1;$i<$n;$i++)
    {
        $fib[] = $fib[$i]+$fib[$i-1];
    }
    return $fib;
}