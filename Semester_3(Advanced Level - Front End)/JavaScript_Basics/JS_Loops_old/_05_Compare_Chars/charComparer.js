/**
 * Created by isrmn on 13.3.2015 г..
 */
function compareChars(arr1,arr2) {
    var isEqual;

    if(arr1.length !== arr2.length) {
        isEqual = false;
    } else {
        for (var i = 0; i < arr1.length; i++) {
            if(arr1[i] === arr2[i]) {
                isEqual = true;
            } else {
                isEqual = false;
                break;
            }
        }
    }

    isEqual ? console.log('Equal') : console.log('Not Equal');
}

compareChars(['1', 'f', '1', 's', 'g', 'j', 'f', 'u', 's', 'q'],
    ['1', 'f', '1', 's', 'g', 'j', 'f', 'u', 's', 'q']);

compareChars(['3', '5', 'g', 'd'],
    ['5', '3', 'g', 'd']);

compareChars(['q', 'g', 'q', 'h', 'a', 'k', 'u', '8', '}', 'q', '.', 'h', '|', ';'],
    ['6', 'f', 'w', 'q', ':', '”', 'd', '}', ']', 's', 'r']);
