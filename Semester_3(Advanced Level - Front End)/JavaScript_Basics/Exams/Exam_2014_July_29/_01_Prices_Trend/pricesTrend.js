/**
 * Created by toshiba on 19.3.2015 г..
 */
function solve(input) {
    console.log('<table>');
    console.log('<tr><th>Price</th><th>Trend</th></tr>');
    for(var i=0; i < input.length; i++) {
        var number = Number(input[i]).toFixed(2);
        number = Number(number);
        if(i > 0) {
            var prevNumber = Number(input[i-1]).toFixed(2);
            prevNumber = Number(prevNumber);
        }
        if((i < 1) || (number === prevNumber)) {
            console.log('<tr><td>' + number.toFixed(2) + '</td><td><img src="fixed.png"/></td></td>');
        } else if (number > prevNumber){
            console.log('<tr><td>' + number.toFixed(2) + '</td><td><img src="up.png"/></td></td>');

        } else if (number < prevNumber){
            console.log('<tr><td>' + number.toFixed(2) + '</td><td><img src="down.png"/></td></td>');
        }
    }
    console.log('</table>');

}

//sumNumbers([1]);
//sumNumbers([36.333,36.5,37.019,35.4,35,35.001,36.225])
//sumNumbers([1.33,1.35,2.25,13.00,0.5,0.51,0.5,0.5,0.33,1.05,1.346,20,900,1500.1,1500.10,2000]);
