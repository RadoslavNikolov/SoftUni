#include "Rectangle.h"



Rectangle::Rectangle() : GeometricObject()
{
}

Rectangle::Rectangle(double sideA, double sideB) : GeometricObject(sideA, sideB)
{
}


Rectangle::~Rectangle()
{
}

double Rectangle::GetVolume()
{
	throw "Invalid operation. Rectangle does not have volume!";
}

string Rectangle::GetType()
{
	return typeid(this).name();
}


