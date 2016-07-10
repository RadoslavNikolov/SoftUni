#include "Voter.h"



Voter::Voter()
{
}

Voter::Voter(unsigned int id, string name, unsigned short age, Gender gender, City city, Ethnos ethnos, Vote vote) : id(id), name(name), age(age), gender(gender), city(city), ethnos(ethnos), vote(vote)
{
}


Voter::~Voter()
{
}
