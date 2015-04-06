/**
 * Created by toshiba on 13.3.2015 г..
 */
function sortArray(inputArr) {
    var firstElement;
    var temp;
    for (var i = inputArr.length-1; i > 0; i--) {
        firstElement = 0;
        for (var j = 1; j <= i; j++) {
            if(inputArr[j] > inputArr[firstElement]) {
                firstElement = j;
            }
        }
        temp = inputArr[firstElement];
        inputArr[firstElement] = inputArr[i];
        inputArr[i] = temp;
    }
    console.log(inputArr.join(', '));
}

sortArray([5, 4, 3, 2, 1]);
sortArray([12, 12, 50, 2, 6, 22, 51, 712, 6, 3, 3]);