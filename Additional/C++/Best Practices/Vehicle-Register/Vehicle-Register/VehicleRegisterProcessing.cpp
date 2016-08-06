#include "VehicleRegisterProcessing.h"
#include <memory>
#include "Vehicle.h"
#include <iostream>
#include <string>
#include "Console.h"
#include <thread>

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
	Console::print("Enter new vehicle in format with delimiter ':' [RegNumber:Weight:SeatsNum:ChassisNum:EngineNum:OwnerName:FirsRegDate(dd.MM.yyyy):CurrentregDay(dd.MM.yyyy)]");

	try
	{
		Console::getInputLine(input);
	}
	catch (const exception&)
	{
		Console::print(" >>>>>> Invalid input ");
	}

	if (input.size() != 8)
	{
		Console::print(" >>>>>> Invalid input ");
		return;
	}

	shared_ptr<Vehicle> p;

	try
	{
		float weight = stof(input[1]);
		short int seatsNum = stoi(input[2]);

		if (seatsNum < 2 || weight < 500)
		{
			motorCyclesDB[input[0]] = make_shared<Vehicle>(motorCyclesDbCounter++, input[0], stof(input[1]), stoi(input[2]), input[3], input[4], input[5], input[6], input[7]);

			Console::print(" >>>>>> Added motorcycle with registration number: " + input[0]);
		}
		else if (weight > 2500)
		{
			trucksDB[input[0]] = make_shared<Vehicle>(trucksDbCounter++, input[0],stof(input[1]), stoi(input[2]), input[3], input[4], input[5], input[6], input[7]);

			Console::print(" >>>>>> Added truck with registration number: " + input[0]);
		}
		else
		{
			carsDB[input[0]] = make_shared<Vehicle>(carsDbCounter++, input[0], stof(input[1]), stoi(input[2]), input[3], input[4], input[5], input[6], input[7]);

			Console::print(" >>>>>> Added car with registration number: " + input[0]);
		}

	}
	catch (const char* msg)
	{
		Console::print(" >>>>>> " + *msg);
	}

}

template<typename Func>
bool searchMapByKey(map<string, shared_ptr<Vehicle>> const & db, const string& regNum, Func const &printFunc);

void searchForCehicleByRegNumber(string regNum, short int vehicleType)
{	
	auto printLambda = [](string v) {Console::print(v); };

	switch (vehicleType)
	{
	case 0:
		if (!searchMapByKey(carsDB, regNum, printLambda))
		{
			printLambda("There is no registration number: " + regNum + " in cars database");
		}
		
		break;
	case 1:
		if (!searchMapByKey(trucksDB, regNum, printLambda))
		{
			printLambda("There is no registration number: " + regNum + " in trucks database!");
		}

		break;
	case 2:
		if (!searchMapByKey(motorCyclesDB, regNum, printLambda))
		{
			printLambda("There is no registration number: " + regNum + " in motorcycles database!");
		}
		break;
	}
}

template<typename Func>
bool searchMapByKey(map<string, shared_ptr<Vehicle>> const & db, string const & regNum, Func const &printFunc)
{
	map<basic_string<char>, shared_ptr<Vehicle>>::const_iterator it;

	it = db.find(regNum);

	if (it != db.end())
	{
		printFunc(it->second->toString());
		return true;
	}

	return false;
}

void VehicleRegisterProcessing::searchVehicleByRegNum()
{
	Console::print("Enter searching registration number: ");

	string regNum;
	getline(cin, regNum);
	
	vector<shared_ptr<thread>> threadVector;

	for (unsigned long long i = 0; i < 3; i++)
	{
		threadVector.push_back(make_shared<thread>(thread(searchForCehicleByRegNumber, regNum, i)));
	}

	for (int i = 0; i < threadVector.size(); i++)
	{
		threadVector[i]->join();
	}
}

