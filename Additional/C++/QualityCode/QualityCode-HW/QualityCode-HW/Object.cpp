#include "Object.h"



Object::Object()
{
}

Object::Object(unsigned int id, double mass, float speed) : id(id), mass(mass), speed(speed)
{
}

Object::Object(unsigned int id, double mass, float speed, const Evironment & environment) : id(id), mass(mass), speed(speed), environment(environment)
{
}


Object::~Object()
{
}

void Object::setEnvironment(Evironment & environment)
{
	this->environment = environment;
}
