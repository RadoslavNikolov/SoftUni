#pragma once
#include <string>
using namespace std;
class GeometricObject
{
public:
	GeometricObject();
	GeometricObject(double sideA, double sideB);
	~GeometricObject();

	virtual double GetSurface();
	virtual double GetPerimeter();
	virtual double GetVolume();

	virtual string GetType();

protected:
	double sideA;
	double sideB;
};

