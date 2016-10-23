/**
 * Created by radko on 30.3.2015 г..
 */

function solve(input) {
    var output = [];
    for(var index in input) {
        output.push(input[index].split(''));

    }
    //console.log(output);

    for (var row = 0; row < input.length - 2; row++) {
        for (var col = 1; col < input[row].length; col++) {
            var char = input[row][col].toLowerCase();
            if(col + 1 < input[row+1].length &&
                col < input[row+2].length &&
                input[row+1][col - 1].toLowerCase() === char &&
                input[row+1][col].toLowerCase() === char &&
                input[row+1][col + 1].toLowerCase() === char &&
                input[row+2][col].toLowerCase() === char) {

                output[row][col] = '';
                output[row+1][col - 1] = '';
                output[row+1][col] = '';
                output[row+1][col + 1] = '';
                output[row+2][col] = '';
            }
        }
    }
    output.forEach(function(outputStr){
        console.log(outputStr.join(''));
    });

}

//var input =[
//    ['freee',
//     'eeeeeeee',
//     'eeeeeeee',
//     'yourself',
//     'freeeeee',
//     'yourselef'],
////    /////////////
////    ['888888',
////    '08*8*80',
////    '808*888',
////    '0**8*8?'],
////    ///////////////
////    ['^u^',
////    'j^l^a',
////    '^w^WoWl',
////    'adw1w6',
////    '(WdWoWgPoop)'],
////    ////////////////
////    ['puoUdai',
////    'miU',
////    'ausupirina',
////    '8n8i8',
////    'm8o8a',
////    '8l8o860',
////    'M8i8',
////    '8e8!8?!']
//];
////
//for (var str in input) {
//    sumNumbers(input[str]);
//}