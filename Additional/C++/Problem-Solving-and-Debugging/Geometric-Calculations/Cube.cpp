#include "Cube.h"



Cube::Cube()
{
}

Cube::Cube(double side) : GeometricObject(side, side)
{
	this->height = side;
}


Cube::~Cube()
{
}

double Cube::GetPerimeter()
{
	throw "Invalid operation. Cube does not have perimeter!";
}

double Cube::GetSurface()
{
	return 6.00f * sideA * sideB;
}

double Cube::GetVolume()
{
	return sideA * sideB * height;
}

string Cube::GetType()
{
	return typeid(this).name();
}
