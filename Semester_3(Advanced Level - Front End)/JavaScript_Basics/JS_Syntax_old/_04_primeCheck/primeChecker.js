/**
 * Created by isrmn on 11.3.2015 г..
 */
function isPrime(number) {
    var prime = true;
    if(number < 2) {
        prime = false;
    } else {
        for (var i = 2; i <= Math.sqrt(number); i++) {
            if(number%i == 0) {
                prime = false;
                break;
            }
        }
    }
    return prime;
}

console.log(isPrime(7));
console.log(isPrime(254));
console.log(isPrime(587));