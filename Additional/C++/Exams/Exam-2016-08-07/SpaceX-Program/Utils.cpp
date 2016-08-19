
// Radoslav Nikolov - rado_niko
#include "Utils.hpp"

RocketTypes Utils::stringToRocketTypesEnum(std::string str)
{
	std::map<std::string, RocketTypes> rocketTypesEnumMapper;
	rocketTypesEnumMapper["Falcon 9"] = RocketTypes::Falcon_9;
	rocketTypesEnumMapper["Falcon 9.1"] = RocketTypes::Falcon_9_1;
	rocketTypesEnumMapper["Falcon Heavy"] = RocketTypes::Falcon_Heavy;


		std::map<std::string, RocketTypes>::iterator i = rocketTypesEnumMapper.find(str);
		if (i != rocketTypesEnumMapper.end())
		{
			return i->second;
		}
		else
		{
			throw "Inavlid rocket type name. Valid names ara (Falcon 9, Falcon 9.1, Falcon Heavy). Names are case sensitive.";
		}
}

LocatonTypes Utils::stringToLocationTypesEnum(std::string str)
{
	std::map<std::string, LocatonTypes> locationTypesEnumMapper;
	locationTypesEnumMapper["Terestrial"] = LocatonTypes::Terestrial;
	locationTypesEnumMapper["Floating"] = LocatonTypes::Floating;


	std::map<std::string, LocatonTypes>::iterator i = locationTypesEnumMapper.find(str);
	if (i != locationTypesEnumMapper.end())
	{
		return i->second;
	}
	else
	{
		throw "Inavlid location type name. Valid names ara (Terestrial, Floating). Names are case sensitive.";
	}

}