#pragma once
#include <exception>
#include "Person.h"


class Student : public Person
{
public:
	Student(unsigned short id, string name, Course cource);
	Student(unsigned short id, string name, Course cource, unsigned int points);
	~Student();

	void setPointsForCurrentCource(int points);
	float getAverageMark();
	string toString();

private:
	unsigned int cuurentPointForCurrentCource = 0;
	unsigned int totalPoint = 0;
	float calcMark(float points);

};

