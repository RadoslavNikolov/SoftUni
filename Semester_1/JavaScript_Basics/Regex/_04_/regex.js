/**
 * Created by toshiba on 25.3.2015 г..
 */
function solve(input) {
    var result = input.match(/\d{1,2}(\/|\.|\-)\d{1,2}\1\d{2,4}/gi);
    console.log(JSON.stringify(result));
}
solve("Koi den sme dnes? Mii 3/24/20153");