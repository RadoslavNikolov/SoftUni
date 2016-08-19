#pragma once
// Radoslav Nikolov - rado_niko
#include "DateTime.hpp"
#include "Utils.hpp"
#include "GeoLocation.hpp"



class Flight
{
private:
	string name;
	RocketTypes rocketType; 
	DateTime ignitionDateTime;
	DateTime landingDateTime;
	float payLoad;
	float flightDuration;
	bool isSuccess;
	GeoLocation location;

public:
	Flight();
	Flight(string name, RocketTypes rocketType, DateTime ignitionTime, DateTime landingTime, float payLoad, bool isSuccess, GeoLocation location);
	~Flight();

	string getName();
	//RocketTypes getRocketType();
	DateTime getIgnitionDateTime();
	DateTime getLandingDateTime();
	float getPayLoad();
	bool getIsFlightSuccessfull();
	GeoLocation getLocation();
	double getPayLoadInLibres();

	string toString();
};


