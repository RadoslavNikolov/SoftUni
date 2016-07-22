#pragma once
#include "GeometricObject.h"

class Cube : public GeometricObject
{
public:
	Cube();
	Cube(double side);
	~Cube();

	double GetPerimeter();
	double GetSurface();
	double GetVolume();
	string GetType();

private:
	double height;
};

