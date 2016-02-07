/**
 * Created by toshiba on 13.3.2015 г..
 */
function reverseString(input) {
    var output = [];
    for (var i = 0, j = input.length-1; i < input.length; i++,j--) {
        output[i] = input [j];
    }
    console.log(output.join(''));
}

reverseString('sample');
reverseString('softUni');
reverseString('java script');