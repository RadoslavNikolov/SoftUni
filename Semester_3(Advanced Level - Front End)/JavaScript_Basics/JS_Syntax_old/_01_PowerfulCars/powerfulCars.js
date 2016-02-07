/**
 * Created by isrmn on 10.3.2015 г..
 */
function convertKWtoHP(carKw) {
    var carHP = carKw/0.745699872;
    return carHP.toFixed(2);
}
console.log(convertKWtoHP(75));
console.log(convertKWtoHP(150));
console.log(convertKWtoHP(1000));
