#include "GuestTeacher.h"
#include <sstream>

GuestTeacher::GuestTeacher(unsigned short id, string name, Course course) : Person(id, name, course)
{
	setSalary(0);
}

GuestTeacher::GuestTeacher(unsigned short id, string name, Course course, float salary) : Person(id, name, course)
{
	setSalary(salary);
}


GuestTeacher::~GuestTeacher()
{
}

void GuestTeacher::setSalary(float salary)
{
	if (salary < 0.0)
	{
		throw "Salary for current course must by positive number.";
	}
	salaryForCourse = salary;

	if (salaryForCourse < 0)
	{
		salaryForCourse = 0;
	}
}

float GuestTeacher::getSalary()
{
	return salaryForCourse;
}

string GuestTeacher::toString()
{
	ostringstream result;
	result << endl << "Person info ========================" << endl
		<< "Type: " << typeid(this).name() << endl
		<< Person::toString()
		<< "Salary for course: " << getSalary() << endl
		<< "====================================" << endl;

	return result.str();
}
