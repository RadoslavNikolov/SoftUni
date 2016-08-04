#include "Vehicle.h"
#include <sstream>
using namespace std;


Vehicle::Vehicle()
{
	throw "Thre is no arguments passed";
}


Vehicle::~Vehicle()
{
}

int Vehicle::getId()
{
	return this->id;
}

string Vehicle::getRegistrationNumber()
{
	return this->registrationNumber;
}

float Vehicle::getWeight()
{
	return this->weight;
}

short int Vehicle::getSeatsNumber()
{
	return this->seatsNumber;
}

string Vehicle::getChassisNumber()
{
	return this->chassisNumber;
}

string Vehicle::getEngineNumber()
{
	return this->engineNumber;
}

string Vehicle::getOwnerName()
{
	return this->ownerName;
}

Date Vehicle::getFirstRegistrationDate()
{
	return this->firstRegistrationDate;
}

Date Vehicle::getCurrentRegistrationDate()
{
	return this->currentRegistrationDate;
}

string Vehicle::toString()
{
	ostringstream result;

	result << "Id: " << this->getId() << endl;
	result << "Registration number: " << this->getRegistrationNumber() << endl;
	result << "Weight: " << this->getWeight() << endl;
	result << "Num of seats: " << this->getSeatsNumber() << endl;
	result << "Chassis number: " << this->getChassisNumber() << endl;
	result << "Engine number: " << this->getEngineNumber() << endl;
	result << "Owner name: " << this->getOwnerName() << endl;
	result << "First registration date: " << this->getFirstRegistrationDate().toString() << endl;
	result << "Current registraton date: " << this->getCurrentRegistrationDate().toString() << endl;

	return string();
}
