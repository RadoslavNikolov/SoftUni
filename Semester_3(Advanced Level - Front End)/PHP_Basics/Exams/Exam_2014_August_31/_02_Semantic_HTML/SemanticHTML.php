<?php
$inputArr = $_GET['html'];
$semanticTags = ["main", "header", "nav", "article", "section", "aside", "footer"];

$openTagsPattern = '/<div.*?\b((id|class)\s*=\s*"(.*?)").*?>/';
preg_match_all($openTagsPattern, $inputArr, $matches);
//var_dump($matches);
foreach($matches[0] as $key => $match) {
    $attrName = $matches[1][$key];
    $attrValue = $matches[3][$key];
    if (in_array($attrValue, $semanticTags)) {
        $replaceTag = str_replace('div', $attrValue, $match);
        $replaceTag = str_replace($attrName, '', $replaceTag);
        $replaceTag = preg_replace('/\s*>/', '>', $replaceTag);
        $replaceTag = preg_replace('/\s{2,}/', ' ', $replaceTag);
        $inputArr = str_replace($match, $replaceTag, $inputArr);
    }
}


$closeTagsPattern = '/<\/div>\s.*?(\w+)\s*-->/';
preg_match_all($closeTagsPattern, $inputArr, $matches);
//var_dump($matches);

foreach($matches[0] as $key => $match) {
    $commentValue = $matches[1][$key];
    if (in_array($commentValue, $semanticTags)) {
        $inputArr = str_replace($match, "</$commentValue>", $inputArr);
    }
}

echo $inputArr;

