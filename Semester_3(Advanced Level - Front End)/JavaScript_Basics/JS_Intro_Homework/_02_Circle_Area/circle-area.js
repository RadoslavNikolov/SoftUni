/**
 * Created by toshiba on 9.3.2015 г..
 */
var radiusArr = [7,1.5,20];
for (var i = 0; i < radiusArr.length; i++) {
    document.write('r = ' + radiusArr[i] + '; area = ' + (Math.PI*Math.pow(radiusArr[i],2)) + "<br/>");
}