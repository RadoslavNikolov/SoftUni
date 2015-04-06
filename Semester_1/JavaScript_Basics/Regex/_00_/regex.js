/**
 * Created by toshiba on 25.3.2015 г..
 */
function solve(input) {
    var result = input.match(/[A-Za-z0-9\-_]{3,15}/gi);
    console.log(JSON.stringify(result));
}
solve("gosho_123");