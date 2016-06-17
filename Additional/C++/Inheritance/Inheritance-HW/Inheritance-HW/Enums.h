#pragma once
#include <map>

using namespace std;

enum class Course {Java,C,CSharp,CPlusPlus, NoCourse};

enum class PersonType {Student, Teacher, GuestTeacher};

class EnumsHelper
{
public: 
	static Course stringToEnum(string str);
};



