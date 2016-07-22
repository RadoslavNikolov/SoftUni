#pragma once
#include "GeometricObject.h"

class Rectangle : public GeometricObject
{
public:
	Rectangle();
	Rectangle(double sideA, double sideB);
	~Rectangle();

	double GetVolume();
	string GetType();
};

