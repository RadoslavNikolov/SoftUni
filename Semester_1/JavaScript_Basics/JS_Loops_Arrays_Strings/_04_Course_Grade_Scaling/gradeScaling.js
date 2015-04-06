/**
 * Created by isrmn on 17.3.2015 г..
 */
function scaleGrade(input) {
    //add 10% to score
    input.map(function(person){
        person.score = parseFloat((person.score * 1.1).toFixed(1));
    });
    //add 'hasPassed' property if score >= 100
    input.forEach(function(person){
        if(person.score >= 100) {
            person['hasPassed'] = true;
        } else {
            person['hasPassed'] = false;
        }
    });
    //filter only those who have passed
    var outputArr = input.filter(function(person){
        if(person.hasPassed === true) {
            return person;
        }
    });
    //sort outputArr by key
    outputArr.sort(function(a,b){
        return a.name > b.name;
    });

    console.log(outputArr);

}

scaleGrade([
        {
            'name' : 'Пешо',
            'score' : 91
        },
        {
            'name' : 'Лилия',
            'score' : 290
        },
        {
            'name' : 'Алекс',
            'score' : 343
        },
        {
            'name' : 'Габриела',
            'score' : 400
        },
        {
            'name' : 'Жичка',
            'score' : 70
        }
    ]
);
