#pragma once
#include "Character.h"

class PhysicsContorl
{
public:
	PhysicsContorl();
	~PhysicsContorl();

	static float CalcMaxJumpHeightOfCharacter(const Character & character);
	static float CalcTimeOfJumpOfCharacter(const Character & character);
	static bool IsCharacterCapableJumpCertainHeight(const Character & character, float targetHeight);
};

