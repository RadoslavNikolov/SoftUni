<?php

$string = "This is a Hello World script";

echo preg_match("/^(This|That|There)/",$string,$matches);


echo "\n" . preg_match("/(Je|He)llo/",$string,$matches);

foreach ($matches as $key => $value) {
    echo  "\n" . $key . ' -> ' . $value;
}


$string = 'foobar foo--bar fubar';

/*** try to match the pattern ***/
echo (preg_match("/foo(.*)bar/U", $string, $matches));
var_dump($matches);



// create a string
$string = 'We will replace the word foo';

// substitute the word for and put in bar
$string = preg_replace("/foo/", 'bar', $string);

// echo the new string
echo $string;


// create a string with some template vars. the string and
// the vars would easily have been called from a template.
$string = 'This is the {_FOO_} bought to you by {_BAR_}';

// create an array of template vars
// of course, each variable could be an array itself
$template_vars=array("FOO" => "The PHP Way", "BAR" => "PHPro.orG");
var_dump($template_vars);

// preg replace our variables and evaluate them
$string = preg_replace("/{_(.*?)_}/ime", "\$template_vars['$1']",$string);

// echo the new string
echo "\n" . $string;
