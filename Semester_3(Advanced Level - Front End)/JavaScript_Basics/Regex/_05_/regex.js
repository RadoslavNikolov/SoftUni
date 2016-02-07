/**
 * Created by toshiba on 25.3.2015 г..
 */
function solve(input) {
    var result = input.match(/^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&*()\-_=+])[a-zA-Z0-9!@#$%^&*()\-_=+]{8,20}$/gi);
    console.log(JSON.stringify(result));
}
solve("hsfuUIhfsui761467$12");