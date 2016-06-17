#include "Student.h"
#include <sstream>


Student::Student(unsigned short id, string name, Course course) : Person(id, name, course)
{
}

Student::Student(unsigned short id, string name, Course course, unsigned int points) : Person(id,name, course)
{
	setPointsForCurrentCource(points);
}


Student::~Student()
{
}

void Student::setPointsForCurrentCource(int points)
{
	cuurentPointForCurrentCource = points;

	if (points < 0 || points > 100)
	{
		throw "Points for given cource must be in range [0-100].";
	}

	totalPoint += cuurentPointForCurrentCource;
}

float Student::getAverageMark()
{
	if (numOfCources == 0)
	{
		return 0.0;
	}
	else
	{
		return calcMark(totalPoint /numOfCources);
	}
}

string Student::toString()
{
	ostringstream result;
	result << endl << "Person info ========================" << endl
		<< "Type: " << typeid(this).name() << endl
		<< Person::toString()
		<< "Average evaluation mark: " << getAverageMark() << endl
		<< "====================================" << endl;

	return result.str();
}

float Student::calcMark(float points)
{
	if (points < 50.0)
	{
		return 2.0;
	}
	else if (points < 60) 
	{
		return 3.0;
	}
	else if (points < 70)
	{
		return 4.0;
	}
	else if (points < 80)
	{
		return 5.0;
	}
	else
	{
		return 6.0;
	}

}
