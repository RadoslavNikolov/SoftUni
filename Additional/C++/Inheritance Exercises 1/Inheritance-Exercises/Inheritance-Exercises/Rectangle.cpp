#include <string>
#include <sstream>
using namespace std;

class Rectangle
{
public:
	Rectangle(double sideA, double sideB) : sideA(sideA), sideB(sideB), test('a') {}

	Rectangle() : sideA(0), sideB(0) , test('a') {}

	double getSideA()
	{
		return sideA;
	}

	double getSideB()
	{
		return sideB;
	}

	string toString() {
		ostringstream result;
		result << "SideA: " << sideA << "  /  SideB: " << sideB << "	/	" << test << "	/	Perimeter: " << calcPerimeter() << endl;

		return result.str();
	}

	double calcPerimeter() {
		return 2 * this->sideA + 2 * this->sideB;
	}

private:
	double sideA;
	double sideB;
	char test;
};


