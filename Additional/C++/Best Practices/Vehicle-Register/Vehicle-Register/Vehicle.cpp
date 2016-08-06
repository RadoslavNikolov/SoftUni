#include "Vehicle.h"
#include <sstream>
#include "Console.h"

Vehicle::Vehicle(int id, string registrationNum, float weight, short int seatsNum, string chassisNum, string engineNum, string ownerName, string firstRegDateStr, string currentRegDateStr):
	id(id), registrationNumber(registrationNum), weight(weight), seatsNumber(seatsNum), chassisNumber(chassisNum), engineNumber(engineNum), ownerName(ownerName)
{
	try
	{
		this->firstRegistrationDate = Date(firstRegDateStr);
		this->currentRegistrationDate = Date(currentRegDateStr);
	}
	catch (const char* msg)
	{
		Console::print(msg);
	}	
}

Vehicle::~Vehicle()
{
}

int Vehicle::getId() const
{
	return this->id;
}

string Vehicle::getRegistrationNumber() const
{
	return this->registrationNumber;
}

float Vehicle::getWeight() const
{
	return this->weight;
}

short int Vehicle::getSeatsNumber() const
{
	return this->seatsNumber;
}

string Vehicle::getChassisNumber() const
{
	return this->chassisNumber;
}

string Vehicle::getEngineNumber() const
{
	return this->engineNumber;
}

string Vehicle::getOwnerName() const
{
	return this->ownerName;
}

Date Vehicle::getFirstRegistrationDate() const
{
	return this->firstRegistrationDate;
}

Date Vehicle::getCurrentRegistrationDate() const
{
	return this->currentRegistrationDate;
}

string Vehicle::toString() const
{
	ostringstream result;

	result << "Id: " << this->getId() << endl;
	result << "Registration number: " << this->getRegistrationNumber() << endl;
	result << "Weight: " << this->getWeight() << endl;
	result << "Num of seats: " << this->getSeatsNumber() << endl;
	result << "Chassis number: " << this->getChassisNumber() << endl;
	result << "Engine number: " << this->getEngineNumber() << endl;
	result << "Owner name: " << this->getOwnerName() << endl;
	result << "First registration date: " << this->getFirstRegistrationDate().toString();
	result << "Current registraton date: " << this->getCurrentRegistrationDate().toString();

	return result.str();
}
