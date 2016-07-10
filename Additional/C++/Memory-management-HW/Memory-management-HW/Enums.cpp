#include "Enums.h"
#include <map>
#include <algorithm>

Gender EnumsHelper::stringToGenderEnum(string str)
{
	map<string, Gender> genderMapper;
	genderMapper["male"] = Male;
	genderMapper["female"] = Female;
	genderMapper["other"] = Other;

	transform(str.begin(), str.end(), str.begin(), ::tolower);

	auto i = genderMapper.find(str);

	if (i != genderMapper.end())
	{
		return i->second;
	}
	else
	{
		throw "Inavlid gender name. Valid names ara (Male, Female, Other).";
	}
}

Vote EnumsHelper::stringToVoteEnum(string str)
{
	map<string, Vote> voteMapper;
	voteMapper["yes"] = Yes;
	voteMapper["no"] = No;

	transform(str.begin(), str.end(), str.begin(), ::tolower);

	auto i = voteMapper.find(str);

	if (i != voteMapper.end())
	{
		return i->second;
	}
	else
	{
		throw "Inavlid vote name. Valid names ara (Yes, No).";

	}
}

Ethnos EnumsHelper::stringToEthnosEnum(string str)
{
	map<string, Ethnos> ethnosMapper;
	ethnosMapper["briton"] = Briton;
	ethnosMapper["european"] = European;
	ethnosMapper["indian"] = Indian;
	ethnosMapper["pakistani"] = Pakistani;
	ethnosMapper["unwantedjunk"] = UnwantedJunk;

	transform(str.begin(), str.end(), str.begin(), ::tolower);

	auto i = ethnosMapper.find(str);

	if (i != ethnosMapper.end())
	{
		return i->second;
	}
	else
	{
		throw "Inavlid vote name. Valid names ara (Briton, European, Indian, Pakistani, UnwantedJunk).";
	}
}

City EnumsHelper::stringToCityEnum(string str)
{
	map<string, City> cityMapper;
	cityMapper["london"] = London;
	cityMapper["manchester"] = Manchester;
	cityMapper["liverpool"] = Liverpool;
	cityMapper["belfast"] = Belfast;
	cityMapper["edinburgh"] = Edinburgh;
	cityMapper["bristol"] = Bristol;

	transform(str.begin(), str.end(), str.begin(), ::tolower);

	auto i = cityMapper.find(str);

	if (i != cityMapper.end())
	{
		return i->second;
	}
	else
	{
		throw "Inavlid vote name. Valid names ara (London, Manchester, Liverpool, Belfast, Edinburgh, Bristol).";
	}
}




