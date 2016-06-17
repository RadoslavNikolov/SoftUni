#pragma once
#include "Enums.h"

class Person
{
public:
	Person();
	Person(unsigned short personId, string personName, Course course);
	~Person();
	
	Course getCurrentCourse();
	string getCourseName();
	unsigned short getNumOfCources();
	void setCurrentCourse(Course course);

	virtual string toString();
	virtual string getName()
	{
		return name;
	}

	virtual unsigned short getPersonId()
	{
		return id;
	}

private:
	unsigned short id;
	string name;
	
protected:
	Course currentCourse;
	unsigned short numOfCources;
};

