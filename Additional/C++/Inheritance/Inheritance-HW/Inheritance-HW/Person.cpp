#include "Person.h"
#include <sstream>


Person::Person() : id(0), name("NoName"), currentCourse(Course::NoCourse), numOfCources(0)
{
}


Person::Person(unsigned short personId, string personName, Course course) : id(personId), name(personName), numOfCources(0)
{
	setCurrentCourse(course);
}

Person::~Person()
{
}


Course Person::getCurrentCourse()
{
	return currentCourse;
}

string Person::getCourseName()
{
	switch (currentCourse)
	{
	case Course::Java:
		return "Java";
		break;
	case Course::C:
		return "C";
		break;
	case Course::CSharp:
		return "CSharp";
		break;
	case Course::CPlusPlus:
		return "CPlusPlus";
		break;
	case Course::NoCourse:
		return "NoCource";
		break;
	default:
		return "";
		break;
	}
}

unsigned short Person::getNumOfCources()
{
	return numOfCources;
}

void Person::setCurrentCourse(Course course)
{
	numOfCources++;
	currentCourse = course;
}


string Person::toString()
{
	ostringstream result;
	result << "ID: " << id << endl
		<< "Name: " << name << endl
		<< "Current course: " << getCourseName() << endl;

	return result.str();
}
