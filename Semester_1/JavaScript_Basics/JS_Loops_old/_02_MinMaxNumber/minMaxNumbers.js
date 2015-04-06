/**
 * Created by toshiba on 11.3.2015 г..
 */
function findMinAndMax(dataArr) {
    var minNumber = Number.MAX_VALUE;
    var maxNumber = Number.MIN_VALUE;
    dataArr.forEach(function(number) {
        if(number < minNumber) {
            minNumber = number;
        }
        if(number > maxNumber) {
            maxNumber = number;
        }
    });
    console.log('Min -> ' + minNumber + '\nMax -> ' + maxNumber);
}

findMinAndMax([1, 2, 1, 15, 20, 5, 7, 31]);
findMinAndMax([2, 2, 2, 2, 2]);
findMinAndMax([500, 1, -23, 0, -300, 28, 35, 12]);