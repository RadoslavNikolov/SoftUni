#pragma once
#include "GeometricObject.h"

class Parallelepiped : public GeometricObject
{
public:
	Parallelepiped();
	Parallelepiped(double sideA, double sideB, double height);
	~Parallelepiped();

	double GetSurface();
	double GetVolume();
	double GetPerimeter();
	string GetType();

private:
	double height;
};

