// Radoslav Nikolov - rado_niko
#ifndef Console_hpp
#define Console_hpp

#include <map>
#include <vector>
using namespace std;

class Console {
public:
	Console();
	~Console();

	bool isActive() const;
	void update();

	map<unsigned int, void(Console::*)()> consoleCommonFuncMenuMapping;

	template<typename T>
	static void print(T value);

	static void getInputLine(vector<string>& input);

private:
	bool active;
	string command;
	vector<string> tokens;

	void getInput();
	void resetCommand();
	void parseCommand(std::string command);
	void exicuteCommand();
	string getFirstToken();
	void exitConsole();
	static void printMenu();
	void clearSystem();
};

#endif