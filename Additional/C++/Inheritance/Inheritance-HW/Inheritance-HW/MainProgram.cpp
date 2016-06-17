#include <iostream>
#include "Student.h"
#include "GuestTeacher.h"
#include "Teacher.h"
#include "Enums.h"
#include "SplitString.h"
#include <memory>

// Ќе спазвам условието да има три колекции за всеки Person с цел да си поигра€ с малко по сложни неща
typedef map<unsigned short, shared_ptr<Person>> Database;
Database myDB;
unsigned short dbCounter = 1;

void printMenu()
{
	cout << endl << "1. Get data for student with ID" << endl;
	cout << "2. Add data for new student" << endl;
	cout << "3. Add data for new teacher" << endl;
	cout << "4. Add data for new gest teacher" << endl;
	cout << "0 End" << endl;
	cout << "Enter number from menu:  ";
}

void getInputLine(vector<string> &input)
{
	string segment;
	cin >> segment;

	SplitString s(segment);
	input = s.split(':');
}

shared_ptr<Person> getPersonById(unsigned short id)
{
	Database::iterator it = myDB.find(id);
	if (it != myDB.end())
	{
		return it->second;
	}

	return nullptr;
}

void addDataForPerson(PersonType personType)
{
	if (dbCounter >= 65535)
	{
		cout << endl << " >>>>>> Database is full!" << endl;
		return;
	}

	vector<string> input;

	if (personType == PersonType::Student)
	{
		cout << "Enter new student in format with delimiter ':' [Name:CurrentCourse(Java,C,CSharp,CPlusPlus, NoCourse):CurrentPoints(0-100)]" << endl;	
		getInputLine(input);

		//Add data to 'database'
		try
		{
			myDB[dbCounter] = make_shared<Student>(dbCounter, input[0], EnumsHelper::stringToEnum(input[1]), stoi(input[2]));
			cout << " >>>>>> Added student with id: " << dbCounter << endl;;
			dbCounter++;
		}
		catch (const char* msg)
		{
			cout << " >>>>>> " << msg << endl;
		}
				
	}

	if (personType == PersonType::Teacher)
	{
		cout << "Enter new teacher in format with delimiter ':' [Name:CurrentCourse(Java,C,CSharp,CPlusPlus, NoCource):MonthlySalary(>0)]" << endl;
		getInputLine(input);

		//Add data to 'database'
		try
		{
			myDB[dbCounter] = make_shared<Teacher>(dbCounter, input[0], EnumsHelper::stringToEnum(input[1]), stoi(input[2]));
			cout << " >>>>>> Added teacher with id: " << dbCounter << endl;
			dbCounter++;
		}
		catch (const char* msg)
		{
			cout << " >>>>>> " << msg << endl;
		}

	}

	if (personType == PersonType::GuestTeacher)
	{
		cout << "Enter new guest teacher in format with delimiter ':' [Name:CurrentCourse(Java,C,CSharp,CPlusPlus, NoCource):SalaryForCourse(>0)]" << endl;
		getInputLine(input);

		//Add data to 'database'
		try
		{
			myDB[dbCounter] = make_shared<GuestTeacher>(dbCounter, input[0], EnumsHelper::stringToEnum(input[1]), stoi(input[2]));
			cout << " >>>>>> Added guest teacher with id: " << dbCounter << endl;
			dbCounter++;
		}
		catch (const char* msg)
		{
			cout << " >>>>>> " << msg << endl;
		}		
	}	
}

void commandManager(unsigned short choice)
{
	shared_ptr<Person> p;
	unsigned short searchingId;

	switch (choice)
	{
	case 1:
		cout << "Enter Id (0-65535):  ";
		cin >> searchingId;

		if (!cin)
		{
			cin.clear();
			cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
			cout << endl << " >>>>>> Invalid id! Id must be in range [0-65535]" << endl;
			break;
		}

		p = getPersonById(searchingId);

		if (p != nullptr)
		{
			cout << p->toString();
		}
		else
		{
			cout << endl << " >>>>>> Cannot find person with id: " << searchingId << endl;
		}

		break;
	case 2:
		addDataForPerson(PersonType::Student);
		break;
	case 3:
		addDataForPerson(PersonType::Teacher);
		break;
	case 4:
		addDataForPerson(PersonType::GuestTeacher);
		break;
	default:
		cout << endl <<  " >>>>>> Invalid command!" << endl;
		break;
	}
}

void start()
{
	bool isRunning = true;
	unsigned short choice;

	while (isRunning)
	{
		choice = 999;
		printMenu();
		cin.sync();
		cin >> choice;

		if (!cin)
		{
			cin.clear(); // reset failbit
			cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n'); //skip bad input
		}

		isRunning = choice != 0;

		if (isRunning)
		{
			commandManager(choice);
		}

	}
}


int main()
{
	start();
}



