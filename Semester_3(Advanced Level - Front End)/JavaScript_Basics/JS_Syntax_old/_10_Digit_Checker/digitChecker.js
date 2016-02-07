/**
 * Created by isrmn on 11.3.2015 г..
 */
function checkDigit(number) {
    console.log('Check if third digit in ' + number + ' is "3"');
    return parseInt((number % 1000) / 100) == 3;
}
console.log(checkDigit(1235));
console.log(checkDigit(25368));
console.log(checkDigit(123456));

