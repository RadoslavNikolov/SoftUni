#include "PhysicsContorl.h"



PhysicsContorl::PhysicsContorl()
{
}


PhysicsContorl::~PhysicsContorl()
{
}

float PhysicsContorl::CalcMaxJumpHeightOfCharacter(const Character & character)
{
	float displacement = -(0 - character.speed * character.speed) / (2 * character.environment.gravity);

	return displacement;
}

float PhysicsContorl::CalcTimeOfJumpOfCharacter(const Character & character)
{
	float dist = PhysicsContorl::CalcMaxJumpHeightOfCharacter(character);

	float time = sqrt((2 * dist) / character.environment.gravity);
	return time;
}

bool PhysicsContorl::IsCharacterCapableJumpCertainHeight(const Character & character, float targetHeight)
{
	return false;
}
