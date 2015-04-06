/**
 * Created by isrmn on 11.3.2015 г..
 */
function calcSupply(age,maxAge,favoriteFood,amountPerDay) {
    var totalAmount = (maxAge - age) * 365 * amountPerDay;
    console.log(totalAmount + 'kg of ' + favoriteFood + ' would be enough until I am ' + maxAge + ' years old.');
}
calcSupply(38,118,'chocolate',0.5);
calcSupply(20,87,'fruits',2);
calcSupply(16,102,'nuts',1.1);