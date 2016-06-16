#include <sstream>
#include <typeinfo>
#include <map>
#include <iostream>

using namespace std;

enum CourceType { Java, CSharp };

class Person
{
public:
	Person() {};
	Person(int id, string personName) : personId(id), name(personName), courcesCount(1){};

	virtual ~Person() {}

	int getCourcesCount() const
	{
		return courcesCount;
	}

	string getName() const
	{
		return name;
	}

	virtual string toString()
	{
		ostringstream result;
		result 		
			<< "Person id: " << personId << endl
			<< "Person name: " << getName() << endl
			<< "All cources number: " << getCourcesCount() << endl;

		return result.str();
	}

protected:
	int personId;
	string name;
	CourceType currentCource;
	int courcesCount = 0;
};

class Student : public Person
{
public:
	Student(int id, string name, int points) : Person(id, name), points(points) {};
	
	string toString() override
	{
		ostringstream result;
		result
			<< typeid(this).name() << endl
			<< Person::toString()
			<< "Average points: " << points / getCourcesCount() << endl;

		return result.str();
	}
private:
	int points;
};

typedef map<int, Person*> Database;
Database myDB;
int counter = 0;

Person* getPersonById(int id)
{
	Database::iterator it = myDB.find(id);
	if (it != myDB.end())
	{
		return it->second;
	}
	
	return nullptr;
}

int main()
{
	Person * p1;
	Student s(++counter,"Test", 100);
	p1 = &s;
	myDB[counter] = p1;

	myDB[++counter] = &Student(counter,"Test1", 80);

	int searchingKey = 2;
	Person * resultPerson = getPersonById(searchingKey);

	if (resultPerson != nullptr)
	{
		cout << resultPerson->toString();
	}
	else
	{
		cout << "No person found with key: " << searchingKey << endl;
	}
}


