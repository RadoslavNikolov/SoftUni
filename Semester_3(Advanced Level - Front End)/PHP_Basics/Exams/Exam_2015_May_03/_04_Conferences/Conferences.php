<?php
date_default_timezone_set("Europe/Sofia");
$inputText = $_GET['conferences'];

//$file = 'people.txt';
//// Open the file to get existing content
//$current = file_get_contents($file);
//// Append a new person to the file
//$current .= $inputText;
//// Write the contents back to the file
//file_put_contents($file, $current);

preg_match_all("/\\[(.*?)\\]/",$inputText,$matches);
//var_dump($matches);
$page = (int)$_GET['page'];
$pageSize = (int)$_GET['pageSize'];
//var_dump($page);
//var_dump($pageSize);

$confs = [];
$primarySort = [];
$secondarySort = [];
$thirdSort = [];
$fourthSort = [];
$currDate = date_create("2015-05-03");

foreach($matches[1] as $line) {
   $lineArray = explode(", ",$line);
//    var_dump($lineArray);
    $temp = preg_match("/^\\d{4}[-\\/]\\d{2}[-\\/]\\d{2}\\s*/",$lineArray[0]);
    preg_match_all("/^\\d{4}(.*)\\d{2}(.*)\\d{2}/",$lineArray[0],$delimiters);
    if($delimiters[1] != $delimiters[2]){
        $temp = 0;
        $date = date_create($lineArray[0]);
    }
    $temp1 = preg_match("/#[A-Za-z.-]+/",$lineArray[1]);
    $temp2 = preg_match("/'[\\S\\s]+'/",trim($lineArray[2]));
    $temp3 = preg_match("/[A-Za-z-,]+/",trim($lineArray[3]));
    $temp4 = preg_match("/\\b[\\d]+\\b/",trim($lineArray[4]));
    $temp5 = preg_match("/\\b[\\d]+\\b/",trim($lineArray[5]));
    if($temp && $temp1 && $temp2 && $temp3 && $temp4 && $temp5) {
        $date = date_create($lineArray[0]);
        $tag = htmlspecialchars(trim($lineArray[1]));
        $name = htmlspecialchars(trim($lineArray[2]));
        $location = htmlspecialchars(trim($lineArray[3]));
        $ticketsAll = htmlspecialchars(trim($lineArray[4]));
        $ticketsSold = htmlspecialchars(trim($lineArray[5]));
        $primarySort[] = $date->format('Y-m-d');
        $secondarySort[] = $location;
        $thirdSort[] = $ticketsAll - $ticketsSold;
        $fourthSort[] = $name;

        $confs[] = [
            'date' => $date->format('Y-m-d'),
            'tag' => $tag,
            'name' => $name,
            'location' => $location,
            'ticketsAll' => $ticketsAll,
            'ticketsSold' => $ticketsSold
        ];
    }
}

//var_dump($primarySort);
//var_dump($confs);
//var_dump($secondarySort);
//var_dump($thirdSort);
//var_dump($fourthSort);
array_multisort($primarySort, SORT_DESC, $secondarySort, SORT_ASC, $thirdSort, SORT_ASC, $fourthSort, SORT_DESC, $confs);
$rowSpan = 1;
$indexRowSpan = 0;
for ( $i = 0; $i < count($confs) - 1; $i++) {
    $date1 = $confs[$i]['date'];
    $date2 = $confs[$i+1]['date'];
    if($date1 == $date2) {
        $rowSpan++;
        $indexRowSpan = $i;
    }
}
echo '<table border="1" cellpadding="5"><tr><th>Date</th><th>Event name</th><th>Event hash</th><th>Days left</th><th>Seats left</th></tr>';

for ( $i = 0; $i < count($confs); $i++) {
    if($i >= ($page -1)*$pageSize && $i < ($page-1)*$pageSize  + $pageSize) {
        $tempDate = date_create($confs[$i]['date'])->format('z');
        $timeDiff = $tempDate - $currDate->format('z');
//        var_dump($timeDiff);
//    var_dump($confs[$i]['date']);
//    var_dump($timeDiff);
        echo "<tr>";
        if($rowSpan > 1) {
            if($rowSpan > 1 && $indexRowSpan == $i) {
                echo '<td rowspan="' . $rowSpan . '">' . $confs[$i]['date'] . '</td>';
            }
            if($i >= $indexRowSpan + $rowSpan) {
                echo '<td>' . $confs[$i]['date'] . '</td>';
            }
        } else {
            echo '<td>' . $confs[$i]['date'] . '</td>';
        }


        $name1 = trim(str_replace("'","",$confs[$i]['name']));

        echo "<td>" . $name1 . "</td>";
        echo "<td>" . $confs[$i]['tag'] . "</td>";
        if($timeDiff >= 0) {
            echo "<td>+" . $timeDiff . " days</td>";
        } else {
            echo "<td>" . $timeDiff . " days</td>";

        }
        echo "<td>" . ($confs[$i]['ticketsAll'] - $confs[$i]['ticketsSold']) . " seats left</td></tr>";
    }

}
if(empty($confs)) {
    echo "<tr><td>-</td><td>-</td><td>-</td><td>-</td><td>-</td></tr>";
}

echo "</table>";


//var_dump($confs);