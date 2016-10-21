/**
 * Created by radko on 20.3.2015 г..
 */
function solve(input) {
    var bill = parseFloat(input[0]);
    var mood = input[1];
    //console.log(mood);
    var tip;
    switch(mood) {
        case 'happy': tip = (bill*0.1).toFixed(2); break;
        case 'married': tip = (bill*0.0005).toFixed(2); break;
        case 'drunk': tip = drunkChange(bill); break
        default : tip = (bill * 0.05).toFixed(2); break;
    }
    console.log(tip);

    function drunkChange(bill) {
        var tip = bill * 0.15;
        tip = Math.pow(tip,tip.toString()[0]);
        return tip.toFixed(2);
    }

}
//sumNumbers([1242192.33,'married'])