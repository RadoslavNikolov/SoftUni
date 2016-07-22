#include "Parallelepiped.h"



Parallelepiped::Parallelepiped() : GeometricObject(0.00f,0.00f)
{
	this->height = 0.00f;
}

Parallelepiped::Parallelepiped(double sideA, double sideB, double height) : GeometricObject(sideA, sideB)
{
	this->height = height;
}


Parallelepiped::~Parallelepiped()
{
}

double Parallelepiped::GetSurface()
{
	double surface = 2.00f * (sideA * sideB) + 2.00f * ((sideA * height) + (sideB * height));

	return surface;
}

double Parallelepiped::GetVolume()
{
	return sideA * sideB * height;
}

double Parallelepiped::GetPerimeter()
{
	throw "Invalid operation. Parallelepiped does not have perimeter!";
}

string Parallelepiped::GetType()
{
	return typeid(this).name();
}
