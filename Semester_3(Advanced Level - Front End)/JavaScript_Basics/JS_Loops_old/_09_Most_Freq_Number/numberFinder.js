/**
 * Created by toshiba on 13.3.2015 г..
 */
function findMostFreqNum(inputArr) {
    var processedArr = {};
    for (var i = 0; i < inputArr.length; i++) {
        var key = inputArr[i].toString();
        if(processedArr.hasOwnProperty(key)) {
            processedArr[key]++;
        } else {
            processedArr[key] = 1;
        }
    }
    //console.log(processedArr);

    var frequency = Number.MIN_VALUE;
    var number;
    for ( var key in processedArr ) {
        if(processedArr[key] > frequency) {
            frequency = processedArr[key];
            number = key;
        }
    }
    console.log(number + ' (' + frequency + ' times)')
}

findMostFreqNum([4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3]);
findMostFreqNum([2, 1, 1, 5, 7, 1, 2, 5, 7, 3, 87, 2, 12, 634, 123, 51, 1]);
findMostFreqNum([1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13]);

