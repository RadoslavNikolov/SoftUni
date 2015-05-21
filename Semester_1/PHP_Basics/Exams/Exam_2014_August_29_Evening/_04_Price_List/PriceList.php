<?php
$inputText = $_GET['priceList'];
$inputArr = preg_split("/\r?\n/", $inputText);
$inputText = implode("",$inputArr);
//var_dump($inputText);

$productList = [];

preg_match_all("/(<tr>.*?<\\/tr>)/",$inputText,$matches);
//var_dump($matches);
foreach($matches[0] as $line) {
    preg_match_all("/<td>(.*?)<\\/td>/",$line,$match);
//    var_dump($match);
    if(!empty($match[1])){
        $category = html_entity_decode(trim($match[1][1]));
        $item = [
            'product' => html_entity_decode(trim($match[1][0])),
            'price' => html_entity_decode(trim($match[1][2])),
            'currency' => html_entity_decode(trim($match[1][3]))
        ];
        if(!isset($productList[$category])) {
            $productList[$category] = [];
        }
        array_push($productList[$category], $item);
    }
}
ksort($productList);

foreach($productList as $key => $value) {
    usort($value, function($a, $b) {
        return strcmp($a['product'], $b['product']);
    });
    $productList[$key] = $value;
}

echo json_encode($productList);







