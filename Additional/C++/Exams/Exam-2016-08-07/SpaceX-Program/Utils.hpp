// Radoslav Nikolov - rado_niko
#pragma once
#include <map>
#include <memory>

enum  RocketTypes { Falcon_9, Falcon_9_1, Falcon_Heavy};

enum  LocatonTypes {Terestrial, Floating};

class Utils
{
public:

	static RocketTypes stringToRocketTypesEnum(std::string str);

	static LocatonTypes stringToLocationTypesEnum(std::string str);
};

