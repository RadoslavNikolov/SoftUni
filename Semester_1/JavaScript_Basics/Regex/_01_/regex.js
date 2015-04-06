/**
 * Created by toshiba on 25.3.2015 г..
 */
function solve(input) {
    var result = input.match(/([A-Za-z0-9\-_.]+)@([A-Za-z0-9\-_]+).([A-Za-z]{2,})/gi);
    console.log(JSON.stringify(result));
}
solve("meil SLO4AENOS.N.eMisLA@Eliomenad.com mail");