#include <iostream>
#include <ostream>
#include <sstream>
#include <algorithm>
#include <vector>

using namespace std;

#pragma region Building class declaration
class Buildidng
{
private:
	string _ownerCompanyName;
	unsigned short _floorNum;
	unsigned short _officesNum;
	int _employeesNum;
	int _freeWorkingSpaces;

public:
	enum BuildingCondition { employeesCond, freeWorkinfSpacesCond, buildingCoeffcientCond, peoplePerFloorCond, officesPerFloorCond, peoplePerOfficeCond};

	inline Buildidng(string ownerComapanyName, unsigned short floorNum, unsigned short officesNum, int employeesNum, int freeWrokingSpace)
	{
		_ownerCompanyName = ownerComapanyName;
		_floorNum = floorNum;
		_officesNum = officesNum;
		_employeesNum = employeesNum;
		_freeWorkingSpaces = freeWrokingSpace;
	}

	inline Buildidng()
	{
		_ownerCompanyName = "No name";
		_floorNum = 0;
		_officesNum = 0;
		_employeesNum = 0;
		_freeWorkingSpaces = 0;	
	}

	/*inline ~Buildidng()
	{
		cout << "Released" << " Building " << getOwnerCompanyName() << endl;
	}*/

	inline string getOwnerCompanyName() const { return _ownerCompanyName; };
	inline unsigned short getFloorNum() const { return _floorNum; };
	inline  unsigned short getOfficesNum() const { return _officesNum; };
	inline int getEmployeesNum() const { return _employeesNum; };
	inline int getFreeWorkingSpace() const { return _freeWorkingSpaces; };

	string toString() const;
	float peoplePerFloor() const;
	float officesPerFloor() const;
	float peoplePerOffice() const;
	float buildingCoefficient() const;
};


string Buildidng::toString() const {
	ostringstream result;
	result << "Company name: " << getOwnerCompanyName() << endl
		<< "Floors: " << getFloorNum() << endl
		<< "Offices: " << getOfficesNum() << endl
		<< "Employees: " << getEmployeesNum() << endl
		<< "Free working spaces: " << getFreeWorkingSpace() << endl
		<< "Building coefficient: " << buildingCoefficient() << endl;
	return result.str();
}

float Buildidng::peoplePerFloor() const
{
	if (getFloorNum() == 0)
	{
		cout << "Devide by zero exception." << endl;
		cout << getOwnerCompanyName() << " building has zero floors" << endl;
		return 0.0;
	}

	return getEmployeesNum() / float(getFloorNum());
}

float Buildidng::officesPerFloor() const
{
	if (getFloorNum() == 0)
	{
		cout << "Devide by zero exception." << endl;
		cout << getOwnerCompanyName() << " building has zero floors" <<endl;
		return 0.0;
	}

	return getOfficesNum() / float(getFloorNum());
}

float Buildidng::peoplePerOffice() const
{
	if (getOfficesNum() == 0)
	{
		cout << "Devide by zero exception." << endl;
		cout << getOwnerCompanyName() << " building has zero offices" << endl;
		return 0.0;
	}
	return getEmployeesNum() / float(getOfficesNum());
}

float Buildidng::buildingCoefficient() const
{
	if (getFreeWorkingSpace() == 0 || (getEmployeesNum() / getFreeWorkingSpace()) == 0)
	{
		cout << "Devide by zero exception." << endl;
		cout << getOwnerCompanyName() << " building has zero employees or free working spaces" << endl;
		return 0.0;
	}

	return getEmployeesNum() / float((getEmployeesNum() / float(getFreeWorkingSpace())));
}

#pragma endregion


#pragma region Custom defined predicates

auto cmpBuildingEmployeesAsc = [](Buildidng const & a, Buildidng const & b)
{
	return a.getEmployeesNum() != b.getEmployeesNum() ? a.getEmployeesNum() < b.getEmployeesNum() : a.getEmployeesNum() == b.getEmployeesNum();
};

auto cmpBuildingFreeWorkingSpacesAsc = [](Buildidng const & a, Buildidng const & b)
{
	return a.getFreeWorkingSpace() != b.getFreeWorkingSpace() ? a.getFreeWorkingSpace() < b.getFreeWorkingSpace() : a.getFreeWorkingSpace() == b.getFreeWorkingSpace();
};

auto cmpBuildingCoefficientAsc = [](Buildidng const & a, Buildidng const & b)
{
	return a.buildingCoefficient() != b.buildingCoefficient() ? a.buildingCoefficient() < b.buildingCoefficient() : a.buildingCoefficient() == b.buildingCoefficient();
};

auto cmpPeoplePerFloorAsc = [](Buildidng const & a, Buildidng const & b)
{
	return a.peoplePerFloor() != b.peoplePerFloor() ? a.peoplePerFloor() < b.peoplePerFloor() : a.peoplePerFloor() == b.peoplePerFloor();
};

auto cmpOfficesPerFloorAsc = [](Buildidng const & a, Buildidng const & b)
{
	return a.officesPerFloor() != b.officesPerFloor() ? a.officesPerFloor() < b.officesPerFloor() : a.officesPerFloor() == b.officesPerFloor();
};

auto cmpPeoplePerOfficeAsc = [](Buildidng const & a, Buildidng const & b)
{
	return a.peoplePerOffice() != b.peoplePerOffice() ? a.peoplePerOffice() < b.peoplePerOffice() : a.peoplePerOffice() == b.peoplePerOffice();
};

