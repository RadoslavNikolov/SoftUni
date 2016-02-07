<?php

$string = 'The cat sat on the Mat';

// match the beginning of the string
echo "\n" . preg_match("/^The/", $string);

// match the end of the string
echo "\n" . preg_match("/mat\\z/i", $string);

// match anywhere in the string
echo "\n" . preg_match("/dog/i", $string);


$string = 'The cat sat on the matthew';

// matches the letter "a" followed by zero or more "t" characters
echo "\n" . preg_match("/at*/i", $string);

// matches the letter "a" followed by a "t" character that may or may not be present
echo "\n" . preg_match("/at?/i", $string);


// matches the letter "a" followed by one or more "t" characters
echo "\n" . preg_match("/at+/i", $string);

// matches a possible letter "e" followed by one of more "w" characters anchored to the end of the string
echo "\n" . preg_match("/e?w+\\z/i", $string);

// matches the letter "a" followed by exactly two "t" characters
echo "\n" . preg_match("/at{2}/i", $string);

// matches a possible letter "e" followed by exactly two "t" characters
echo "\n" . preg_match("/e?t{2}/i", $string);

// matches a possible letter "a" followed by exactly 2 to 6 "t" chars (att attt atttttt)
echo "\n" . preg_match("/a?t{2,6}/i", $string);
