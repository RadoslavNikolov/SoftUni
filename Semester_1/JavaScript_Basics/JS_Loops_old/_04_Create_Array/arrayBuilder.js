/**
 * Created by isrmn on 13.3.2015 г..
 */
function createArray() {
    var arr = [];
    for (var i = 0; i <= 20; i++) {
        arr[i] = i * 5;
    }
    console.log(arr.join(' '));
}
createArray();