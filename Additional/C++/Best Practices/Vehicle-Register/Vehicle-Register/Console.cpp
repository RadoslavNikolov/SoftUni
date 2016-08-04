#include "Console.h"
#include <iostream>
#include <sstream>
#include <iterator>
#include <vector>
#include <functional>
#include <map>
#include "VehicleRegisterProcessing.h"
#include "SplitString.h"

typedef void(VehicleRegisterProcessing::*DoFunc)(void);
typedef pair<string, DoFunc> Pair;
typedef map<string, DoFunc> mapVotesProcessingFunCall;
mapVotesProcessingFunCall menuFuncMap;

const char tokensDelimiter = ':';

vector<string> menu = {
	"1. Add new vehicle",     //0 exit console
	"2. Search vehicle by registration number",
	"9. Clear screen",
	"0. End",
	"Enter number from menu:  "
};

map<unsigned int, string> menuNumberToFuncNameMap;

Console::Console()
{
	menuNumberToFuncNameMap[0] = "exitConsole()";
	menuNumberToFuncNameMap[1] = "addNewVehicle()";
	menuNumberToFuncNameMap[2] = "searchVehicleByRegNum()";

	menuNumberToFuncNameMap[9] = "clearSystem()";

	mapping["exitConsole()"] = &Console::exitConsole;
	mapping["clearSystem()"] = &Console::clearSystem;

	menuFuncMap.insert(Pair("addNewVehicle()", &VehicleRegisterProcessing::addNewVehicle));
	menuFuncMap.insert(Pair("searchVehicleByRegNum()", &VehicleRegisterProcessing::searchVehicleByRegNum));

	active = true;
}

Console::~Console()
{
}

//------------------------------------------------------
//This will be a loop that out and in puts to the screen
//------------------------------------------------------
void Console::update() {
	print("Solution [Command Line]");
	print("------Version 0.1-------");

	while (command == "") {
		printMenu();
		getInput();
	}

	parseCommand(command);
	exicuteCommand(evaluate());
	resetCommand();
}


void Console::getInput() {
	getline(cin, command);
}

void Console::parseCommand(string command) {
	SplitString s(command);
	tokens = s.split(tokensDelimiter);
}

std::string Console::getFirstToken() {
	return tokens[0];
}

//------------------------------------------------------
//evaluates what to do based on the tokes passed
//------------------------------------------------------
int Console::evaluate()
{
	unsigned short choice = stoi(getFirstToken());

	return  choice;
}

void Console::exicuteCommand(int commandNum)
{
	VehicleRegisterProcessing votes_processing;
	Console console;

	auto const find = menuFuncMap.find(menuNumberToFuncNameMap[commandNum]);
	if (find != menuFuncMap.end())
	{
		(votes_processing.*(find->second))();
	}
	else
	{
		auto const x = mapping.find(menuNumberToFuncNameMap[commandNum]);
		if (x != mapping.end())
		{
			(this->*mapping[menuNumberToFuncNameMap[commandNum]])();
		}
		else
		{
			print(" >>>>>> Invalid command!");
		}
	}

}


void Console::resetCommand() {
	command = "";
}

void Console::exitConsole() {
	this->active = false;
}

void Console::clearSystem()
{
	system("cls");
}

void Console::printMenu()
{
	for (auto const & item : menu)
	{
		print(item);
	}
}

bool Console::isActive() const {
	return this->active;
}

template<typename T>
void Console::print(T const& value) {
	std::cout << value << endl;;
}

