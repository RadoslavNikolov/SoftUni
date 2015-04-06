/**
 * Created by toshiba on 24.3.2015 г..
 */
function solve(input) {
    var output = [];
    for(var index in input) {
        output.push(input[index].split(''));

    }
    //console.log(output);

    for (var row = 0; row < input.length - 2; row++) {
        for (var col = 0; col <input[row].length-2; col++) {
            var char = input[row][col].toLowerCase();
            if(col + 1 < input[row+1].length &&
                col + 2 < input[row+2].length &&
                input[row][col + 2].toLowerCase() === char &&
                input[row+1][col + 1].toLowerCase() === char &&
                input[row+2][col].toLowerCase() === char &&
                input[row+2][col +2].toLowerCase() === char) {

                output[row][col] = '';
                output[row][col + 2] = '';
                output[row+1][col + 1] = '';
                output[row+2][col] = '';
                output[row+2][col +2] = '';
            }
        }
    }
    output.forEach(function(outputStr){
        console.log(outputStr.join(''));
    });

}


//var input = [
//    ['abnbjs',
//     'xoBab',
//     'Abmbh',
//     'aabab',
//     'ababvvvv'],
//    /////////////
//    ['888888',
//    '08*8*80',
//    '808*888',
//    '0**8*8?'],
//    ///////////////
//    ['^u^',
//    'j^l^a',
//    '^w^WoWl',
//    'adw1w6',
//    '(WdWoWgPoop)'],
//    ////////////////
//    ['puoUdai',
//    'miU',
//    'ausupirina',
//    '8n8i8',
//    'm8o8a',
//    '8l8o860',
//    'M8i8',
//    '8e8!8?!']
//];
//
//for (var str in input) {
//    solve(input[str]);
//}