/**
 * Created by radko on 20.3.2015 г..
 */
function solve(input) {
    var output = '';
    var numArr = input[0].split(/\D+/g).filter(function(x){
        return x !== '';
    });
    numArr.forEach(function(num){
        var hexNum = parseInt(num).toString(16).toUpperCase();
        while(hexNum.length < 4) {
            hexNum = '0' + hexNum;
        }
        output +=  '0x' + hexNum + '-';
    });


    console.log(output.substring(0,output.length-1));
}
//solve('20');