#include "CourseContainer.h"
#include <algorithm>


CourseContainer::CourseContainer()
{
}


CourseContainer::~CourseContainer()
{
}

void CourseContainer::searchAndPrint(std::string facultyNumber)
{
	bool hasFind = false;

	for_each(this->studentContainer.begin(), this->studentContainer.end(), [&](shared_ptr<Student> student) {
		if (student->getFacultyName().compare(facultyNumber) == 0)
		{
			std::cout << student->getName() << endl;
			hasFind = true;
		}
	});


	/*for (auto student : this->studentContainer)
	{
		if (student->getFacultyName().compare(facultyNumber) == 0)
		{
			std::cout << student->getName() << endl;
			return;
		}
	}*/

	if (!hasFind)
	{
		std::cout << "Cannot find student with faculty number: " << facultyNumber << endl;
	}
}

void executeSearch()
{
	
}
