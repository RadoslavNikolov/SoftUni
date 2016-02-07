/**
 * Created by isrmn on 10.3.2015 г..
 */
function roundNumber(number) {
    var round = Math.round(number);
    var floor = Math.floor(number);
    console.log(number + " round = " + round);
    console.log(number + " floor = " + floor + "\n----------------------");
}

roundNumber(22.7);
roundNumber(12.3);
roundNumber(58.7);