#pragma once
// Radoslav Nikolov - rado_niko
#include <vector>
#include <memory>
#include <map>
#include "Flight.hpp"
#include "Utils.hpp"

using namespace std;

class FlightContainer
{
	vector<shared_ptr<Flight>> flightsVec;

public:
	FlightContainer();
	FlightContainer(string name, LocatonTypes locationType);
	~FlightContainer();

	string name;
	LocatonTypes locationType;
	
	bool addFlight(shared_ptr<Flight> flight);

	void searchAndPrintFlightByName(string missionName);

	int getSuccessfullyLandedFlights();

};
