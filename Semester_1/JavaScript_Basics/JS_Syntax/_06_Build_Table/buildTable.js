/**
 * Created by toshiba on 11.3.2015 г..
 */
function fillTribunacciArr(end) {
    var tribunacciArr = [];
    var temp1 = 1;
    var temp2 = 0;

    for (var i = 0; i <= end; i++)
    {
        tribunacciArr.push(temp2);
        temp2 = temp2 + temp1;
        temp1 = temp2 - temp1;
        if(temp2 > end) {
            break;
        }
    }
    return tribunacciArr;
}
function checkForFibunacciNum(fillTribunacciArr,number) {
    var isFibunacci = false;
    for (var i = 0; i < fillTribunacciArr.length; i++) {
        if(fillTribunacciArr[i] == number) {
            isFibunacci = true;
            break;
        }
    }
    if(isFibunacci) {
        return "yes";
    } else {
        return "no";
    }
}

function buildTable(start, end) {
    var tribunacciArr = fillTribunacciArr(end);

    var outputStr = '<table>\n<tr><th>Num</th><th>Square</th><th>Fib</th></tr>\n';
    for (var i = start; i <= end; i++) {
        var isFib = checkForFibunacciNum(tribunacciArr,i);
        outputStr += '<tr><td>' + i + '</td><td>' + (i*i) + '</td><td>' + isFib + '</td></tr>\n';
    }
    outputStr += '</table>';
    console.log(outputStr);
}

buildTable(2,6);
console.log('****************');
buildTable(55,56);


