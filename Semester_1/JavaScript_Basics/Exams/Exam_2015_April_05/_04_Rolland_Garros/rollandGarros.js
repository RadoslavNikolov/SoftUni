/**
 * Created by toshiba on 5.4.2015 г..
 */
function solve(input) {
    var players = {};
    var output = [];
    input.forEach(function(match){
        var row =  match.trim().split(/\s*:\s*/g);
        var names = row[0].trim().split(/\s*vs.\s*/g);
        var player1Name = names[0].replace(/\s+/g, ' ');
        var player2Name = names[1].replace(/\s+/g, ' ');
        var results = row[1].split(/\s+/g);
        var player1Match = 0;
        var player2Match = 0;
        var player1Sets = 0;
        var player2Sets = 0;
        var player1Games = 0;
        var player2Games = 0;
        results.forEach(function(sets){
            var line = sets.split('-');
            var x = Number(line[0]);
            var y = Number(line[1]);
            if(x > y) {
                player1Sets+=1;
            } else {
                player2Sets+=1;
            }
            player1Games += x;
            player2Games += y;
        });
        if(player1Sets > player2Sets) {
            player1Match+=1;
        } else {
            player2Match+=1;
        }

        if(!players[player1Name]) {
            players[player1Name] = {
                'name': player1Name,
                'matchesWon': Number(player1Match),
                'matchesLost': Number(player2Match),
                'setsWon': Number(player1Sets),
                'setsLost': Number(player2Sets),
                'gamesWon': Number(player1Games),
                'gamesLost': Number(player2Games)
            };
        } else {
                players[player1Name].matchesWon += player1Match;
                players[player1Name].matchesLost += player2Match;
                players[player1Name].setsWon += player1Sets;
                players[player1Name].setsLost += player2Sets;
                players[player1Name].gamesWon += player1Games;
                players[player1Name].gamesLost += player2Games;
        }

        if(!players[player2Name]) {
            players[player2Name] = {
                'name': player2Name,
                'matchesWon': Number(player2Match),
                'matchesLost': Number(player1Match),
                'setsWon': Number(player2Sets),
                'setsLost': Number(player1Sets),
                'gamesWon': Number(player2Games),
                'gamesLost': Number(player1Games)
            };
        } else {
                players[player2Name].matchesWon += player2Match;
                players[player2Name].matchesLost += player1Match;
                players[player2Name].setsWon += player2Sets;
                players[player2Name].setsLost += player1Sets;
                players[player2Name].gamesWon += player2Games;
                players[player2Name].gamesLost += player1Games;
        }
    });

    for (var key in players) {
        output.push(players[key]);
    }

    output.sort(function(a,b) {
        if(a.matchesWon !== b.matchesWon) {
            return Number(b.matchesWon) - Number(a.matchesWon);
        } else if (a.setsWon !== b.setsWon) {
            return Number(b.setsWon) - Number(a.setsWon);
        } else if (a.gamesWon !== b.gamesWon) {
            return Number(b.gamesWon) - Number(a.gamesWon);
        } else {
            return a.name.localeCompare(b.name);
        }
    });

    console.log(JSON.stringify(output));
}



//var input = [ 'Novak Djokovic vs. Roger Federer : 6-3 6-3',
//    'Roger    Federer    vs.        Novak Djokovic    :         6-2 6-3',
//    'Rafael Nadal vs. Andy Murray : 4-6 6-2 5-7',
//    'Andy Murray vs. David Ferrer : 6-4 7-6',
//    'Tomas Bedrych vs. Kei Nishikori : 4-6 6-4 6-3 4-6 5-7',
//    'Grigor Dimitrov vs. Milos Raonic : 6-3 4-6 7-6 6-2',
//    'Pete Sampras vs. Andre Agassi : 2-1',
//    'Boris Beckervs.Andre        \t\t\tAgassi:2-1' ];
//var input = ['Boris Beckervs.Andre        \t\t\tAgassi:2-1' ];
//solve(input);
