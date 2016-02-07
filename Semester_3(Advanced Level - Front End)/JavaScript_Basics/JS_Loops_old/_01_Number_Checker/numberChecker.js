/**
 * Created by toshiba on 11.3.2015 г..
 */
function printNumber(range) {
    var outputStr = '';
    if(range < 1) {
        console.log('no');
    } else {
        for (var i = 1; i <= range; i++) {
            if((i % 4 != 0) && (i % 5 != 0)) {
                outputStr += (i + ', ');
            }
        }
        console.log(outputStr.substring(0,outputStr.length - 2));
    }
}
printNumber(20);
printNumber(-5);
printNumber(13);