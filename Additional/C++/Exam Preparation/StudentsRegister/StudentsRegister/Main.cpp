#include "Student.h"
#include "CourseContainer.h"
#include <iostream>
#include <thread>

void search(string facultyName, CourseContainer & container)
{
	container.searchAndPrint(facultyName);
}

int main()
{
	CourseContainer aContainer;

	std::shared_ptr<Student> aStudent = std::make_shared<Student>(Student());
	aContainer.studentContainer.push_back(aStudent);

	thread aThread = thread(search, "dddd", aContainer);

	aThread.join();
	return 0;
}


