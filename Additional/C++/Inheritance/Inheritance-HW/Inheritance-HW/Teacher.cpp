#include "Teacher.h"
#include <sstream>
#include <time.h> 

Teacher::Teacher(unsigned short id, string name, Course course) : Person(id, name, course)
{
	setSalary(0);
	subsDate = time(0);
}

Teacher::Teacher(unsigned short id, string name, Course course, float salary) : Person(id, name, course)
{
	setSalary(salary);
	subsDate = time(0);
}

Teacher::~Teacher()
{
}

void Teacher::setSalary(float salary)
{
	if (salary < 0)
	{
		throw "Salary must by positive number.";
	}

	monthlySalary = salary;
}

float Teacher::getSalary()
{
	return monthlySalary;
}

int Teacher::getDaysJoined()
{
	time_t now = time(0);
	double diff = difftime(now, subsDate) / (60);

	return diff;
}

string Teacher::toString()
{
	ostringstream result;
	result << endl << "Person info ========================" << endl
		<< "Type: " << typeid(this).name() << endl
		<< Person::toString()
		<< "Monthly salary: " << getSalary() << endl
		<< "Joined before: " << getDaysJoined() << " minutes" << endl
		<< "====================================" << endl;

	return result.str();
}
