/**
 * Created by isrmn on 11.3.2015 г..
 */
function calcExpression () {
    var expression = document.getElementById('expression-string').value;
    var result = eval(expression);
    document.getElementById('result').innerText = result;
}