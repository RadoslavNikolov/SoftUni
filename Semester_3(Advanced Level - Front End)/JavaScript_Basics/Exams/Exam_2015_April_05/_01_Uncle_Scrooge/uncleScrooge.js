/**
 * Created by toshiba on 5.4.2015 г..
 */
function solve(input) {
    //console.log(input);
    var coins = 0;
    input.forEach(function(input){
        var row = input.split(' ');
        if(row[0].toLowerCase() === 'coin') {
            if(row[1].match(/\d/g)) {
                if(Number(row[1]) >= 0){
                    var isValid = true;
                    var dot = row[1].indexOf('.');
                    if(dot > -1) {
                        for (var i = dot+1; i < row[1].length; i++) {
                            if(row[1][i] != '0') {
                                isValid = false;
                                break;
                            }
                        }
                    }
                    if(isValid) {
                        coins += Number(row[1]);
                    }
                }
            }
        }
    });
    var gold = 0;
    var silver = 0;
    var bronze = 0;
    gold = Math.floor(coins/100);
    coins  = coins%100;
    silver = Math.floor(coins/10);
    coins = coins%10;
    bronze = coins;

    console.log('gold : ' + gold);
    console.log('silver : ' + silver);
    console.log('bronze : ' + bronze);
}
//var input = [ 'Coin 1',
//    'coin -2',
//    'coin 5',
//    'coin 10',
//    'coin 20',
//    'coin 50',
//    'coin 100',
//    'coin 200',
//    'coin 500',
//    'cigars 1' ];
//sumNumbers(input);
