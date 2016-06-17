#pragma once
#include "Person.h"
#include <ctime>

class Teacher : public Person
{
public:
	Teacher(unsigned short, string, Course);
	Teacher(unsigned short, string, Course, float);
	~Teacher();

	void setSalary(float salary);
	float getSalary();
	int getDaysJoined();
	string toString();

private:
	time_t subsDate;
	float monthlySalary;
};

