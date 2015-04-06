/**
 * Created by isrmn on 11.3.2015 г..
 */
function bitChecker(number) {
    console.log('Check if third bit is "1" \n' +'Checked number is: ' + number + '\n' + number.toString(2));
    var thirdBit = number >> 3 & 1;
    if(thirdBit) {
        console.log('true \n----------------------');
    } else {
        console.log('false \n----------------------');
    }
}
bitChecker(333);
bitChecker(425);
bitChecker(2567564754);