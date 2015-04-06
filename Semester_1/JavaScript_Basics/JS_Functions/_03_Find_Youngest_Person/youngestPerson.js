/**
 * Created by isrmn on 19.3.2015 г..
 */
function findYpungestPerson(inputArr) {
    var processedArray = inputArr.filter(function(element){
        return element.hasSmartphone;
    });
    processedArray.sort(function(a,b){
        return a.age > b.age;
    });
    //console.log(processedArray)
    console.log('The youngest person is ' + processedArray[0].firstname + ' ' + processedArray[0].lastname);
}
var people = [
    { firstname : 'George', lastname: 'Kolev', age: 32, hasSmartphone: false },
    { firstname : 'Vasil', lastname: 'Kovachev', age: 40, hasSmartphone: true },
    { firstname : 'Bay', lastname: 'Ivan', age: 81, hasSmartphone: true },
    { firstname : 'Baba', lastname: 'Ginka', age: 40, hasSmartphone: false }];

findYpungestPerson(people);