<?php
date_default_timezone_set('Europe/Sofia');
$currDate = date_create_from_format('d/m/Y', $_GET['today']);
$inputArray = preg_split("/\\s*,\\s+/",$_GET['registrations'],-1,PREG_SPLIT_NO_EMPTY);
$cars = [];
if(!empty($inputArray)) {
    foreach($inputArray as $line) {
        $lineArray = preg_split("/\\s*\\|\\s*/",$line,-1,PREG_SPLIT_NO_EMPTY);
        $car = trim(htmlspecialchars($lineArray[0]));
        $model = trim(htmlspecialchars($lineArray[1]));
        $date = date_create_from_format('d/m/Y', $lineArray[2]);
        $plateNumber = trim(htmlspecialchars($lineArray[3]));
        if(!isset($cars[$car])) {
            $cars[$car] = [];
            if(!isset($cars[$car][$model])) {
                $cars[$car][$model] = [
                    'registrations' => []
                ];
            }
        }

        if($date > $currDate) {
            $cars[$car][$model]['registrations'][] = [
                'date' => $lineArray[2],
                'plate' => $plateNumber,
                'isValid' => false
            ];
        } else {
            $cars[$car][$model]['registrations'][] = [
                'date' => $lineArray[2],
                'plate' => $plateNumber
            ];
        }
    }
}
ksort($cars);
foreach($cars as $key => $model) {
    ksort($model);
    $cars[$key] = $model;
}
echo json_encode($cars);
//echo '<br><br>' . '{"Audi":{"A3":{"registrations":[{"date":"1\/12\/2012","plate":"CA4444CC"}]}},"Ford":{"Focus":{"registrations":[{"date":"11\/05\/2010","plate":"PB1234AB"},{"date":"1\/12\/2012","plate":"PB1111PB"}]}},"Opel":{"Astra":{"registrations":[{"date":"11\/05\/2020","plate":"CB9999CA","isValid":false}]}}}';