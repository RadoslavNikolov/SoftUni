<?php
$inputArray = preg_split("/\r?\n/",$_GET['list'],-1,PREG_SPLIT_NO_EMPTY);

$order = $_GET['order'];
$type = $_GET['filter'];
$minPrice = $_GET['minPrice'];
$maxPrice = $_GET['maxPrice'];

$computers = [];
$tempIndex = 0;
foreach($inputArray as $line) {
    $lineArr = preg_split("/\\|/",$line,-1,PREG_SPLIT_NO_EMPTY);
    $tempIndex++;
    if(trim($lineArr[3]) < $minPrice || trim($lineArr[3]) > $maxPrice) continue;
    if(trim($lineArr[1]) != $type && $type != 'all') continue;

    $computers[] = [
        'id' => $tempIndex,
        'name' => trim($lineArr[0]),
        'type' => trim($lineArr[1]),
        'components' => trim($lineArr[2]),
        'price' => floatval(trim($lineArr[3]))
    ];
}

usort($computers, function($a, $b) use ($order) {
    $compare = $a['price'] - $b['price'];
    if($compare == 0) {
        return $a['id'] > $b['id'];
    }
    if($order == 'descending') {
        $compare *= -1;
    }
    return $compare;
});

foreach($computers as $product) {
    $componentsList = explode(",",$product['components']);
    echo '<div class="product" id="product' . htmlspecialchars(trim($product['id'])) . '">';
    echo "<h2>" . htmlspecialchars($product['name']) . "</h2>";
    if(!empty($componentsList)) {
        echo "<ul>";
        foreach($componentsList as $item) {
            echo '<li class="component">' . htmlspecialchars(trim($item)) . '</li>';
        }
        echo "</ul>";
    }
    echo '<span class="price">' . number_format($product['price'], 2, '.', '') . '</span></div>';
}
