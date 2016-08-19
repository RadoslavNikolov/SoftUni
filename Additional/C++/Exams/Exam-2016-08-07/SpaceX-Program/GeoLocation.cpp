#include "GeoLocation.hpp"

// Radoslav Nikolov - rado_niko


GeoLocation::GeoLocation() : latitude(0.00f), longitude(0.00f)
{
}

GeoLocation::GeoLocation(double latitude, double longitude) : latitude(latitude), longitude(longitude)
{
}


GeoLocation::~GeoLocation()
{
}

double GeoLocation::getLatitude()
{
	return this->latitude;
}

double GeoLocation::getLongitude()
{
	return this->longitude;
}
