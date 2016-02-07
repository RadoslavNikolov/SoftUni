<?php
$inputStr = json_decode($_GET['jsonTable']);
$numOfCols = $inputStr[0];
$index = 0;
$output = [];
foreach($inputStr[1] as $line) {
    preg_match_all("/time=(\\d{0,3})ms/",$line,$matches);
    if(isset($matches[1][0])) {
        $timeStr = $matches[1][0];
    }
    if(isset($timeStr) && $timeStr != '' ) {
        $letter = chr($timeStr);
        if(ctype_alpha($letter)) {
            $output[] = $letter;
            $index++;
        }
        if($letter == ' '){
            $output[] = '';
            $index++;
        }
        if($letter == '*') {
            if($index > 0 && $index % $numOfCols > 0) {
                for ($i = $index % $numOfCols; $i < $numOfCols; $i++) {
                    $output[] = '';
                    $index++;
                }
            }
        }
    }
}
//var_dump($index);
while($index%$numOfCols > 0) {
    $output[] = '';
    $index++;
}
//var_dump($output);

echo "<table border='1' cellpadding='5'>";
    for ($i = 0; $i < count($output); $i++) {
      if($i % $numOfCols == 0) {
          echo "<tr>";
      }
        if($output[$i] != ''){
            echo "<td style='background:#CAF'>" . htmlspecialchars($output[$i]) . "</td>";
        } else {
            echo "<td></td>";
        }

        if($i % $numOfCols == $numOfCols-1){
            echo "</tr>";
        }
    }

echo "</table>";
