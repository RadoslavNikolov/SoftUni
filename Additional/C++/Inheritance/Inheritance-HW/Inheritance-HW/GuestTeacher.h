#pragma once
#include "Person.h"

class GuestTeacher : public Person
{
public:
	GuestTeacher(unsigned short, string, Course);
	GuestTeacher(unsigned short, string, Course, float);
	~GuestTeacher();

	void setSalary(float salary);
	float getSalary();
	string toString();

private:
	float salaryForCourse;
};

