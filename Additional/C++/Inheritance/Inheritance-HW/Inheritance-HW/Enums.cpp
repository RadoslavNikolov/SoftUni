#include "Enums.h"

Course EnumsHelper::stringToEnum(string str)
{
	map<string, Course> coursesMapper;
	coursesMapper["Java"] = Course::Java;
	coursesMapper["C"] = Course::C;
	coursesMapper["CSharp"] = Course::CSharp;
	coursesMapper["CPlusPlus"] = Course::CPlusPlus;
	coursesMapper["NoCource"] = Course::NoCourse;

	map<string, Course>::iterator i = coursesMapper.find(str);
	if (i != coursesMapper.end())
	{
		return i->second;
	}
	else
	{
		throw "Inavlid course name. Valid names ara (Java,C,CSharp,CPlusPlus,NoCourse). Names are case sensitive.";
	}
}
