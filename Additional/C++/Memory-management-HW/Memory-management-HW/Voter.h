#pragma once
#include "Enums.h"

class Voter
{
public:
	Voter();
	Voter(unsigned int id, string name, unsigned short age, Gender gender, City city, Ethnos ethnos, Vote vote); 
	~Voter();

	unsigned int id;
	string name;
	unsigned short age;
	Gender gender;
	City city;
	Ethnos ethnos;
	Vote vote;
};

