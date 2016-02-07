<?php
$input = $_GET['code'];
//var_dump($input);
$inputArr = preg_split("/\\r?\\n/",$input,-1,PREG_SPLIT_NO_EMPTY);
$counts = [];
$counts['variables'] = [];
$counts['loops'] = [];
$counts['conditionals'] = [];

$counts['loops'] = [
    'while' => [],
    'for' => [],
    'foreach' => []
];

$variablesPattern = '/\$[a-z0-9_\x7f-\xff][a-zA-Z0-9_\x7f-\xff]*/';
//$variablesPattern = "/\\$[0-9a-z_]+[A-Za-z0-9_]*/";
$loopsPattern = "/((while|for|foreach)\\s*\\((.*)\\))/";
//$loopsPattern = "/((while|for|foreach)\\s*\\(\\$.*\\s*[<>=!]*\\s*\\s*.*\\s*\\))/";
$conditionalPattern = "/((if|else\\s*if)\\s*\\((.*)\\))/";
//$conditionalPattern = "/((if|else\\s*if)\\s*\\((.*)\\))/";

foreach($inputArr as $line) {
    preg_match_all($variablesPattern,$line,$matches);
//var_dump($matches);
    if(!empty($matches) && !empty($matches[0])) {
        foreach($matches[0] as $match) {
//        var_dump($match);
            if(!isset($counts['variables'][$match])) {
                $counts['variables'][$match] = 1;
            } else {
                $counts['variables'][$match] += 1;
            }
        }
    }

    preg_match_all($loopsPattern,$line,$matches);
//var_dump($matches);

    if(!empty($matches) && !empty($matches[1])) {
        for ( $i = 0; $i < count($matches[1]); $i++) {
            $counts['loops'][$matches[2][$i]][] = $matches[1][$i];
        }
//    foreach($matches as $key => $match) {
//        var_dump($match);
//        if(!isset($counts['loops'][$match])) {
//            $counts['loops'][$matches[$key]] = $match;
//        } else {
//            $counts['loops'][$match] += 1;
//        }
    }

    preg_match_all($conditionalPattern,$line,$matches);
    if(!empty($matches) && !empty($matches[1])) {
        for ( $i = 0; $i < count($matches[1]); $i++) {
            $counts['conditionals'][] = $matches[1][$i];
        }
//    foreach($matches as $key => $match) {
//        var_dump($match);
//        if(!isset($counts['loops'][$match])) {
//            $counts['loops'][$matches[$key]] = $match;
//        } else {
//            $counts['loops'][$match] += 1;
//        }
    }
}

//var_dump($matches);
//var_dump($counts);
echo json_encode($counts);

//echo '<br>{"variables":{"$firstNumber":6,"$secondNumber":6},"loops":{"while":["while ($firstNumber < $secondNumber)"],"for":[],"foreach":[]},"conditionals":[]}';


