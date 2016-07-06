#pragma once
#include "Object.h"

class Character : public Object
{
public:
	Character();
	Character(unsigned int id, string name, double mass, float speed);
	Character(unsigned int id, string name, double mass, float speed, const Evironment & environment);
	~Character();

	string name;
};

