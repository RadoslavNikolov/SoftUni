#pragma once
#include "Date.h"

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
	Vehicle(int id, string registrationNum, float weight, short int seatsNum, string chassisNum, string engineNum, string ownerName, string firstRegDateStr, string currentRegDateStr);

	~Vehicle();

	int getId() const;
	string getRegistrationNumber() const;
	float getWeight() const;
	short int getSeatsNumber() const;
	string getChassisNumber() const;
	string getEngineNumber() const;
	string getOwnerName() const;
	Date getFirstRegistrationDate() const;
	Date getCurrentRegistrationDate() const;
	string toString() const;
};

