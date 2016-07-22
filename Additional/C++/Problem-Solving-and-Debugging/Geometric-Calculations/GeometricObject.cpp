#include "GeometricObject.h"



GeometricObject::GeometricObject() : sideA(0.00f), sideB(0.00f)
{
}

GeometricObject::GeometricObject(double sideA, double sideB) : sideA(sideA), sideB(sideB)
{
}


GeometricObject::~GeometricObject()
{
}

double GeometricObject::GetSurface()
{
	return sideA * sideB;
}

double GeometricObject::GetPerimeter()
{
	return 2.00f * sideA + 2.00f * sideB;
}

double GeometricObject::GetVolume()
{
	return 0.0;
}

string GeometricObject::GetType()
{
	return "";
}
