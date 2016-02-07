<?php
$input = json_decode($_GET['jsonTable']);
$m = 26;
$k = $input[1][0];
$s = $input[1][1];
$words = [];
$size = 0;
//var_dump($input);
foreach($input[0] as $word) {
    $tempWord = strtoupper($word);
    $size = max(strlen($tempWord), $size);
    $processedWord = '';
    for ($i = 0; $i < strlen($tempWord); $i++) {
        if(ord($tempWord[$i]) < 65 || ord($tempWord[$i]) > 90) {
            $processedWord .= $tempWord[$i];
        } else {
            $cipher = (($k * (ord($tempWord[$i])-65)) + $s) % $m;
            $processedWord .= chr($cipher + 65);
        }

    }
    $words[] = $processedWord;

}

echo "<table border='1' cellpadding='5'>";
for ($row = 0; $row < count($words); $row++) {
    $word = str_pad($words[$row],$size);
    echo "<tr>";
    if($size > 0) {
        for ($col = 0; $col < $size; $col++) {
            if($word[$col] != ' ') {
                echo "<td style='background:#CCC'>" . htmlspecialchars($word[$col]) . "</td>";
            } else {
                echo "<td></td>";
            }
        }
    } else {
        echo "<td></td>";
    }

    echo "</tr>";
}
echo "</table>";