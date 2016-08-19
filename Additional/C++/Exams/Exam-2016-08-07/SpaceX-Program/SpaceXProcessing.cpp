
// Radoslav Nikolov - rado_niko
#include "SpaceXProcessing.hpp"
#include <memory>
#include "Flight.hpp"
#include <iostream>
#include <string>
#include "Console.hpp"
#include "FlightContainer.hpp"
#include "Utils.hpp"
#include <thread>

using namespace std;

typedef map<string, shared_ptr<FlightContainer>> ContainersDB;
ContainersDB containerDb;


void SpaceXProcessing::addNewFlight()
{
	vector<string> input;
	Console::print("Enter new flight in format with delimiter ':' [LandingPlace:LandingType(Terestrial:Floating):MissionName:RocketName(Falcon 9, Falcon 9.1, Falcon Heavy):IgnitionDateTime(dd.MM.yyyy.HH.mm.ss):LandingDateTime(dd.MM.yyyy.HH.mm.ss):PayLoad:IsSucessfully(Yes,No):Latidute,Longitude]");	

	try
	{
		Console::getInputLine(input);
	}
	catch (const exception&)
	{
		Console::print(" >>>>>> Invalid input ");
	}

	if (input.size() != 10)
	{
		Console::print(" >>>>>> Invalid input ");
		return;
	}

	// Създаваме контейнер, ако не съществува
	ContainersDB::iterator it = containerDb.find(input[0]);
	if (it == containerDb.end())
	{
		containerDb[input[0]] = make_shared<FlightContainer>(input[0], Utils::stringToLocationTypesEnum(input[1]));
	}
	// Край


	string missionName = input[2];
	RocketTypes rocketType = Utils::stringToRocketTypesEnum(input[3]);
	// По някаква причина това хвърля странни грешшки, но не чупи програмата. Нямам време за да разбера защо :(
	DateTime ignitionDate = DateTime(input[4]);
	DateTime landingDate = DateTime(input[5]);
	// Край
	float payLoad = stof(input[6]);
	bool isSuccessfull = input[7] == "Yes" || input[7] == "yes";
	GeoLocation location = GeoLocation(stod(input[8]), stod(input[9]));

	shared_ptr<Flight> p;
	try
	{
		containerDb[input[0]]->addFlight(make_shared<Flight>(missionName, rocketType, ignitionDate, landingDate, payLoad, isSuccessfull, location));
	}
	catch (const char* msg)
	{
		Console::print(" >>>>>> " + *msg);
	}

}


void searchByName(string flightName, shared_ptr<FlightContainer> container)
{
	container->searchAndPrintFlightByName(flightName);
}


void SpaceXProcessing::searchForFlightByName()
{
	Console::print("Enter searching flight name: ");

	string flightName;
	getline(cin, flightName);

	vector<shared_ptr<thread>> threadVector;

	for (auto db : containerDb)
	{
		threadVector.push_back(make_shared<thread>(thread(searchByName, flightName, db.second)));
	}

	for (unsigned int i = 0; i < threadVector.size(); i++)
	{
		threadVector[i]->join();
	}
}

