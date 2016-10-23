/**
 * Created by isrmn on 16.3.2015 г..
 */
function solve(input) {
    var outputArr = [];
    var command = input[0].substring(7,input[0].length-1);
    var preFilledArray = equalElementLenght(input);
    switch(parseInt(command)%360) {
        case 0:  outputArr = strRotate_0(preFilledArray); break;
        case 90: outputArr = strRotate_90(preFilledArray); break;
        case 180: outputArr = strRotate_180(preFilledArray); break;
        case 270: outputArr = strRotate_270(preFilledArray); break;
        default : break;
    }
    for (var i = 0; i < outputArr.length; i++) {
        console.log(outputArr[i]);

    }



    function strRotate_0(inputArr) {
        var outputArr = [];
        for (var i  = 0; i < inputArr.length; i++) {
            var tempStr = '';
            for (var j = 0; j < inputArr[0].length; j++) {
                tempStr += inputArr[i][j];
            }
            outputArr.push(tempStr);
        }
        return outputArr;
    }
    function strRotate_90(inputArr) {
        var outputArr = [];
        for (var i = 0; i < inputArr[0].length; i++) {
            var tempStr = '';
            for (var j = inputArr.length-1; j >= 0; j--) {
                //var tempInput = inputArr[j];
                tempStr += inputArr[j][i];
            }
            outputArr.push(tempStr);
        }
        return outputArr;
    }
    function strRotate_180(inputArr) {
        var outputArr = [];
        for (var i  = inputArr.length-1; i >= 0; i--) {
            var tempStr = '';
            for (var j = inputArr[0].length-1; j >= 0; j--) {
                tempStr += inputArr[i][j];
            }
            outputArr.push(tempStr);
        }
        return outputArr;
    }
    function strRotate_270(inputArr) {
        var outputArr = [];
        for (var i = inputArr[0].length-1; i >= 0; i--) {
            var tempStr = '';
            for (var j = 0; j < inputArr.length; j++) {
                tempStr += inputArr[j][i];
            }
            outputArr.push(tempStr);
        }
        return outputArr;
    }


    function equalElementLenght(inputArr) {
        var maxElementLenght = 0;
        for (var i = 1; i < inputArr.length; i++) {
            if(inputArr[i].length > maxElementLenght) {
                maxElementLenght = inputArr[i].length;
            }
        }
        var processedArray = [];
        for (var i = 1; i < inputArr.length; i++) {
            var tempString = inputArr[i];
            for (var j = tempString.length; j < maxElementLenght; j++) {
                tempString = tempString + ' ';
            }
            processedArray.push(tempString);
        }
        return processedArray;
    }
}

//var input = [
//    ['Rotate(0)','hello','softuni','exam'],
//    ['Rotate(180)','hello','softuni','exam'],
//    ['Rotate(270)','hello','softuni','exam']
//];
//for(var str in input) {
//    sumNumbers(input[str]);
//}