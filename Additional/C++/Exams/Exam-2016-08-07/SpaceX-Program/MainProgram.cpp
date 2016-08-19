#include "Console.hpp"

// Radoslav Nikolov - rado_niko

//Input string:
//MyPlace:Terestrial:MyMission:Falcon 9 : 01.01.2016.12.20.20 : 05.01.2016.15.30.00 : 15555.5 : Yes : 45.5 : 53.5


// По някаква причина във файл SpaceXProcessing  това хвърля странни грешки. Ако се дебъгва се игнорира грешаката е всичко е ОК.
//RocketTypes rocketType = Utils::stringToRocketTypesEnum(input[3]);
//DateTime ignitionDate = DateTime(input[4]);
//DateTime landingDate = DateTime(input[5]);

int main()
{
	Console console;

	while (console.isActive()) {
		console.update();
	}

	return 0;
}