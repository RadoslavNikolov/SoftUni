<?php
/*** a simple string ***/
$string = 'I live in the white house';

/*** try to match white not followed by house ***/
if(preg_match("/white+(?!house)/i", $string))
{
    /*** if we find the word white, not followed by house ***/
    echo 'Found a match';
}
else
{
    /*** if no match is found ***/
    echo 'No match found';
}



$string = 'This is an example eg: foo';

/*** try to match eg followed by a colon ***/
if(preg_match("/eg+(?=:)/", $string, $match))
{
    print_r($match);
}
else
{
    echo 'No match found';
}


$string = 'I live in the whitehouse';

/*** try to match house preceded by white ***/
if(preg_match("/(?<=white)house/i", $string))
{
    /*** if we find the word white, not followed by house ***/
    echo 'Found a match';
}
else
{
    /*** if no match is found ***/
    echo 'No match found';
}

/*** get the host name from a url ***/
preg_match('#^(?:http://)?([^/]+)#i', "http://www.phpro.org/tutorials", $matches);

/*** show the host name ***/
echo "\n" . $matches[1];

