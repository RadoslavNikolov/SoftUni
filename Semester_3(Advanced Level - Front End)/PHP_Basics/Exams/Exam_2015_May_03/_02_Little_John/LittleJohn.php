<?php
$input = [];
$input[] = $_GET['arrows'];
$input[] = $_GET['arrows1'];
$input[] = $_GET['arrows2'];
$input[] = $_GET['arrows3'];

//var_dump($input);
$smallArrow = 0;
$mediumArrow = 0;
$largeArrow = 0;
$largArrPattern = "/(>{3}-{5}>{2})/";
$medArrPattern = "/(>{2}-{5}>{1})/";
$smallArrPattern = "/(>{1}-{5}>{1})/";

foreach($input as $line) {
    preg_match_all($largArrPattern,$line,$matches);
    if(!empty($matches[1])){
//        var_dump($matches);
        $largeArrow += count($matches[1]);
        $line = str_replace(">>>----->>",'*',$line);
    }

    preg_match_all($medArrPattern,$line,$matches);
    if(!empty($matches[1])){
//        var_dump($matches);
        $mediumArrow += count($matches[1]);
        $line = str_replace(">>----->",'*',$line);

    }

    preg_match_all($smallArrPattern,$line,$matches);
    if(!empty($matches[1])){
//        var_dump($matches);
        $smallArrow += count($matches[1]);
        $line = str_replace(">----->",'*',$line);
    }
}
$output = '';
var_dump($smallArrow);
var_dump($mediumArrow);
var_dump($largeArrow);


$count = (int)($smallArrow . $mediumArrow . $largeArrow);

$output .= decbin($count);
var_dump($output);
$output .= strrev(decbin($count));
echo bindec($output);
//var_dump(bindec($output));



