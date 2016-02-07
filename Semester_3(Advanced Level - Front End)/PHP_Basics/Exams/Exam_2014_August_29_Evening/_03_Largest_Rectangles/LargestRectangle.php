<?php
$input = json_decode($_GET['jsonTable']);

list($minRow, $minCol, $maxRow, $maxCol) = findLargestRectangle($input);

printTable($input, $minRow, $minCol, $maxRow, $maxCol);

function findLargestRectangle($input) {
    $maxArea = 0;
    $result = false;
    for ($minRow = 0; $minRow < count($input); $minRow++) {
        for ($maxRow = $minRow; $maxRow < count($input); $maxRow++) {
            for ($minCol = 0; $minCol < count($input[$minRow]); $minCol++) {
                for ($maxCol = $minCol; $maxCol < count($input[$minRow]); $maxCol++) {
                    if(isRectangle($input, $minRow, $minCol, $maxRow, $maxCol)) {
                        $area = ($maxRow - $minRow+1) * ($maxCol - $minCol+1);
                        if ($area > $maxArea) {
                            $maxArea = $area;
                            $result = [$minRow, $minCol, $maxRow, $maxCol];
                        }
                    }
                }
            }
        }
    }
    return $result;
}

function isRectangle($input, $minRow, $minCol, $maxRow, $maxCol) {
    $symbol = $input[$minRow][$minCol];
    for ($col = $minCol; $col <= $maxCol; $col++) {
        if($input[$minRow][$col] != $symbol) {
            return false;
        }
        if($input[$maxRow][$col] != $symbol) {
            return false;
        }
    }

    for ($row = $minRow+1; $row < $maxRow; $row++) {
        if($input[$row][$minCol] != $symbol) {
            return false;
        }
        if($input[$row][$maxCol] != $symbol) {
            return false;
        }
    }

    return true;
}

function printTable($input, $minRow, $minCol, $maxRow, $maxCol) {
    echo "<table border='1' cellpadding='5'>";
    for ($row = 0; $row < count($input); $row++) {
        echo "<tr>";
        for ($col = 0; $col < count($input[$row]); $col++) {
            $topBorder = ($row == $minRow) && ($col >= $minCol && $col <= $maxCol);
            $bottomBorder = ($row == $maxRow) && ($col >= $minCol && $col <= $maxCol);
            $leftBorder = ($col == $minCol) && ($row >= $minRow && $row <= $maxRow);
            $rightBorder = ($col == $maxCol) && ($row >= $minRow && $row <= $maxRow);
            if($topBorder || $bottomBorder || $leftBorder || $rightBorder) {
                echo "<td style='background:#CCC'>";
            } else {
                echo "<td>";
            }
            echo htmlspecialchars($input[$row][$col]) . "</td>";
        }

        echo "</tr>";
    }

    echo "</table>";
}