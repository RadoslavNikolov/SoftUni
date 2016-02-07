<?php
    $input=$_GET['text'];
    $minFontSize = intval($_GET['minFontSize']);
    $maxFontSize = intval($_GET['maxFontSize']);
    $step = intval($_GET['step']);
    $currSize = $minFontSize;
    $increment = true;
    $decoration = '';


    for ( $i = 0; $i < strlen($input); $i++) {
      if(ord($input[$i])%2 == 0) {
          $decoration = 'text-decoration:line-through;';
      } else {
          $decoration = '';
      }

      echo "<span style='font-size:{$currSize};{$decoration}'>" . htmlspecialchars($input[$i]) . "</span>";
        $isLetter = isLetter ($input[$i]);
//        var_dump($isLetter);
//        var_dump($currSize);

        if($isLetter) {
            if($increment) {
                $currSize += $step;
            } else {
                $currSize -= $step;
            }
        }

        if($isLetter && ($currSize >= $maxFontSize || $currSize <= $minFontSize)) {
            $increment = !$increment;
        }
    }

    function isLetter($letter) {
        return preg_match("/[a-zA-Z]/",$letter);
    }
?>

