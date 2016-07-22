#pragma once
#include "GeometricObject.h"
#include <string>

class Square : public GeometricObject
{
public:
	Square();
	Square(double side);
	~Square();

	double GetVolume();
	string GetType();

};

