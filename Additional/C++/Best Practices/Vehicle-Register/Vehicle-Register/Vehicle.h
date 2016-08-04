#pragma once
#include <string>
#include "Date.h"
using namespace std;
class Vehicle
{
private:
	int id;
	string registrationNumber;
	float weight;
	short int seatsNumber;
	string chassisNumber;
	string engineNumber;
	string ownerName;
	Date firstRegistrationDate;
	Date currentRegistrationDate;

public:
	Vehicle();
	~Vehicle();

	int getId();
	string getRegistrationNumber();
	float getWeight();
	short int getSeatsNumber();
	string getChassisNumber();
	string getEngineNumber();
	string getOwnerName();
	Date getFirstRegistrationDate();
	Date getCurrentRegistrationDate();

	string toString();

};

