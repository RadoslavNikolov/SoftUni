#pragma once
#include <string>

using namespace std;
class Evironment
{
public:
	Evironment();
	Evironment(unsigned int id, string name, float gravity);
	~Evironment();

	unsigned int id;
	string name;
	float gravity;
};

