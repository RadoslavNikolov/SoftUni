/**
 * Created by isrmn on 17.3.2015 г..
 */
function solve(input) {
    //console.log(input);
    var result = {};
    for(var key in input) {
        var row = input[key].split(/\/|:|-/g);
        //console.log(row);
        var team1 = row[0].trim();
        var team2 = row[1].trim();
        var team1Score = Number(row[2]);
        var team2Score = Number(row[3]);
        if(!result[team1]) {
            result[team1] = {
                'goalsScored': team1Score,
                'goalsConceded': team2Score,
                'matchesPlayedWith': [team2]
            };
        } else {
            result[team1].goalsScored += team1Score;
            result[team1].goalsConceded += team2Score;

            if(result[team1].matchesPlayedWith.indexOf(team2) === -1){
                result[team1].matchesPlayedWith.push(team2);
            }
        }
        if(!result[team2]) {
            result[team2] = {
                'goalsScored': team2Score,
                'goalsConceded': team1Score,
                'matchesPlayedWith': [team1]
            };
        } else {
            result[team2].goalsScored += team2Score;
            result[team2].goalsConceded += team1Score;

            if(result[team2].matchesPlayedWith.indexOf(team1) === -1){
                result[team2].matchesPlayedWith.push(team1);
            }
        }
    }

    //sorting processed obj
    var tempArr = [];
    var ouputObj = {};
    for(var key in result) {
        result[key].matchesPlayedWith.sort();
        tempArr.push(key);
    }
    tempArr.sort(function(a, b) { return a.toLowerCase().localeCompare(b.toLowerCase()); });
    tempArr.forEach(function(key){ ouputObj[key] = result[key]; });

    console.log(JSON.stringify(ouputObj));
}


var input = [
    ['Germany / Argentina: 1-0',
        'Brazil / Netherlands: 0-3',
        'Netherlands / Argentina: 0-0',
        'Brazil / Germany: 1-7',
        'Argentina / Belgium: 1-0',
        'Netherlands / Costa Rica: 0-0',
        'France / Germany: 0-1',
        'Brazil / Colombia: 2-1']
];

for (var str in input) {
    solve(input[str]);
}