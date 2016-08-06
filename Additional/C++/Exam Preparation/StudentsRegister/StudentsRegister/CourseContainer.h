#ifndef CourseContainer_h
#define CourseContainer_h

#include <vector>
#include <memory>
#include <iostream>
#include "Student.h"

class CourseContainer
{
public:
	CourseContainer();
	~CourseContainer();

	std::vector<shared_ptr<Student>> studentContainer;

	void searchAndPrint(std::string facultyNumber);
};


#endif // !Course_h

