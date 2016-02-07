/**
 * Created by isrmn on 16.3.2015 г..
 */
function findcardFrequency(input) {
    var output = {};
    var cardsArr = input.split(/\W+/).filter(function(v) {
        return v !== '';
    });
    console.log(cardsArr);
    for (var i = 0; i < cardsArr.length; i++) {
        var temp = cardsArr[i];
        if(output['_' + cardsArr[i]]) {
            output['_' + cardsArr[i]]++;
        } else {
            output['_' + cardsArr[i]] = 1;
        }
    }
    console.log(output);
    for(var key in output) {
        console.log(key.substring(1,key.length) + ' -> ' + ((output[key]/cardsArr.length)*100).toFixed(2) + '%');
    }
    console.log('------------------------------');

}
findcardFrequency('8♥ 2♣ 4♦ 10♦ J♥ A♠ K♦ 10♥ K♠ K♦');
findcardFrequency('J♥ 2♣ 2♦ 2♥ 2♦ 2♠ 2♦ J♥ 2♠');
findcardFrequency('10♣ 10♥');