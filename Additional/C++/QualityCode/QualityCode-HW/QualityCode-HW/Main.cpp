#include "Character.h"
#include "Evironment.h"
#include "PhysicsContorl.h"
#include <iostream>

int main()
{
	Character pesho(1, "Pesho", 95, 3.5f);
	Evironment earth(1, "Erath", 9.80665f);
	pesho.setEnvironment(earth);

	float maxJumpHeight = PhysicsContorl::CalcMaxJumpHeightOfCharacter(pesho);
	float timeOfJump = PhysicsContorl::CalcTimeOfJumpOfCharacter(pesho);
	cout << "Max Pesho`s jump height is: " << maxJumpHeight << "m." << endl;
	cout << "Pesho`s time of jump is: " << timeOfJump << "sec." << endl;

	return 0;
}