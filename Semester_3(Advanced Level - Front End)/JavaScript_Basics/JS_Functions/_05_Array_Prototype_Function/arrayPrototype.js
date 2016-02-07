/**
 * Created by isrmn on 19.3.2015 г..
 */
Array.prototype.removeItem = function() {
    var toremove;
    var lenght = arguments.length;
    var index;
    while(lenght) {
        toremove = arguments[--lenght];
        while((index = this.indexOf(toremove)) !== -1) {
            this.splice(index,1);
        }
    }
    return this;
}

var input = [
    [1, [1, 2, 1, 4, 1, 3, 4, 1, 111, 3, 2, 1, '1']],
    ['bye', ['hi', 'bye', 'hello']]
];
for(var i in input) {
    console.log(input[i][1].removeItem(input[i][0]));
}