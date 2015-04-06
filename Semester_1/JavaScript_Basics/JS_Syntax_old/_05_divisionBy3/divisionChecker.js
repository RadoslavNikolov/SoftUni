/**
 * Created by isrmn on 11.3.2015 г..
 */
function divisionBy3(number) {
    var sumOfDigits = 0;
    while (number > 9) {
        sumOfDigits += number%10;
        number/=10;
        number = parseInt(number);
    }
    sumOfDigits+=number;
    if(sumOfDigits % 3 == 0) {
        console.log("the number is divided by 3 without remainder");
    } else {
        console.log("the number is not divided by 3 without remainder");
    }
}
divisionBy3(12);
divisionBy3(188);
divisionBy3(591);