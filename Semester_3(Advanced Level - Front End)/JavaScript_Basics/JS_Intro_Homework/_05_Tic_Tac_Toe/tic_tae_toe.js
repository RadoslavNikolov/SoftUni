/**
 * Created by toshiba on 16.2.2015 г..
 */
var matrix = [[0,0,0], [0,0,0], [0,0,0]];
var count = 1;

function gamePlay(id) {
    var i = Math.floor(id/10)-1;
    var j = Math.floor(id%10)-1;
    if(matrix[i][j]== 0) {
        if(count%2!=0) {
            matrix[i][j] = 1;
            document.getElementById(id).value = "O";
            document.getElementById(id).disabled = true;
            count++;

        } else {
            matrix[i][j] = 2;
            document.getElementById(id).value = "X";
            document.getElementById(id).disabled = true;
            count++;
        }
        //checkForWinner();
    }
    checkForWinner();

}

function checkForWinner() {
    for (var i = 0; i < 3; i++) {
        if((matrix[i][0] != 0) && (matrix[i][1] != 0) && (matrix[i][2] != 0)) {
            if((matrix[i][0] == matrix[i][1]) && (matrix[i][0] == matrix[i][2])) {
                for (var j = 1; j < 4; j++) {
                    var id = "" + (i + 1) + j;
                    document.getElementById(id).style.color = "#07c901";
                }
                setDisplay();
            }
        }
    }
    for (var i = 0; i < 3; i++) {
        if((matrix[0][i] != 0) && (matrix[1][i] != 0) && (matrix[2][i] != 0)) {
            if((matrix[0][i] == matrix[1][i]) && (matrix[0][i] == matrix[2][i])) {
                for (var j = 1; j < 4; j++) {
                    var id = "" + j + (i + 1);
                    document.getElementById(id).style.color = "#07c901";
                }
                setDisplay();
            }
        }
    }
    if((matrix[0][0] != 0) && (matrix[1][1] != 0) && (matrix[2][2] != 0)) {
        if((matrix[0][0] == matrix[1][1]) && (matrix[0][0] == matrix[2][2])) {
            for (var j = 1; j < 4; j++) {
                var id = "" + j + j;
                document.getElementById(id).style.color = "#07c901";
            }
            setDisplay();
        }
    }
    if((matrix[0][2] != 0) && (matrix[1][1] != 0) && (matrix[2][0] != 0)) {
        if((matrix[0][2] == matrix[1][1]) && (matrix[0][2] == matrix[2][0])) {
            for (var j = 1; j < 4; j++) {
                var id = "" + j + (4-j);
                document.getElementById(id).style.color = "#07c901";
            }
            setDisplay();
        }
    }
}

function setDisplay() {
    for (var i = 0; i < 3; i++) {
        for (var j = 0; j < 3; j++) {
            if(matrix[i][j] == 0) {
                var id = "" + (i+1) + (j+1);
                document.getElementById(id).disabled = true;
            }
        }
    }
    if(count%2 == 0) {
        var result = "O win the game!!!";
    } else {
        var result = "X win the game!!!";
    }
    document.getElementById("winnerDIV").innerText = result;
}