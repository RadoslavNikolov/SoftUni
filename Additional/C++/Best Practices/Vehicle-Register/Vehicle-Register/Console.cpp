#include "Console.h"
#include <iostream>
#include <iterator>
#include <functional>
#include <map>
#include "VehicleRegisterProcessing.h"
#include <string>
#include <mutex>
#include "SplitString.h"

mutex mtx;
typedef void(VehicleRegisterProcessing::*DoFunc)(void);
typedef pair<unsigned int, DoFunc> Pair;
typedef map<unsigned int, DoFunc> mapVotesProcessingFunCall;
mapVotesProcessingFunCall customFuncMenuMapping;

const char tokensDelimiter = ':';

vector<string> menu = {
	"1. Add new vehicle",
	"2. Search vehicle by registration number",
	"9. Clear screen",
	"0. End",
	"Enter number from menu:  "
};


Console::Console()
{
	consoleCommonFuncMenuMapping[0] = &Console::exitConsole;
	consoleCommonFuncMenuMapping[9] = &Console::clearSystem;

	customFuncMenuMapping.insert(Pair(1, &VehicleRegisterProcessing::addNewVehicle));
	customFuncMenuMapping.insert(Pair(2, &VehicleRegisterProcessing::searchVehicleByRegNum));

	active = true;
}

Console::~Console()
{
}

//This will be a loop that out and in puts to the screen
void Console::update() 
{
	print("Solution [Command Line]");
	print("------Version 0.1-------");

	while (command == "") {
		printMenu();
		getInput();
	}

	parseCommand(command);
	exicuteCommand();
	resetCommand();
}

void Console::getInput() 
{
	getline(cin, command);
}

void Console::parseCommand(string command) 
{
	SplitString s(command);
	tokens = s.split(tokensDelimiter);
}

string Console::getFirstToken() 
{
	if (this->tokens.size() == 0)
	{
		return "";
	}

	return tokens[0];
}

void Console::exicuteCommand()
{
	unsigned short commandNum = 9999;
	commandNum = stoi(getFirstToken());

	VehicleRegisterProcessing votes_processing;
	Console console;

	auto const find = customFuncMenuMapping.find(commandNum);
	if (find != customFuncMenuMapping.end())
	{
		(votes_processing.*(find->second))();
	}
	else
	{
		auto const x = consoleCommonFuncMenuMapping.find(commandNum);
		if (x != consoleCommonFuncMenuMapping.end())
		{
			(this->*(x->second))();
		}
		else
		{
			print(" >>>>>> Invalid command!");
		}
	}
}


void Console::resetCommand() 
{
	command = "";
}

void Console::exitConsole() 
{
	this->active = false;
}

void Console::clearSystem()
{
	system("cls");
}

void Console::printMenu()
{
	print("");

	for (auto const & item : menu)
	{
		print(item);
	}
}

bool Console::isActive() const 
{
	return this->active;
}

template<typename T>
void Console::print(T value) 
{
	mtx.lock();
	cout << value << endl;
	mtx.unlock();
}

void Console::getInputLine(vector<string> &input)
{
	string segment;
	getline(cin, segment);

	SplitString s(segment);
	input = s.split(':');
}




