#pragma once
#include <string>
#include <vector>
#include <map>
using namespace std;

class Console {
public:
	Console();
	~Console();
	//if the console is running or not
	bool isActive() const;
	//this will update the console application
	void update();

	map<string, void(Console::*)()> mapping;

private:
	bool active;
	string command;
	vector<string> tokens;

	template<typename T>
	static void print(T const& value);

	//this will be used to take input from the screen
	void getInput();

	//clears the value of command
	void resetCommand();

	//breaks the command into its tokens
	void parseCommand(std::string command);

	//evaluates what it will do based on the command
	int evaluate();

	void exicuteCommand(int commandNum);

	//this will return the first token
	std::string getFirstToken();

	//sets active to false
	void exitConsole();

	void clearSystem();

	static void printMenu();
};
