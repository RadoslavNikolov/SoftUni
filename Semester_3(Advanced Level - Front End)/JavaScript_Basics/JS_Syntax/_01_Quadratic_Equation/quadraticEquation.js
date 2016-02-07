/**
 * Created by toshiba on 11.3.2015 г..
 */
function calcQuadraticEqu(a,b,c) {
    var x1;
    var x2;
    var discriminant = Math.pow(b, 2) - (4 * a * c);

    //one way to claculate
    //if ((a + b + c) == 0) {
    //    x1 = c / a;
    //    x2 = 1;
    //    console.log('x1 = ' + x1 + '\nx2 = ' + x2);
    //} else if ((a - b + c) == 0) {
    //    x1 = -c / a;
    //    x2 = -1;
    //    console.log('x1 = ' + x1 + '\nx2 = ' + x2);
    //}


    if (discriminant < 0) {
        console.log('No real rots\n**************')
    } else if (discriminant == 0) {
        console.log('x = ' + ( -b / (2 * a)) + '\n**************');
    } else {
        x1 = (-b - Math.sqrt(discriminant)) / (2 * a);
        x2 = (-b + Math.sqrt(discriminant)) / (2 * a);
        console.log('x1 = ' + x1 + '\nx2 = ' + x2 + '\n**************');
    }
}

calcQuadraticEqu(2,5,-3);
calcQuadraticEqu(2,-4,2);
calcQuadraticEqu(4,2,1);




