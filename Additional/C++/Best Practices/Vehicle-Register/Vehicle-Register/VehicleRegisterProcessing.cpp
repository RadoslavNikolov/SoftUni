#include "VehicleRegisterProcessing.h"
#include <iostream>
#include <map>
#include <memory>
#include <vector>
#include "Vehicle.h"
#include "SplitString.h"

using namespace std;

typedef map<string, shared_ptr<Vehicle>> CarsDatabase;
CarsDatabase carsDB;
int carsDbCounter = 1;

typedef map<string, shared_ptr<Vehicle>> TrucksDatabase;
TrucksDatabase trucksDB;
int trucksDbCounter = 1;

typedef map<string, shared_ptr<Vehicle>> MotorCyclesDatabase;
MotorCyclesDatabase motorCyclesDB;
int motorCyclesDbCounter = 1;


void VehicleRegisterProcessing::addNewVehicle()
{
	vector<string> input;
	cout << "Enter new vehicle in format with delimiter ':' [RegNumber:Weight:SeatsNum:ChassisNum:EngineNum:OwnerName:FirsRegDate(dd.MM.yyyy):CurrentregDay(dd.MM.yyyy)]" << endl;
	VehicleRegisterProcessing::getInputLine(input);

	if (input.size() != 8)
	{
		cout << " >>>>>> Invalid input " << endl;;
		return;
	}

	shared_ptr<Vehicle> p;

	try
	{
		/*p = getItemByRegNum(input[0]);
		if (p != nullptr)
		{
			cout << "Item with this id already exists.";
			return;
		}*/

		float weight = stof(input[1]);
		short int seatsNum = stoi(input[2]);

		if (seatsNum < 2 || weight < 500)
		{
			motorCyclesDB[input[0]] = make_shared<Vehicle>(motorCyclesDbCounter++, input[0], input[1], input[2], input[3], input[4], input[5], input[6], input[7]);
			cout << " >>>>>> Added motorcycle with registration number: " << input[0] << endl;
		}
		else if (weight > 2500)
		{
			trucksDB[input[0]] = make_shared<Vehicle>(trucksDbCounter++, input[0], input[1], input[2], input[3], input[4], input[5], input[6], input[7]);
			cout << " >>>>>> Added truck with registration number: " << input[0] << endl;
		}
		else
		{
			carsDB[input[0]] = make_shared<Vehicle>(carsDbCounter++, input[0], input[1], input[2], input[3], input[4], input[5], input[6], input[7]);
			cout << " >>>>>> Added car with registration number: " << input[0] << endl;
		}


	}
	catch (const char* msg)
	{
		cout << " >>>>>> " << msg << endl;
	}


	cout << "Add new vehicle" << endl;
}

void VehicleRegisterProcessing::searchVehicleByRegNum()
{
	cout << "Search vehicle by id" << endl;
}

void VehicleRegisterProcessing::getInputLine(vector<string> &input)
{
	string segment;
	cin >> segment;

	SplitString s(segment);
	input = s.split(':');
}
