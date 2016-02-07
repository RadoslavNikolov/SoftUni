/**
 * Created by radko on 31.3.2015 г..
 */
function solve(input) {
    var users = {students: [], trainers: []};
    var sortCriteria = input[0].split('^');

    for (var i = 1; i < input.length; i++) {
        var strLine = JSON.parse(input[i]);
        if(strLine.role == 'student') {
            users.students.push(strLine);
        } else {
            users.trainers.push(strLine);
        }
    }

    if (sortCriteria[0] === 'level') {
        sortByLevel();
    } else {
        sortByName();
    }
    sortByCourses();

    for(var key in users.students) {
        var sum = 0;
        users.students[key].grades.forEach(function(grade){
            sum += Number(grade);
        });
        users.students[key].averageGrade = (sum/users.students[key].grades.length).toFixed(2);
    }

    for(var key in users.trainers) {
        delete users.trainers[key].town;
        delete users.trainers[key].role;
    }

    for(var key in users.students) {
        var hasCertificate = users.students[key].certificate;
        delete users.students[key].town;
        delete users.students[key].role;
        delete users.students[key].grades;
        delete users.students[key].level;
        delete users.students[key].certificate;
        users.students[key].certificate = hasCertificate;
    }

    console.log(JSON.stringify(users));



    function sortByLevel() {
        users.students.sort(function(a,b){
            if(a.level !== b.level) {
                return Number(a.level) - Number(b.level);
            } else {
                return a.id - b.id;
            }
        });
    }

    function sortByName() {
        users.students.sort(function(a,b){
            if (a.firstname < b.firstname) {
                return -1;
            }
            if (a.firstname > b.firstname) {
                return 1;
            }
            if (a.lastname < b.lastname) {
                return -1;
            }
            if (a.lastname > b.lastname) {
                return 1;
            }
            return 0;
        });
    }
    function sortByCourses() {
        users.trainers.sort(function(a,b){
            if(a.courses.length !== b.courses.length) {
                return a.courses.length - b.courses.length;
            } else {
                return a.lecturesPerDay - b.lecturesPerDay;
            }
        });
    }

}

//var input = [
//    ['name^courses',
//     '{"id":0,"firstname":"Angel","lastname":"Ivanov","town":"Plovdiv","role":"student","grades":["5.89"],"level":2,"certificate":false}',
//     '{"id":1,"firstname":"Mitko","lastname":"Nakova","town":"Dimitrovgrad","role":"trainer","courses":["PHP","Unity Basics"],"lecturesPerDay":6}',
//     '{"id":2,"firstname":"Bobi","lastname":"Georgiev","town":"Varna","role":"student","grades":["5.59","3.50","4.54","5.05","3.45"],"level":4,"certificate":false}',
//     '{"id":3,"firstname":"Ivan","lastname":"Ivanova","town":"Vidin","role":"trainer","courses":["JS","Java","JS OOP","Database","OOP","C#"],"lecturesPerDay":7}',
//     '{"id":4,"firstname":"Mitko","lastname":"Petrova","town":"Sofia","role":"trainer","courses":["Database","JS Apps","Java"],"lecturesPerDay":2}']
//];
//
//for (var arr in input) {
//    solve(input[arr]);
//}