<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Awesome Calendar</title>
    <link rel="stylesheet" href="style.css" type="text/css"/>
</head>
<body>

<?php
$year = date('Y');
echo '<h1>' . $year . '</h1>';
for ($i = 1; $i <= 12; $i++) {
    echo '<div class="month">';
    echo '<h2>' . date('F',mktime(0,0,0,$i,1,$year)) . '</h2>';
    echo '<div class="day-label">MON</div>';
    echo '<div class="day-label">TUE</div>';
    echo '<div class="day-label">WED</div>';
    echo '<div class="day-label">THU</div>';
    echo '<div class="day-label">FRI</div>';
    echo '<div class="day-label">SAT</div>';
    echo '<div class="day-label">SUN</div>';

    for ($k = 1; $k < date('N',mktime(0,0,0,$i,1,$year)) ; $k++) {
        echo '<div class="day"></div>';
    }
    for ($j = 1; $j <= date('t', mktime(0, 0, 0, $i, 1, $year)); $j++) {
        echo '<div class="day">' . $j . '</div>';
    }

    echo '</div>';

}
?>

</body>
</html>