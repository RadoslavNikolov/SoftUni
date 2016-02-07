/**
 * Created by isrmn on 17.3.2015 г..
 */
function solve(input) {
    var processedArray = [];
    for (var i = 2; i < input.length-1; i++) {
        var tempArray = input[i].split(/<tr><td>|<\/td><td>|<\/td><\/tr>/g).filter(function(elem){
            return elem !== '';
        });
        processedArray.push({
            'product': tempArray[0],
            'price': tempArray[1],
            'votes': tempArray[2]
        });
    }
    processedArray.sort(function(x,y){
        if(x.price !== y.price) {
            return x.price - y.price;
        }
         return x.product > y.product;

    });
    //console.log(processedArray);
    printTable(processedArray);

    function printTable(inputArr) {
        console.log('<table>\n<tr><th>Product</th><th>Price</th><th>Votes</th></tr>');
        inputArr.forEach(function(row){
            console.log('<tr><td>' + row.product + '</td><td>' + row.price + '</td><td>' +row.votes + '</td></tr>');
        });
        console.log('</table>')
    }
}

//var input = [
//    ['<table>',
//        '<tr><th>Product</th><th>Price</th><th>Votes</th></tr>',
//        '<tr><td>Kamenitza Grapefruit 1 l</td><td>1.85</td><td>+7</td></tr>',
//        '<tr><td>Vodka Finlandia 1 l</td><td>19.35</td><td>+12</td></tr>',
//        '<tr><td>Laptop Lenovo IdeaPad B5400</td><td>929.00</td><td>0</td></tr>',
//        '<tr><td>Laptop ASUS ROG G550JK-CN268D</td><td>1939.00</td><td>+1</td></tr>',
//        '<tr><td>Ariana Radler 0.5 l</td><td>1.19</td><td>+33</td></tr>',
//        '<tr><td>Coffee Davidoff 250 gr.</td><td>11.99</td><td>+11</td></tr>',
//        '<tr><td>Kamenitza Lemon 1 l</td><td>1.65</td><td>+7</td></tr>',
//        '<tr><td>Vodka Absolute 1 l</td><td>22.00</td><td>+2</td></tr>',
//        '<tr><td>Laptop Dell Inspiron 3537</td><td>1199.0</td><td>+3</td></tr>',
//        '<tr><td>Laptop HP 250 G2</td><td>629</td><td>-10</td></tr>',
//        '<tr><td>Ariana Radler 1.5 l</td><td>2.79</td><td>+33</td></tr>',
//        '<tr><td>Coffee Lavazza 250 gr.</td><td>8.73</td><td>+10</td></tr>',
//        '</table>']
//];
//
//for (var str in input) {
//    solve(input[str]);
//}