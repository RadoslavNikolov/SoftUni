#pragma once
#include <string>
using namespace std;

enum Gender
{
	Male,
	Female,
	Other
};

enum Vote
{
	Yes,
	No
};

enum Ethnos
{
	Briton,
	European,
	Indian,
	Pakistani,
	UnwantedJunk
};

enum City
{
	London,
	Manchester,
	Liverpool,
	Belfast,
	Edinburgh,
	Bristol

};


class EnumsHelper
{
public:
	static Gender stringToGenderEnum(string str);
	static Vote stringToVoteEnum(string str);
	static Ethnos stringToEthnosEnum(string str);
	static City stringToCityEnum(string str);
};

