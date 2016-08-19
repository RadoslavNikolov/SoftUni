
// Radoslav Nikolov - rado_niko
#include "Console.hpp"
#include <iostream>
#include <iterator>
#include <functional>
#include <map>
#include "SpaceXProcessing.hpp"
#include <string>
#include <mutex>
#include "SplitString.hpp"

mutex mtx;
typedef void(SpaceXProcessing::*DoFunc)(void);
typedef pair<unsigned int, DoFunc> Pair;
typedef map<unsigned int, DoFunc> mapVotesProcessingFunCall;
mapVotesProcessingFunCall customFuncMenuMapping;

const char tokensDelimiter = ':';

vector<string> menu = {
	"1. Add new flight",
	"2. Search flight by mission name",
	"9. Clear screen",
	"0. End",
	"Enter number from menu:  "
};


Console::Console()
{
	consoleCommonFuncMenuMapping[0] = &Console::exitConsole;
	consoleCommonFuncMenuMapping[9] = &Console::clearSystem;

	customFuncMenuMapping.insert(Pair(1, &SpaceXProcessing::addNewFlight));
	customFuncMenuMapping.insert(Pair(2, &SpaceXProcessing::searchForFlightByName));

	active = true;
}

Console::~Console()
{
}

void Console::update()
{
	print("------Menu-------");

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

	SpaceXProcessing votes_processing;
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




