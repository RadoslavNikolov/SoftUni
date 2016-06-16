#include <string>
#include <sstream>
using namespace std;

class Human
{
private:
	string _name;
	int _age;

public:
	Human(string name, int age)
	{
		setName(name);
		setAge(age);
	}

	Human()
	{
		setName("No name");
		setAge(0);
	}

	string getName() const
	{
		return _name;
	}

	int getAge() const
	{
		return _age;
	}

	void setName(string value)
	{
		_name = value;
	}

	void setAge(int value)
	{
		_age = value;
	}

	string toString() const
	{
		ostringstream result;
		result << "Human name: " << getName() << endl
			<< "Human age: " << getAge() << endl;
		return result.str();
	}
};
