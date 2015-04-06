/**
 * Created by isrmn on 11.3.2015 г..
 */
function treeHouseCompare(a,b) {
    var houseArea = a * a + a * a * 2 / 6;
    var radius = (b / 3) * 2;
    var treeArea = b * (b / 3) + Math.PI * radius *radius;
    if(houseArea > treeArea) {
        console.log('house/' + houseArea.toFixed(2));
    } else if(houseArea < treeArea) {
        console.log('tree/' + treeArea.toFixed(2));
    } else {
        console.log('equal' + houseArea.toFixed(2));
    }
}
treeHouseCompare(3,2);
treeHouseCompare(3,3);
treeHouseCompare(4,5);