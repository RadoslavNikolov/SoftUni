<?php
    if(isset($_GET['inputField'], $_GET['choice'], $_GET['submit'])){
        $inputStr = $_GET['inputField'];
        $output = '';
        switch($_GET['choice']) {
            case 'palindrome': $output = checkPalindrome($inputStr); break;
            case 'reverse': $output = stringReverse($inputStr); break;
            case 'split': $output = stringSplit($inputStr); break;
            case 'hash': $output = stringHash($inputStr); break;
            case 'shuffle': $output = stringShuffle($inputStr); break;
            default: break;
        }
    }

function checkPalindrome($str) {
    if(strtolower($str) === strrev(strtolower($str))) {
        $output = $str . "is a palindrome!";
        return $output;
    }
    $output = $str . "is not a palindrome!";
    return $output;
}

function stringReverse($str) {
    return strrev($str);
}

function stringSplit($str){
    $strArr = str_split($str);
    return implode(' ',$strArr);
}
function stringHash($str) {
    return crypt($str,'$2a$07$usesomesillystringforsalt$');
}

function stringShuffle($str) {
    return str_shuffle($str);
}
?>

<!doctype html >
<html lang = "en" >
<head >
<meta charset = "UTF-8" >
<title >Modify String</title >
</head >
<body >
    <div id="wrapper">
        <form action="">
        <input type="text" id="inputField" name="inputField" placeholder="Enter string" required="true"/><br>
        <input type="radio" id="palindrome" name="choice" value="palindrome" required="true"/>
        <label for="palindrome">Check Palindrome</label>
        <input type="radio" id="reverse-string" name="choice" value="reverse"/>
        <label for="reverse-string">Reverse String</label>
        <input type="radio" id="split-string" name="choice" value="split"/>
        <label for="split-string">Split</label>
        <input type="radio" id="hash-string" name="choice" value="hash"/>
        <label for="hash-string">Hash String</label>
        <input type="radio" id="shuffle-string" name="choice" value="shuffle"/>
        <label for="shuffle-string">Shuffle String</label>
        <input type="submit" name="submit"/>
        </form>
        <?php if(isset($output)): ?>
        <h2><?= $output ?></h2>
        <?php endif ?>
    </div>
</body >
</html >