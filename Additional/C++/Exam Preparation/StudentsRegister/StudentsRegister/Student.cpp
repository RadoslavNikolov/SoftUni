#include "Student.h"
#include <iostream>




Student::Student()
{
	cout << "Please enter name" << endl;
	string name;
	getline(cin, name);
	this->setName(name);

	cout << "Please enter faculty number" << endl;
	string facultyNumber;
	getline(cin, facultyNumber);
	this->setFacultyName(facultyNumber);

	int group;
	do
	{
		cout << "Please enter group from 40 to 44" << endl;	
		cin >> group;
	} while (this->setGroup(group) == false);
	

	int course;
	do
	{
		cout << "Please enter course from 1 to 5" << endl;
		cin >> course;
	} while (this->setCorse(course) == false);

	char inputedCharacter = 0;
	do
	{
		cout << "Please enter subject name" << endl;
		string subject;
		cin >> subject;
		if (subject[0] == '!')
		{
			break;
		}

		cout << "Please enter subject mark" << endl;
		float mark;
		cin >> mark;

		addMark(subject, mark);

	} while (true);
	
}


Student::~Student()
{
}

#pragma region Gettes
string Student::getName()
{
	return this->_name;
}

string Student::getFacultyName()
{
	return this->_facultyNumber;
}

Groups Student::getGroup()
{
	return this->_group;
}

Courses Student::getCourse()
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
#pragma endregion

#pragma region Setters
void Student::setName(string name)
{
	this->_name = name;
}

void Student::setFacultyName(string facultyName)
{
	this->_facultyNumber = facultyName;
}

bool Student::setCorse(int course)
{
	switch ((Courses)course)
	{
	case COURCE_1:
	case COURCE_2:
	case COURCE_3:
	case COURCE_4:
	case COURCE_5:
		this->_course = (Courses)course;
		return true;
	default:
		return false;
	}
}

bool Student::setGroup(int group)
{
	switch ((Groups)group)
	{
	case GROUP_40:
	case GROUP_41:
	case GROUP_42:
	case GROUP_43:
	case GROUP_44:
		this->_group = (Groups)group;
		return true;
	default:
		return false;
	}

}
#pragma endregion

#pragma region Functions

void Student::addMark(string subject, float mark)
{
	this->_subjects.insert(subject);
	this->_marks[subject] = mark;
}

float Student::getAvgMark()
{
	return 0.0f;
}


#pragma endregion

