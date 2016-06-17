#include <iostream>
#include "Models.cpp"
#include "Models1.cpp"

using namespace std;

int main()
{
	/*Bicycle myBike;
	myBike.numberOfUsers = 1;
	myBike.numberOfGears = 21;
	myBike.maxSpeed = 50;

	Car myCar;
	myCar.numberOfUsers = 1;
	myCar.numberofSeats = 5;
	myCar.maxSpeed = 200;
	myCar.horsePower = 100;
	myCar.rimSize = 15;
	myCar.make = "Toyota";
	myCar.model = "Auris";


	PickUpTruck myTruck;
	myTruck.numberOfUsers = 1;
	myTruck.numberofSeats = 3;
	myTruck.maxSpeed = 180;
	myTruck.horsePower = 200;
	myTruck.rimSize = 18;
	myTruck.make = "Ford";
	myTruck.model = "F50";
	myTruck.tonnage = 3;

	cout << myBike.toString() << endl << endl;
	cout << myCar.toString() << endl << endl;
	cout << myTruck.toString() << endl;*/


	Rectangle rect;
	rect.sideA = 5;
	rect.sideB = 10;

	cout << "Perimeter: " << rect.perimeter() << endl;
	cout << "Surface: " << rect.surface() << endl;

	Circle c;
	c.radius = 10;

	cout << "Perimeter: " << c.perimeter() << endl;
	cout << "Surface: " << c.surface() << endl;
}