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
    var ouputObj = {};
    for(var key in result) {
        result[key].matchesPlayedWith.sort();
    }
    var tempArr = Object.keys(result).sort();
    tempArr.forEach(function(key){ ouputObj[key] = result[key]; });

    console.log(JSON.stringify(ouputObj));
}


//var input = [
//    ['Levski / CSKA: 0-2',
//        'Pavlikeni / Loko Gorna: 4-2',
//        'Loko Gorna / Levski: 1-4',
//        'Litex / Loko Gorna: 0-0',
//        'Beroe / Botev Plovdiv: 2-1',
//        'Loko Gorna / Beroe: 3-1',
//        'Pavlikeni / Ludogorets: 0-2',
//        'Loko Sofia / Litex: 0-2',
//        'Pavlikeni / Marek: 1-1',
//        'Litex / Levski: 0-0',
//        'Beroe / Litex: 3-2',
//        'Litex / Beroe: 1-0',
//        'Ludogorets / Litex: 3-0',
//        'Litex / Ludogorets: 1-0',
//        'CSKA / Beroe: 1-0',
//        'Botev Plovdiv / CSKA: 1-1',
//        'Ludogorets / Loko Sofia: 1-0',
//        'Litex / CSKA: 0-1',
//        'Marek / Haskovo: 0-1',
//        'Levski / Loko Gorna: 1-1'
//    ]
//];
//
//for (var str in input) {
//    sumNumbers(input[str]);
//}