/**
 * Created by rnikolov on 03.10.2016 г..
 */
function sumVat(input) {
    let sum = 0;

    for(let num of input){
        sum += Number(num)
    }

    console.log("Sum = " + sum);
    console.log("VAT = " + sum * 0.20);
    console.log("Total = " + sum * 1.20);
}

sumVat([10,20,30]);
