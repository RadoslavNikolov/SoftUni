/**
 * Created by isrmn on 13.3.2015 г..
 */
function findMaxSequence(inputArr) {
    var index = 0;
    var numEqualElements = 1;
    var count = 1;
    for (var i = 1; i < inputArr.length; i++) {
        if(inputArr[i] === inputArr[i-1]) {
            count++;
        } else {
            if(count >= numEqualElements) {
                index = i-count;
                numEqualElements = count;
                count = 1;
            } else {
                count = 1;
            }
        }
    }
    if(numEqualElements === 1) {
        var output = inputArr.slice(inputArr.length-1,inputArr.length);
    } else {
        var output = inputArr.slice(index,(index + numEqualElements ));
    }
    console.log(output);
}

findMaxSequence([2, 1, 1, 2, 3, 3, 2, 2, 2, 1]);
findMaxSequence(['happy']);
findMaxSequence([2, 'qwe', 'qwe', 3, 3, '3']);
findMaxSequence([3, 2, 3, 4, 2, 2, 4]);
findMaxSequence([3, 5, 4, 6, 1, 2, 3, 6, 10, 32]);