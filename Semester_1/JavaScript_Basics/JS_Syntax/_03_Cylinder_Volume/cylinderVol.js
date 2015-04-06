/**
 * Created by toshiba on 11.3.2015 г..
 */
function calcCylinderVol(input) {
    var radius = input[0];
    var height = input[1];
    var cylinderVolume = Math.PI * radius * radius * height;
    return cylinderVolume.toFixed(3);
}
console.log(calcCylinderVol([2,4]));
console.log(calcCylinderVol([5,8]));
console.log(calcCylinderVol([12,3]));