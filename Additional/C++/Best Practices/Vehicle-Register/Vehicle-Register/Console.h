#ifndef Console_h
#define Console_h
#endif
#include <map>
#include <vector>
using namespace std;

class Console {
public:
	Console();
	~Console();

	//if the console is running or not
	bool isActive() const;
	//this will update the console application
	void update();

	map<unsigned int, void(Console::*)()> consoleCommonFuncMenuMapping;

	template<typename T>
	static void print(T value);

	static void getInputLine(vector<string>& input);

private:
	bool active;
	string command;
	vector<string> tokens;
	
	///this will be used to take input from the screen
	void getInput();

	///clears the value of command
	void resetCommand();

	///breaks the command into its tokens
	void parseCommand(std::string command);

	///executes valid command, corresponding to menu
	void exicuteCommand();

	///this will return the first token
	string getFirstToken();

	///sets active to false
	void exitConsole();

	static void printMenu();

	///this will clear cmd screen and print the menu
	void clearSystem();
};
