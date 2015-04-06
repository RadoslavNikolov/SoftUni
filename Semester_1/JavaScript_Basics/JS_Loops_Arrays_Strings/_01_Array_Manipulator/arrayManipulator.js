/**
 * Created by isrmn on 17.3.2015 г..
 */
function manipulateArray(input) {
    var numberArray = input.filter(function(v){
        if(!isNaN(v)) {
            return v.toString();
        }
    });
    var min = Number.MAX_VALUE;
    var max = Number.MIN_VALUE;
    var tempObj = {};
    for(var elem in numberArray) {
        if(numberArray[elem] < min){
            min = numberArray[elem]
        }
        if(numberArray[elem] > max) {
            max = numberArray[elem]
        }
        if(!tempObj.hasOwnProperty(numberArray[elem])) {
            tempObj[numberArray[elem]] = 1;
        } else {
            tempObj[numberArray[elem]]++;
        }
    }
    numberArray.sort(function(a,b){
        return a < b;
    });
    var maxFreq = 0;
    var mostFreqNumber = '';
    for(var key in tempObj) {
        if(tempObj[key] > maxFreq) {
            maxFreq = tempObj[key];
            mostFreqNumber = key.toString();
        }
    }

    console.log('Min number: ' + min + '\nMax number: ' + max + '\nMost frequent number: ' + mostFreqNumber + '\n[' + numberArray.join(', ') + ']');
}

manipulateArray(["Pesho", 2, "Gosho", 12, 2, "true", 9, undefined, 0, "Penka", { bunniesCount : 10}, [10, 20, 30, 40]]);

