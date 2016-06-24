#include <iostream>
#include "Rectangle.cpp"
#include "Cube.cpp"

double calcRectPerimeter(Rectangle &rect) 
{
	return 2 * rect.getSideA() + 2 * rect.getSideB();
}

double calcCubeVolume(const Cube &cube)
{
	////������� �� �������� �� ���� ���� �����. ���� �� ������� ������ ����������� �� ���������
	//cube.setCubeSide(20);

	////������� �� �������� �� ���� �������� ���� �������. �� ������� ���������. ������ �� Private ������� �� �����. ���� ���� ���� Reflection, �� �� ������� �������� � �������.
	//*((double *)(&cube)) = 20;

	double cubeSide = cube.getCubeSide();

	return cubeSide * cubeSide * cubeSide;
}

int main() 
{
	Rectangle rect(5, 8);
	cout << rect.toString() << endl;

	cout << calcRectPerimeter(rect) << endl;

	//������ �� private ������� �� ����� � �������� ������ � �������.
	*((double *)(&rect)) = 20;
	*(((double *)(&rect)) + 1) = 20;
	*(char *)(((double *)(&rect)) + 2) = 'b';
	 
	cout << rect.toString() << endl;

	Cube cube(5);
	cout << "Perimeter of cube: " << cube.calcPerimeter() << endl;
	cout << "Surface of cube: " << cube.calcSurface() << endl;
	cout << "Volume of cube: " << cube.calcVolume() << endl;

	cout << endl << "Cude side: " << cube.getCubeSide() << endl;
	cout << "Volume of cube calc by external function: " << calcCubeVolume(cube) << endl;
	cout << "Cude side: " << cube.getCubeSide() << endl;


	return 0;
}