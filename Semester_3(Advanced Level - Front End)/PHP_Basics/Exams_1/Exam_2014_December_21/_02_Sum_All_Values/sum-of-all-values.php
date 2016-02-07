<?php
//preg_match_all("/^([A-Za-z_]+)\\d+.*?\\d+([A-Za-z+]+)$/",$_GET['keys'],$keyMatches);
preg_match("/^([A-Za-z_]+)\\d+/",$_GET['keys'],$startKey);
preg_match("/\\d+([A-Za-z_]+)$/",$_GET['keys'],$endKey);
//var_dump($keyMatches);

if($startKey && $endKey) {
    $startKey = $startKey[1];
    $endKey = $endKey[1];
    $pattern = "/" . $startKey . "(.*?)" . $endKey . "/";
    preg_match_all($pattern,$_GET['text'],$matches);
    $sum = 0;
//    var_dump($matches);
    foreach($matches[1] as $num) {
        if(is_numeric($num) && $num != "") {
            $sum += $num;
//                var_dump($sum);
        }
    }
    echo "<p>The total value is: <em>" . ($sum == 0 ? "nothing" : $sum) . "</em></p>";
} else {
    echo "<p>A key is missing</p>";
}