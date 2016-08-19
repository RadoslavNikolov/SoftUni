#include "Flight.hpp"
#include <sstream>

// Radoslav Nikolov - rado_niko

Flight::Flight()
{
}

Flight::Flight(string name, RocketTypes rocketType, DateTime ignitionTime, DateTime landingTime, float payLoad, bool isSuccess, GeoLocation location) : 
	name(name), rocketType(rocketType), ignitionDateTime(ignitionTime), landingDateTime(landingTime), payLoad(payLoad), isSuccess(isSuccess), location(location)
{
}


Flight::~Flight()
{
}

string Flight::getName()
{
	return this->name;
}


DateTime Flight::getIgnitionDateTime()
{
	return this->ignitionDateTime;
}

DateTime Flight::getLandingDateTime()
{
	return this->landingDateTime;
}

float Flight::getPayLoad()
{
	return this->payLoad;
}

bool Flight::getIsFlightSuccessfull()
{
	return this->isSuccess;
}

GeoLocation Flight::getLocation()
{
	return this->location;
}

double Flight::getPayLoadInLibres()
{
	return 0.0;
}

string Flight::toString()
{
	ostringstream result;
	result << "Flight name: " << this->getPayLoad() << endl;
	//result << "Ignition time:  " << this->getIgnitionDateTime.toString() << endl;
	result << "Landing time: " << this->getLandingDateTime().toString() << endl;
	result << "Pay load in kg: " << this->getPayLoad() << endl;
	result << "Pay load in libres: " << this->getPayLoadInLibres() << endl;
	result << "Is successfull: " << this->getIsFlightSuccessfull() << endl;
	result << "Location latitude: " << this->getLocation().getLatitude() << endl;
	result << "Location longitude: " << this->getLocation().getLongitude() << endl;

	return result.str();
}


