<?php
    $recipient = htmlspecialchars($_GET['recipient']);
    $subject = htmlentities($_GET['subject']);
    $body = htmlspecialchars($_GET['body']);
    $key = $_GET['key'];

//$recipient = "info@softuni.bg";
//$subject = "SoftUniConf <2014>";
//$body = htmlspecialchars("SoftUniConf <2014> is coming.<a href='https://softuni.bg/SoftUniConf'>Learn more</a>");
//$key = "s3cr3t!";

    $output =
        "<p class='recipient'>$recipient</p>" .
        "<p class='subject'>$subject</p>" .
        "<p class='message'>$body</p>";
//        echo $output;
    $encryptedEmail = implode("|", encryptEmail($output,$key));
    $encryptedEmail = "|" . $encryptedEmail . "|";
    echo $encryptedEmail;

function encryptEmail($str,$key) {
    $outputArr = [];
    $count = 0;
    for ($i = 0; $i < strlen($str); $i++) {
      if($count >= strlen($key)){
          $count = 0;
      }
        $outputArr[] = dechex(ord($str[$i]) * ord($key[$count]));
        $count++;
    }
    return $outputArr;
}
