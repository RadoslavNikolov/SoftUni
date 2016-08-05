#include "Student.h"



Student::Student()
{
}


Student::~Student()
{
}

string Student::getName()
{
	return this->_name;
}

string Student::getFacultyName()
{
	return this->_facultyNumber;
}

Group Student::getGroup()
{
	return this->_group;
}

Course Student::getCourse()
{
	return this->_course;
}

set<string> Student::getSubjects()
{
	return this->_subjects;
}

map<string, float> Student::getMarks()
{
	return this->_marks;
}

void Student::setName(string name)
{
	this->_name = name;
}

void Student::setFacultyName(string facultyName)
{
	this->_facultyNumber = facultyName;
}

void Student::setCorse(Course course)
{
	this->_course = course;
}

void Student::setGroup(Group group)
{
	this->_group = group;
}

void Student::addSubject(string subject)
{
	this->_subjects.insert(subject);
}

void Student::addMark(string subject, float mark)
{
	this->_marks[subject] = mark;
	//this->_marks.insert(pair<string, float>(subject, mark));
}
