/**
 * Created by radko on 19.3.2015 г..
 */
function solve(input) {
    //console.log(input);
    var  maxSum = -555550000000000000;
    var maxSumString = '';
    var count = 0;

    var pattern = /<tr><td>.*<\/td><td>(.*)<\/td><td>(.*)<\/td><td>(.*)<\/td><\/tr>/g;
    for (var i = 2; i < input.length-1; i++) {
        var tempSum = 0;
        var tempStr = '';
        while(row = pattern.exec(input[i])) {
            //console.log(row);
            for (var j = 1; j < 4; j++) {
                if(!isNaN(row[j])) {
                    tempSum += parseFloat(row[j]);
                    tempStr =  tempStr + row[j] + ' + ';
                    count++;
                }
            }
        }
        if(tempSum > maxSum) {
            maxSum = tempSum;
            maxSumString = tempStr;
        }
    }
    //console.log(maxSum);
    //console.log(maxSumString);
    if(count === 0){
        console.log('no data');
    } else {
        console.log(maxSum + ' = ' + maxSumString.substring(0,maxSumString.length-3));
    }


}

//var input = [
//    ['<table>',
//     '<tr><th>Town</th><th>Store1</th><th>Store2</th><th>Store3</th></tr>',
//     '<tr><td>Sofia</td><td>26.2</td><td>8.20</td><td>-</td></tr>',
//     '<tr><td>Varna</td><td>11.2</td><td>18.00</td><td>36.10</td></tr>',
//     '<tr><td>Plovdiv</td><td>17.2</td><td>12.3</td><td>6.4</td></tr>',
//     '<tr><td>Bourgas</td><td>-</td><td>24.3</td><td>-</td></tr>',
//     '</table>']
//];
//var input = [
//    ['<table>',
//    '<tr><th>Town</th><th>Store1</th><th>Store2</th><th>Store3</th></tr>',
//    '<tr><td>Pleven</td><td>-100</td><td>-200</td><td>-</td></tr>',
//    '<tr><td>Varna</td><td>-100</td><td>-</td><td>-300</td></tr>',
//    '<tr><td>Rousse</td><td>-</td><td>-200</td><td>-100</td></tr>',
//    '</table>']
//];
//for (var str in input) {
//    solve(input[str]);
//}

