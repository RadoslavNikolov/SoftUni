<?php
$inputArray = explode('C|_|',$_GET['luggage']);
//$inputArray = preg_split("/C|_|/",$_GET['luggage'],-1,PREG_SPLIT_NO_EMPTY);
$minWeight = (int)$_GET['minWeight'];
$maxWeight = (int)$_GET['maxWeight'];
$typeLuggageArray = $_GET['typeLuggage'];
$filterRoom = $_GET['room'];

$output = [];
//var_dump($inputArray);

//var_dump($typeLuggageArray);

foreach($inputArray as $line) {
    if($line === '') continue;
    $lineArray = explode(";",$line);
//    var_dump($lineArray);
    $luggageType = trim($lineArray[0]);
    $room = trim($lineArray[1]);
    $name = trim($lineArray[2]);
    $weight = (int)$lineArray[3];
    if($room != $filterRoom) continue;
    if(!in_array($luggageType,$typeLuggageArray)) continue;
    if(!isset($output[$luggageType])) {
        $output[$luggageType] = [];
        $output[$luggageType]['room'] = $room;
        $output[$luggageType]['name'] = [];
        $output[$luggageType]['name'][] = $name;
        $output[$luggageType]['weight'] = $weight;
    } else {
        $output[$luggageType]['name'][] = $name;
        $output[$luggageType]['weight'] += $weight;
    }
}
//sort
ksort($output);
foreach ($output as $key => $value) {
    usort($value['name'], function($a, $b){
        return strcmp($a, $b);
    });
    $output[$key] = $value;
}

//print
echo '<ul>';
foreach($output as $key => $value) {
    if($output[$key]['weight'] < $minWeight || $output[$key]['weight'] > $maxWeight) continue;
    echo '<li><p>'. htmlspecialchars($key) .'</p>';
    echo '<ul><li><p>'. htmlspecialchars($value['room']) .'</p>';
    echo '<ul><li><p>'. htmlspecialchars(implode(', ', $value['name'])) .' - '. $value['weight'] .'kg</p>';
    echo '</li></ul></li></ul></li>';
}
echo '</ul>';


