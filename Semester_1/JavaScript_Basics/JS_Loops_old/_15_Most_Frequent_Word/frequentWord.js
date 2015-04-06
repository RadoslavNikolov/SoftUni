/**
 * Created by isrmn on 16.3.2015 г..
 */
function findMostFreqWord(input) {
    var inputAsArr = input.toLowerCase().split(/\W+/).filter(function(v) {
       return v !== '';
    });
    //console.log(inputAsArr);
    var freqCount = {};
    for (var i = 0; i < inputAsArr.length; i++) {
        if(freqCount[inputAsArr[i]]) {
            freqCount[inputAsArr[i]]++;
        } else {
            freqCount[inputAsArr[i]] = 1;
        }
    }
    var word;
    var maxFreq = 0;
    var output = {};
    for(var key in freqCount) {
        if(freqCount[key] > maxFreq) {
            maxFreq = freqCount[key];
        }
    }

    output = sortObjbyKey(freqCount,maxFreq);
    for(var key in output) {
        console.log(key + ' -> ' + output[key] + ' times');
    }
    console.log('--------------------------');
}
function sortObjbyKey(obj,maxFreq) {
    var sortedKeys = [];
    var sortedObj = {};

    //separate keys and sort them
    for(var key in obj) {
        if(obj[key] === maxFreq) {
            sortedKeys.push(key);
        }
    }
    sortedKeys.sort();

    //reconstruct sorted obj based on keys
    for (var key in sortedKeys) {
        sortedObj[sortedKeys[key]] = obj[sortedKeys[key]];
    }
    return sortedObj;
}

findMostFreqWord('in the middle of the night');
findMostFreqWord('Welcome to SoftUni. Welcome to Java. Welcome everyone.');
findMostFreqWord('Hello my friend, hello my darling. Come on, come here. Welcome, welcome darling.');