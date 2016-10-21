/**
 * Created by isrmn on 21.3.2015 г..
 */
function solve(input) {
    var stars = {};
    var coordX = Number(input[3].split(' ')[0]);
    var coordY = Number(input[3].split(' ')[1]);
    var numOfMoves = Number(input[4]);
    for (var i = 0; i < 3; i++) {
        var row = input[i].split(' ');
        var name = 'star' + (i+1);
        stars[name] = { 'name': row[0].toLowerCase(), 'x': Number(row[1]), 'y': Number(row[2])};
    }
    //console.log(stars);
    //console.log(coordX,coordY,numOfMoves);
    for (var i = 0; i <= numOfMoves; i++,coordY++) {
        console.log(checkShipPosition());
    }
    function checkShipPosition() {
        for (var i = 1; i < 4; i++) {
            var starName = 'star' + i;
            if(coordX >= stars[starName].x - 1 && coordX <= stars[starName].x + 1 && coordY >= stars[starName].y -1 && coordY <= stars[starName].y + 1 ) {
                return stars[starName].name;
            }
        }
        return 'space';

    }
}


//var input = [
//    ['Sirius 3 7',
//     'Alpha-Centauri 7 5',
//     'Gamma-Cygni 10 10',
//     '8 1',
//     '6'],
//     ['Terra-Nova 16 2',
//     'Perseus 2.6 4.8',
//     'Virgo 1.6 7',
//     '2 5',
//     '4'
//     ]
//];
//
//for (var str in input) {
//    sumNumbers(input[str]);
//}