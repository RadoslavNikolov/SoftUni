/**
 * Created by toshiba on 11.3.2015 г..
 */
function displayProperties() {
    var propertiesArr = [];
    for (var properties in document) {
        propertiesArr.push(properties);
    }
    propertiesArr.sort(function(a,b) {
        return a.toUpperCase().localeCompare(b.toUpperCase());
    });

    var outputStr = propertiesArr.join('\n');
    console.log(outputStr);
}
displayProperties();
