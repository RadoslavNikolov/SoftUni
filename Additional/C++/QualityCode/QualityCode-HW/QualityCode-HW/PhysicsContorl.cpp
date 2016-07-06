#include "PhysicsContorl.h"



PhysicsContorl::PhysicsContorl()
{
}


PhysicsContorl::~PhysicsContorl()
{
}

float PhysicsContorl::CalcMaxJumpHeightOfCharacter(const Character & character)
{
	// d = (Vi - Vo)^2/2*g
	float displacement = ((0 - character.speed) * (0 - character.speed)) / (2 * character.environment.gravity);

	return displacement;
}

float PhysicsContorl::CalcTimeOfJumpOfCharacter(const Character & character)
{
	// t = sqrt(2 * d)
	float displacement = PhysicsContorl::CalcMaxJumpHeightOfCharacter(character);
	float time = sqrt((2 * displacement) / character.environment.gravity);

	return time;
}

bool PhysicsContorl::IsCharacterCapableJumpCertainHeight(const Character & character, float targetHeight)
{
	float displacement = CalcMaxJumpHeightOfCharacter(character);

	if (displacement >= targetHeight) return true;

	return false;
}
