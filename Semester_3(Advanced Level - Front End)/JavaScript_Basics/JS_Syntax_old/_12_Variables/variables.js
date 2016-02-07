/**
 * Created by isrmn on 11.3.2015 г..
 */
function variablesTypes(data) {
    var name = data[0];
    var age = data[1];
    var isMale = data[2];
    var favoriteFoodArr = data[3];

    console.log('My name: ' + name + " //type is " + typeof name);
    console.log('My age: ' + age + " //type is " + typeof age);
    console.log('I am male: ' + isMale + " //type is " + typeof age);
    var outputStr = 'My favorite foods are:  ';
    favoriteFoodArr.forEach(function(food) {
       outputStr += (food + ',');
    });
    console.log(outputStr.substring(0,outputStr.length-1));


}
variablesTypes(['Pesho', 22, true, ['fries', 'banana', 'cake']]);