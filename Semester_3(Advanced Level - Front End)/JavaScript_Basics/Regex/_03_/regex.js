/**
 * Created by toshiba on 25.3.2015 г..
 */
function solve(input) {
    var result = input.match(/[A-Z][a-z?]*(\.)?/gi);
    result = result.join(' ');
    console.log(JSON.stringify(result));
}
solve("Pesho Peshev Jr.");