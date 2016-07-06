#include "Character.h"
#include "Evironment.h"
#include "PhysicsContorl.h"
#include <iostream>

#define TARGET_HEIGHT 0.7f

void ChekcPersonCapabilities(Character & character)
{
	float maxJumpHeight = PhysicsContorl::CalcMaxJumpHeightOfCharacter(character);
	float timeOfJump = PhysicsContorl::CalcTimeOfJumpOfCharacter(character);
	bool characterCanReachTargetHeight = PhysicsContorl::IsCharacterCapableJumpCertainHeight(character, TARGET_HEIGHT);
	cout << "Max " << character.name << "`s jump height is: " << maxJumpHeight << "m." << endl;
	cout << character.name << "`s time of jump is: " << timeOfJump << "sec." << endl;
	cout << character.name << " is capable to jump " << TARGET_HEIGHT << " m. : " << boolalpha << characterCanReachTargetHeight << endl;
	cout << "======================================" << endl;
}

int main()
{
	Character pesho(1, "Pesho", 95, 3.5f);
	Evironment earth(1, "Erath", 9.80665f);
	pesho.setEnvironment(earth);

	ChekcPersonCapabilities(pesho);

	
	Character gosho(2, "Gosho", 75, 4.5f, earth);

	ChekcPersonCapabilities(gosho);

	return 0;
}