/**
 * Created by isrmn on 21.3.2015 г..
 */
function solve(input) {
    var strArr = input[0].split(/\s+/g);
    for (var i = 1; i < input.length; i++) {
        var output = [];
        strArr.forEach(function(word){
            if(word.toLowerCase().indexOf(input[i].toLowerCase()) !== -1 ){
                output.push(word);
            }
        });
        console.log(sortOutput(output));
    }

    function sortOutput(inputArr) {
        var shortest = Number.MAX_VALUE;
        var shortestWord = '';
        var shortestWordsArr = [];
        inputArr.forEach(function(word){
            if(word.length < shortest) {
                shortest = word.length;
            }
        });
        var count=0;
        inputArr.forEach(function(word){
            if(word.length === shortest) {
                shortestWord = word;
                count++;
                shortestWordsArr.push(word);
            }
        });
        if(count === 1) {
            return shortestWord;
        } else if(count > 1){
            shortestWordsArr.sort();
            return shortestWordsArr[0];
        }
        return '-';
    }
}
//sumNumbers(['word screammm screech speech wolf',
//        'bas',
//        'wo',
//        'scr',
//        's']
//);
//sumNumbers(['firefox mozilla gecko webKit lord battery skype',
//    'firf',
//    'fire',
//    'momo',
//    'skyp',
//'lord',
//'webk']);