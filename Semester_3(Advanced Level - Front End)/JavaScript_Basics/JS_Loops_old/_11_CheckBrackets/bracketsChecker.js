/**
 * Created by toshiba on 13.3.2015 г..
 */
function checkBrackets(expression) {
    var openBracket = 0;
    var closeBracket = 0;
    for (var i = 0; i < expression.length; i++) {
        if (expression[i] == '(') {
            openBracket++;
        } else if(expression[i] == ')') {
            closeBracket++;
        }
    }
    openBracket === closeBracket ? console.log('correct') : console.log('incorrect');
}
checkBrackets('( ( a + b ) / 5 – d )' );
checkBrackets(') ( a + b ) )');
checkBrackets('( b * ( c + d *2 / ( 2 + ( 12 – c / ( a + 3 ) ) ) )');
