#include "Square.h"



Square::Square() : GeometricObject()
{
}

Square::Square(double side) : GeometricObject(side, side)
{
}


Square::~Square()
{
}

double Square::GetVolume()
{
	throw "Invalid operation. Square does not have volume!";
}

string Square::GetType()
{
	return typeid(this).name();
}


