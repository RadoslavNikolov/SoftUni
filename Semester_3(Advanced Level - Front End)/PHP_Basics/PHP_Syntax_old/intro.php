<?php
//$myName = 'Radoslav';
////echo 'My name is ' .$myName;
//
//?>
<!--    <!--nMy name is: -->--><?////=$myName?>
<!---->
<?php
//$p = 5.0;
////$p = ' ' .$p;
////echo $p;
//var_dump($p);
//?>

<?php
$maxInteger = 2147483647;
echo $maxInteger ."\n";
echo gettype($maxInteger) ."\n\n";
$maxInteger +=1;
echo $maxInteger ."\n";
echo gettype($maxInteger) ."\n\n";

$a = 0.1;
$b = 0.2;
$sum = $a + $b;
var_dump($a);
var_dump($b);
var_dump($sum == 0.3);

$variable = "5.15";
$varFloat = (float)$variable;
var_dump($varFloat);


$arr = array('Pesho', 'Gosho');
$arr['Rado'] = 'Hello';
var_dump($arr);

class Person {
    public  $name = '';
    function  name ($newname) {
        $this ->name = $newname;
    }
}
$rado = new Person();
//$rado->name('Radoslav');
$rado->name = 'Radoslav';
//var_dump($rado);
echo "Hello, {$rado->name}\n";


//$res = database_connect();
//database_query($res);
//$res = "boo";
//unset($rado);
//echo $rado->name;
if(isset($rado)) {
    echo $rado->name ."\n\n";
}
$v = false;
echo $v;
echo gettype($v);


$f = "rado";
$$f = 5;
echo "\n\n" . $rado . "\n\n";

$firstName = "Rado";
$secondName =& $firstName;
$secondName = "Pesho";
echo $firstName . "\n";
echo $secondName . "\n";

?>