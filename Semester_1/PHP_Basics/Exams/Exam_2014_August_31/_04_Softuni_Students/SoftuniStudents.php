<?php
$inputText = $_GET['students'];
$column = $_GET['column'];
$order = $_GET['order'];
preg_match_all("/^.*$/m",$inputText,$matches);
$output = "";
//var_dump($matches);

$tempIndex = 0;
foreach($matches[0] as $student) {
    $cuurStudentArr = preg_split("/\\s*,\\s*/", $student);
    $id = ++$tempIndex;
    $username = $cuurStudentArr[0];
    $email = $cuurStudentArr[1];
    $type = $cuurStudentArr[2];
    $result = (int)$cuurStudentArr[3];

//    var_dump($key);
//    var_dump($cuurStudentArr);
    $studentsArray[] = [
        'id' => $id,
        'username' => $username,
        'email' => $email,
        'type' => $type,
        'result' => $result
    ];
}

switch($column) {
    case 'id' : usort($studentsArray, 'sortById'); break;
    case 'username' : usort($studentsArray, 'sortByUsername'); break;
    case 'result' : usort($studentsArray, 'sortByResult'); break;
    default: break;
}

if($order === 'descending') {
    $studentsArray = array_reverse($studentsArray);
}
$output = "<table><thead><tr><th>Id</th><th>Username</th><th>Email</th><th>Type</th><th>Result</th></tr></thead>";

foreach($studentsArray as $key => $value) {
    $id = $value['id'];
    $username = htmlspecialchars($value['username']);
    $email = htmlspecialchars($value['email']);
    $type = htmlspecialchars($value['type']);
    $result = htmlspecialchars($value['result']);
    $output .= "<tr><td>$id</td><td>$username</td><td>$email</td><td>$type</td><td>$result</td></tr>";
}
$output .= "</table>";
echo $output;

function sortById($a, $b) {
    return $a['id'] < $b['id'] ? -1 : 1;
}

function sortByUsername($a, $b) {
    $result = strcmp($a['username'], $b['username']);
    if($result === 0) {
        $result = sortById($a, $b);
    }
    return $result;
}

function sortByResult($a, $b) {
    if($a['result'] === $b['result']) {
        $result = sortById($a, $b);
    } else {
        $result = $a['result'] < $b['result'] ? -1 : 1;
    }
    return $result;
}
