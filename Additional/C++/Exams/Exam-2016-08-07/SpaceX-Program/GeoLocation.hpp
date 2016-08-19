// Radoslav Nikolov - rado_niko
#pragma once
class GeoLocation
{
private:
	double latitude;
	double longitude;

public:
	GeoLocation();
	GeoLocation(double latitude, double longitude);
	~GeoLocation();

	double getLatitude();
	double getLongitude();
};