#pragma endregion



#pragma region Custom sorter functions

void sortBuildingsByCondition(vector<Buildidng>& buildings, Buildidng::BuildingCondition condition)
{
	switch (condition)
	{
	case Buildidng::employeesCond:
		sort(buildings.begin(), buildings.end(), cmpBuildingEmployeesAsc);
		break;
	case Buildidng::freeWorkinfSpacesCond: 
		sort(buildings.begin(), buildings.end(), cmpBuildingFreeWorkingSpacesAsc);
		break;
	case Buildidng::buildingCoeffcientCond:
		sort(buildings.begin(), buildings.end(), cmpBuildingCoefficientAsc);
		break;
	case Buildidng::peoplePerFloorCond:
		sort(buildings.begin(), buildings.end(), cmpPeoplePerFloorAsc);
		break;
	case Buildidng::officesPerFloorCond:
		sort(buildings.begin(), buildings.end(), cmpOfficesPerFloorAsc);
		break;
	case Buildidng::peoplePerOfficeCond:
		sort(buildings.begin(), buildings.end(), cmpPeoplePerOfficeAsc);
		break;
	default: break;
	}
};

#pragma endregion


#pragma region Custom helper functions
void PrintBuildings(vector<Buildidng>& buildings)
{
	for (vector<Buildidng>::iterator i = buildings.begin(); i != buildings.end(); ++i)
	{
		//cout << businessPark[i].toString() << endl;
		string s = i->toString();
		cout << i->toString() << endl;
	}
};

Buildidng GetBuildingByCondition(vector<Buildidng>& buildidngs, bool mostPerFloor, Buildidng::BuildingCondition conditon)
{
	sortBuildingsByCondition(buildidngs, conditon);

	if (mostPerFloor)
	{
		return buildidngs[buildidngs.size() - 1];
	}
	else
	{
		return buildidngs[0];
	}
}

#pragma endregion


int main()
{
	vector<Buildidng> businessPark;
	businessPark.push_back(Buildidng("XYZ industries", 6, 127, 600, 196));
	businessPark.push_back(Buildidng("Rapid Develepment Crew", 8, 210, 822, 85));
	businessPark.push_back(Buildidng("SoftUni", 11, 106, 200, 60));

	cout << "Business park content: " << endl;
	PrintBuildings(businessPark);
	Buildidng buildidng;

	buildidng = GetBuildingByCondition(businessPark, true, Buildidng::employeesCond);
	cout << "Most employees: " << buildidng.getEmployeesNum() << "  in " << buildidng.getOwnerCompanyName() << "Building" << endl;

	buildidng = GetBuildingByCondition(businessPark, false, Buildidng::employeesCond);
	cout << "Least employees: " << buildidng.getEmployeesNum() << "  in " << buildidng.getOwnerCompanyName() << "Building" << endl;

	buildidng = GetBuildingByCondition(businessPark, true, Buildidng::freeWorkinfSpacesCond);
	cout << "Most free working spaces: " << buildidng.getFreeWorkingSpace() << "  in " << buildidng.getOwnerCompanyName() << "Building" << endl;

	buildidng = GetBuildingByCondition(businessPark, false, Buildidng::freeWorkinfSpacesCond);
	cout << "Least free working spaces: " << buildidng.getFreeWorkingSpace() << "  in " << buildidng.getOwnerCompanyName() << "Building" << endl;

	buildidng = GetBuildingByCondition(businessPark, true, Buildidng::buildingCoeffcientCond);
	cout << "Highest coefficient: " << buildidng.buildingCoefficient() << "  in " << buildidng.getOwnerCompanyName() << "Building" << endl;

	buildidng = GetBuildingByCondition(businessPark, false, Buildidng::buildingCoeffcientCond);
	cout << "Lowest coefficient: " << buildidng.buildingCoefficient() << "  in " << buildidng.getOwnerCompanyName() << "Building" << endl;

	buildidng = GetBuildingByCondition(businessPark, true, Buildidng::peoplePerFloorCond);
	cout << "Most people per floor: " << buildidng.peoplePerFloor() << "  in " << buildidng.getOwnerCompanyName() << "Building" << endl;

	buildidng = GetBuildingByCondition(businessPark, false, Buildidng::peoplePerFloorCond);
	cout << "Least people per floor: " << buildidng.peoplePerFloor() << "  in " << buildidng.getOwnerCompanyName() << "Building" << endl;

	buildidng = GetBuildingByCondition(businessPark, true, Buildidng::officesPerFloorCond);
	cout << "Most offices per floor: " << buildidng.officesPerFloor() << "  in " << buildidng.getOwnerCompanyName() << "Building" << endl;

	buildidng = GetBuildingByCondition(businessPark, false, Buildidng::officesPerFloorCond);
	cout << "Least offices per floor: " << buildidng.officesPerFloor() << "  in " << buildidng.getOwnerCompanyName() << "Building" << endl;

	buildidng = GetBuildingByCondition(businessPark, true, Buildidng::peoplePerOfficeCond);
	cout << "Most people per office: " << buildidng.peoplePerOffice() << "  in " << buildidng.getOwnerCompanyName() << "Building" << endl;

	buildidng = GetBuildingByCondition(businessPark, false, Buildidng::peoplePerOfficeCond);
	cout << "Least people per office: " << buildidng.peoplePerOffice() << "  in " << buildidng.getOwnerCompanyName() << "Building" << endl;

}


