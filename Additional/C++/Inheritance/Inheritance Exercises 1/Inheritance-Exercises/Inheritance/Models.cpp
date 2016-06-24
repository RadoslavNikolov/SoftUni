#include <string>
#include <sstream>
using namespace std;

class Vehicle
{
public:
	int numberOfUsers;
	float maxSpeed;

	virtual string toString()
	{
		ostringstream result;
		result << "Number of users: " << numberOfUsers << endl
			<< "Max speed: " << maxSpeed << endl;
		return result.str();
	}

protected:
	int test;
private:

};

class Bicycle : public Vehicle
{
public:
	int numberOfGears;

	string toString() 
	{
		ostringstream result;
		result << Vehicle::toString()
			<< "Number of gears: " << numberOfGears << endl;

		return result.str();
	}
private:

};

class Car : public Vehicle
{
public:
	float horsePower;
	int numberofSeats;
	float rimSize;
	string make;
	string model;

	string toString()
	{
		ostringstream result;
		result << Vehicle::toString()
			<< "Horse power: " << horsePower << endl
			<< "Number of seats: " << numberofSeats << endl
			<< "Rim size: " << rimSize << endl
			<< "Make: " << make << endl
			<< "Model: " << model << endl;

		return result.str();
	}

private:

};

class PickUpTruck : public Car
{
public:
	float tonnage;

	string toString()
	{
		ostringstream result;
		result << Car::toString()
			<< "Tonnage: " << tonnage << endl;

		return result.str();
	}

private:

};




