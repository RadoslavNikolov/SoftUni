#include "Character.h"



Character::Character()
{
}

Character::Character(unsigned int id, string name, double mass, float speed) : Object(id, mass, speed), name(name)
{
}

Character::Character(unsigned int id, string name, double mass, float speed, const Evironment & environment) : Object(id, mass, speed, environment), name(name)
{
}


Character::~Character()
{
}
