#include <iostream>
#include "Cube.h"
#include "Parallelepiped.h"
#include "Rectangle.h"
#include "Square.h"
#include "GeometricObject.h"
#include <memory>
#include <vector>
#include <typeinfo>

using namespace std;

typedef  double (GeometricObject::*MemberFunction)();

#define CALL_MEMBER_FN(object,ptrToMember)  ((object).*(ptrToMember))

void FuncCaller(GeometricObject& o, MemberFunction p, const string & funcName)
{
	try
	{
		cout << funcName << CALL_MEMBER_FN(o, p)() << endl;
	}
	catch (const char* msg)
	{
		cout << " >>>>>> " << msg << endl;
	}
	
}

int main()
{
	vector<shared_ptr<GeometricObject>> objectsVector;

	objectsVector.push_back(make_shared<Square>(5));
	objectsVector.push_back(make_shared<Rectangle>(4, 7));
	objectsVector.push_back(make_shared<Parallelepiped>(5, 8, 12));
	objectsVector.push_back(make_shared<Cube>(11));

	for each (shared_ptr<GeometricObject> obj in objectsVector)
	{
		cout << "Object: " << obj->GetType() << endl;

		MemberFunction p = &GeometricObject::GetPerimeter;
		MemberFunction s = &GeometricObject::GetSurface;
		MemberFunction v = &GeometricObject::GetVolume;

		FuncCaller(*obj, p, "Perimeter: ");
		FuncCaller(*obj, s, "Surface: ");
		FuncCaller(*obj, v, "Volume: ");
	
		cout << "-----------------------------------------------------" << endl;
	}
	
	return 0;
}
