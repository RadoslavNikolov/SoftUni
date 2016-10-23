/**
 * Created by isrmn on 12.3.2015 г..
 */
function solve(arr) {
    var output = arr.slice();
    //console.log(output)

    for (var i = 0; i < arr.length - 1; i++) {
        for (var j = 0; j < arr[i].length; j++) {
            var letter = arr[i][j];
            var leftIndex = j - 1;
            var rightIndex = j + 1;
            if (leftIndex >= 0 && rightIndex < arr[i + 1].length) {
                var tempStr = arr[i + 1].substring(leftIndex, rightIndex + 1);
                if (tempStr.replace(new RegExp(letter, 'g'), '') === '') {
                    output[i] = output[i].substring(0, j) + '*' + output[i].substring(j + 1, output[i].lengthl);
                    for (var k = leftIndex; k <= rightIndex; k++) {
                        output[i + 1] = output[i + 1].substring(0, k) + '*' + output[i + 1].substring(k + 1, output[i + 1].lengthl);

                    }
                }
            }
        }
    }
    return output.join('\n');
}

console.log(solve(['abcdexgh', 'bbbdxxxh', 'abcxxxxx']));
//console.log(sumNumbers(['ax', 'xxx', 'b','bbb','bbbb']));