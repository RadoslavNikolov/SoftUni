
function extractObject(inputArray) {
    var processedArray = [];
    for(var index in inputArray){
        var returnValue = checkElement(inputArray[index]);
        if(returnValue) {
            processedArray.push(returnValue);
        }
    }
    console.log(processedArray);
}

function checkElement(element) {
    if((typeof element === 'object') && !Array.isArray(element)) {
        return element;
    }
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