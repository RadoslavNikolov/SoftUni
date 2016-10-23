/**
 * Created by toshiba on 5.4.2015 г..
 */
function solve(input) {
    var possibleJumps = Number(input[0]);
    var trackLenght = Number(input[1]);
    var winner = '';
    var hasWinner = false;
    var players = [];
    for (var i = 2; i < input.length; i++) {
        var row = input[i].split(', ');
        players.push({
            'name': row[0],
            'jump': Number(row[1]),
            'position': 0
        });
    }
    for (var i = 1; i <= possibleJumps; i++) {
        if(!hasWinner){
            players.forEach(function(player){
                if(!hasWinner) {
                    player.position += player.jump;
                    if(player.position >= trackLenght-1) {
                        winner = player.name;
                        player.position = trackLenght-1;
                        hasWinner = true;
                    }
                }
            });
        }
    }
    if(!hasWinner) {
        var winnerPos = 0;
        players.forEach(function(player){
            if(player.position >= winnerPos) {
                winner = player.name;
                winnerPos = player.position;
            }
        });
    }
    var zeroLine = '';
    for (var i = 0; i < trackLenght; i++) {
        zeroLine += '#';
    }
    console.log(zeroLine + '\n' + zeroLine);
    players.forEach(function(player){
        var line = '';
        for (var i = 0; i < trackLenght; i++) {
            if(i === player.position) {
                line += player.name.charAt(0).toUpperCase();

            } else {
                line += '.';
            }
        }
        console.log(line);
    });
    console.log(zeroLine + '\n' + zeroLine);
    console.log('Winner: ' + winner);
    //console.log(players);
}

//var input = ['10','19','angel, 10','Boris, 10','Georgi, 3','Dimitar, 7'];
//sumNumbers(input);