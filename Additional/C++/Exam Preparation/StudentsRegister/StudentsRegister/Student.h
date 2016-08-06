#ifndef Student_h
#define Student_h

#include "Enums.h"
#include <string>
#include <set>
#include <map>


using namespace std;

class Student
{
protected:
	string _name;
	string _facultyNumber;
	Groups _group;
	Courses _course;
	set<string> _subjects;
	map<string, float> _marks;

public:
	Student();
	~Student();

	

	// getters
	string getName();
	string getFacultyName();
	Groups getGroup();
	Courses getCourse();
	set<string> getSubjects();
	map<string, float> getMarks();

	// setter
	void setName(string name);
	void setFacultyName(string facultyName);
	bool setCorse(int course);
	bool setGroup(int group);

	// functions
	void addMark(string subject, float mark);
	float getAvgMark();

	
};

#endif // !Student_h