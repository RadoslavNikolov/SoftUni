#include "Car.h"
#include <iostream>

using namespace std;

void repairEngine(Car & aCar)
{
	if (!aCar.isEngineBroken) return;

	aCar.isEngineBroken = false;
	std::cout << "Engine repaired!" << endl;;
}

int main()
{
	Car aCar(true);

	cout << aCar.getIsEngineBroken() << endl;
	repairEngine(aCar);

	return 0;
}
