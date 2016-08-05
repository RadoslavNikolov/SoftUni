#ifndef Student_h
#define Student_h
#endif // !Student_h
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
	Group _group;
	Course _course;
	set<string> _subjects;
	map<string, float> _marks;

public:
	Student();
	~Student();

	string getName();
	string getFacultyName();
	Group getGroup();
	Course getCourse();
	set<string> getSubjects();
	map<string, float> getMarks();

	void setName(string name);
	void setFacultyName(string facultyName);
	void setCorse(Course course);
	void setGroup(Group group);

	void addSubject(string subject);
	void addMark(string subject, float mark);
};

