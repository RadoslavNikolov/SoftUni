<?php
date_default_timezone_set("Europe/Sofia");
$inputText = preg_split("/\r?\n/",$_GET['text'],-1,PREG_SPLIT_NO_EMPTY);
$maxPrice = $_GET['max-price'];
$minPrice = $_GET['min-price'];
$sort = $_GET['sort'];
$order = $_GET['order'];
$criteria = [
    'genre' => 2,
    'author' => 0,
    'publish-date' => 4
];
$primarySort = [];
$secondarySort = [];
$books = [];
foreach($inputText as $line) {
    $lineArray = preg_split("/\\//",$line, -1, PREG_SPLIT_NO_EMPTY);
//    var_dump($lineArray);
    if($lineArray[3] < $minPrice || $lineArray[3] > $maxPrice) continue;
    $books[] = [
        'author' => htmlspecialchars(trim($lineArray[0])),
        'name' => htmlspecialchars(trim($lineArray[1])),
        'genre' => htmlspecialchars(trim($lineArray[2])),
        'price' => floatval(trim($lineArray[3])),
        'publish-date' => date_create(trim($lineArray[4])),
        'info' => htmlspecialchars(trim($lineArray[5]))
    ];

    $primarySort[] = trim($lineArray[$criteria[$sort]]);
    $secondarySort[] = date_create(trim($lineArray[4]));
}

$typeOfSort = $order === 'ascending' ? SORT_ASC : SORT_DESC;

if($sort === 'publish-date') {
    array_multisort($secondarySort, $typeOfSort, $books);
} else {
    array_multisort($primarySort, $typeOfSort, $secondarySort, SORT_ASC, $books);
}
//var_dump($books);
//var_dump($primarySort);
//var_dump($secondarySort);
//var_dump($typeOfSort);
foreach($books as $book) {
    echo "<div><p>{$book['name']}</p><ul>";
    echo "<li>{$book['author']}</li><li>{$book['genre']}</li>";
    echo "<li>" . number_format($book['price'], 2, '.', ''). "</li>";
    echo "<li>" . $book['publish-date']->format('Y-m-d') . "</li>";
    echo "<li>{$book['info']}</li></ul></div>";
}
