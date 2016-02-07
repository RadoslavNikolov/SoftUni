<?php
$inputArray = preg_split("/\r?\n/",$_GET['list'],-1,PREG_SPLIT_NO_EMPTY);
$minPrice = floatval($_GET['minPrice']);
$maxPrice = floatval($_GET['maxPrice']);
$filter = trim($_GET['filter']);
$order = trim($_GET['order']);

$primarySort = [];
$secondarySort = [];
$computers = [];

$index = 0;
foreach($inputArray as $line) {
    $index++;
    $lineArray = preg_split("/\\s*\\|\\s*/",$line,-1,PREG_SPLIT_NO_EMPTY);
    $name = trim($lineArray[0]);
    $type = trim($lineArray[1]);
    $components = trim($lineArray[2]);
    $price = floatval($lineArray[3]);
    if($price < $minPrice || $price > $maxPrice) continue;
    if($type != $filter && $filter != 'all') continue;
    $computers[] = [
        'id' => $index,
        'name' => $name,
        'type' => $type,
        'components' => $components,
        'price' => $price
    ];
    $primarySort[] = $price;
    $secondarySort[] = $index-1;
}
//sort
$sort = SORT_ASC;
if($order == 'descending') {
    $sort = SORT_DESC;
}
array_multisort($primarySort,$sort,$secondarySort,SORT_ASC,$computers);

//print
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