/**
 * Created by isrmn on 11.3.2015 г..
 */
function soothsayer(data) {
    var processedArray = [];
    for (var i = 0; i < data.length; i++) {
        var array = data[i];
        var randNum = Math.floor(Math.random() * array.length);
        processedArray.push(array[randNum]);
    }
    console.log('You will work ' + processedArray[0] + ' years on ' + processedArray[1] + '.\nYou will live in ' + processedArray[2] + ' and drive ' + processedArray[3] + '.');
}
soothsayer([[3, 5, 2, 7, 9], ['Java','Python','C#','JavaScript','Ruby'], ['Silicon Valley','London','Las Vegas','Paris','Sofia'], ['BMW','Audi','Lada','Skoda','Opel']]);
