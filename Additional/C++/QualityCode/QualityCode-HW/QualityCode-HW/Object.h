#pragma once
#include "Evironment.h"

class Object
{
public:
	Object();
	Object(unsigned int id, double mass, float speed);
	Object(unsigned int id, double mass, float speed, const Evironment & environment);
	~Object();

	unsigned int id;
	double mass;
	float speed;
	Evironment environment;

	void setEnvironment(Evironment & environment);
};

