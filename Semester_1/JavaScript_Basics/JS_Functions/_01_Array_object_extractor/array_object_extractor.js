/**
 * Created by isrmn on 19.3.2015 г..
 */
function extractObject(inputArray) {
    var processedArray = inputArray.filter(function(element){
        return (typeof element === 'object') && !Array.isArray(element);
    });
    console.log(processedArray);
}

extractObject([
        "Pesho",
        4,
        4.21,
        { name : 'Valyo', age : 16 },
        { type : 'fish', model : 'zlatna ribka' },
        [1,2,3],
        "Gosho",
        { name : 'Penka', height: 1.65}
    ]
);