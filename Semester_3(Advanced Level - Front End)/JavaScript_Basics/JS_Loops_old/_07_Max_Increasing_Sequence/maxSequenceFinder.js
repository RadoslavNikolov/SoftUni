/**
 * Created by isrmn on 13.3.2015 г..
 */
function findMaxSequence(inputArr) {
    var index = 0;
    var numIncreasingElements = 0;
    var count = 1;
    for (var i = 1; i < inputArr.length; i++) {
        if(inputArr[i] > inputArr[i-1]) {
            count++;
            if(i === inputArr.length-1) {
                index = i-count + 1;
                numIncreasingElements = count;
                count = 1;
            }
        } else {
            if(count >= numIncreasingElements) {
                index = i-count;
                numIncreasingElements = count;
                count = 1;
            } else {
                count = 1;
            }
        }
    }
    if(numIncreasingElements === 1) {
        console.log('no');
    } else {
        var output = inputArr.slice(index,(index + numIncreasingElements ));
        console.log(output);
    }
}

findMaxSequence([3, 2, 3, 4, 2, 2, 4]);
findMaxSequence([3, 5, 4, 6, 1, 2, 3, 6, 10, 32]);
findMaxSequence([3, 2, 1]);
findMaxSequence([2, 1, 1, 2, 3, 3, 2, 2, 2, 1]);
