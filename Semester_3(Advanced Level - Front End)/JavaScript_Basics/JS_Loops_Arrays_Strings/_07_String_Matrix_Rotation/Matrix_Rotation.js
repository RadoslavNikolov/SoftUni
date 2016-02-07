/**
 * Created by isrmn on 16.3.2015 г..
 */
function solve(input) {
    var outputArr = [];
    var command = input[0].substring(7,input[0].length-1);
    var preFilledArray = equalElementLenght(input);
    switch(parseInt(command)%360) {
        case 90: outputArr = strRotate_90(preFilledArray); break;
        //case 180: outputArr = strRotate_180(input); break;
        //case 270: outputArr = strRotate_270(input); break;
        default : break;
    }
    for (var i = 0; i < outputArr.length; i++) {
        console.log(outputArr[i]);

    }




    function strRotate_90(inputArr) {
        var outputArr = [];
        for (var i = 0; i < inputArr[0].length; i++) {
            var tempStr = '';
            for (var j = inputArr.length-1; j >= 0; j--) {
                var tempInput = inputArr[j];
                tempStr += tempInput[i];
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
                tempString = tempString + '*';
            }
            processedArray.push(tempString);
        }
        return processedArray;
    }
}

var input = [
    ['Rotate(90)','hello','softuni','exam'],
    ['Rotate(180)','hello','softuni','exam'],
    ['Rotate(270)','hello','softuni','exam']
];
for(var str in input) {
    solve(input[str]);
}