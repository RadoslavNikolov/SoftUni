/**
 * Created by isrmn on 20.3.2015 г..
 */
function solve(input) {
    var courses = {};
    var output = {};

    for(var index in input) {
        var row = input[index].split('|');
        //console.log(row);
        var name = row[0].trim();
        var course = row[1].trim();
        var grade = Number(row[2]);
        var visits = Number(row[3]);
        if(courses[course]) {
            courses[course]['avgGrade']+= grade;
            courses[course]['avgVisits']+=visits;
            courses[course]['numberOfStudents']++;
            if(courses[course]['students'].indexOf(name) === -1) {
                courses[course]['students'].push(name);
            }
        } else {
            courses[course] = {};
            courses[course]['avgGrade'] = grade;
            courses[course]['avgVisits'] = visits;
            courses[course]['numberOfStudents'] = 1;
            courses[course]['students'] = [];
            courses[course]['students'].push(name);
        }
    }
    for(var course in courses) {
        courses[course]['avgGrade'] = parseFloat((courses[course]['avgGrade'] / courses[course]['numberOfStudents']).toFixed(2));
        courses[course]['avgVisits'] = parseFloat((courses[course]['avgVisits'] / courses[course]['numberOfStudents']).toFixed(2));
        courses[course]['students'].sort();
        delete courses[course]['numberOfStudents'];
    }
    var keys = Object.keys(courses).sort();
    for(var key in keys) {
        output[keys[key]] = courses[keys[key]];
    }
    console.log(JSON.stringify(output));
}

//var input = [
//    [
//        'Peter Nikolov | PHP  | 5.50 | 8',
//        'Maria Ivanova | Java | 5.83 | 7',
//        'Ivan Petrov   | PHP  | 3.00 | 2',
//        'Ivan Petrov   | C#   | 3.00 | 2',
//        'Peter Nikolov | C#   | 5.50 | 8',
//        'Maria Ivanova | C#   | 5.83 | 7',
//        'Ivan Petrov   | C#   | 4.12 | 5',
//        'Ivan Petrov   | PHP  | 3.10 | 2',
//        'Peter Nikolov | Java | 6.00 | 9'
//    ]
//];
//
//for (var str in input) {
//    solve(input[str]);
//}