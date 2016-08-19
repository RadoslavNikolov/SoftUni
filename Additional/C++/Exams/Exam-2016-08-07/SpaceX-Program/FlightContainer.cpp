#include "FlightContainer.hpp"
#include "Console.hpp"

// Radoslav Nikolov - rado_niko

FlightContainer::FlightContainer()
{
}

FlightContainer::FlightContainer(string name, LocatonTypes locationType) : name(name), locationType(locationType)
{
}

FlightContainer::~FlightContainer()
{
}

bool FlightContainer::addFlight(shared_ptr<Flight> flight)
{
	try
	{
		this->flightsVec.push_back(flight);
		return true;
	}
	catch (const std::exception&)
	{
		return false;
	}

}

void FlightContainer::searchAndPrintFlightByName(string missionName)
{

	for (auto rec : this->flightsVec)
	{
		if (rec->getName() == missionName)
		{
			Console::print(rec->toString());
			return;
		}
	}

	Console::print("There is no flight with name: " + missionName);
}

int FlightContainer::getSuccessfullyLandedFlights()
{
	int successfullyFlightsNum = 0;
	for (auto fl : this->flightsVec)
	{
		if (fl->getIsFlightSuccessfull())
		{
			successfullyFlightsNum += 1;
		}
	}

	return successfullyFlightsNum;
}
