
#include <map>
#include "Voter.h"
#include <memory>
#include <iostream>
#include <vector>
#include <list>
#include "SplitString.h"
#include "VotesProcessing.h"
#include "Initialization.h"

// Целта на толкова много на пръв поглед речници е бързото търсене по ключ. Предполагам, че в курсовете по структури от данни ще се прави.
// Търсенето в речник(независимо колко голям е) по ключ е 1 т.е. става с една операция.
// Именно поради това в подобни ситуации се използва подобна имплементация с много речници, според primary key-a, по който ще търсим.
// Добавянето, промяната и триенето е по сложно, но търсенето е светкавично.

typedef map<Vote, list<shared_ptr<Voter>>> DatabaseByVote;
DatabaseByVote votersDbByVote;

typedef map<unsigned short, map<Vote,list<shared_ptr<Voter>>>> DatabaseByAge;
DatabaseByAge votersDbByAge;

typedef map<City, map<Vote,list<shared_ptr<Voter>>>> DatabaseByCity;
DatabaseByCity votersDbByCity;

typedef map<Ethnos, map<Vote,list<shared_ptr<Voter>>>> DatabaseByEthnos;
DatabaseByEthnos votersDbByEthnos;

typedef map<string, map<Vote,list<shared_ptr<Voter>>>> DatabaseByName;
DatabaseByName votersDbByName;

typedef map<Gender, map<Vote,list<shared_ptr<Voter>>>> DatabaseByGender;
DatabaseByGender votersDbByGender;


extern unsigned int voteId = 1;
const string collectorPasword = "123";

void printMainMenu()
{
	cout << endl << "1. Enter password for collectors menu" << endl;
	cout << "2. Vote" << endl;
	cout << "0. End" << endl;
	cout << "Enter number from menu:  ";
}


void printCollectorsMenu()
{
	cout << endl << "1. Get results in percents" << endl;
	cout << "2. Get results in numbers" << endl;
	cout << "3. Get results based on Age" << endl;
	cout << "4. Get results based on Name" << endl;
	cout << "5. Get results based on Ethnos" << endl;
	cout << "6. Get results based on City" << endl;
	cout << "7. Get results based on Gender" << endl;
	cout << "0. Return to main menu" << endl;
	cout << "Enter number from menu:  ";
}

void getInputLine(vector<string> &input)
{
	string segment;
	cin >> segment;

	SplitString s(segment);
	input = s.split(':');
}


void collectorsCommandManager(unsigned short choice)
{
	switch (choice)
	{
	case 1:
		VotesProcessing::printResultsInPersents(votersDbByVote);
		break;
	case 2:
		VotesProcessing::printResultsInNumbers(votersDbByVote);
		break;
	case 3:
		VotesProcessing::printResultsBasedOnAge(votersDbByAge);
		break;
	case 4:
		VotesProcessing::printResultsBasedOnName(votersDbByName);
		break;
	case 5:
		VotesProcessing::printResultsBasedOnEthnos(votersDbByEthnos);
		break;
	case 6:
		VotesProcessing::printResultsBasedOnCity(votersDbByCity);
		break;
	case 7:
		VotesProcessing::printResultsBasedOnGender(votersDbByGender);
		break;
	default:
		cout << endl << " >>>>>> Invalid command!" << endl;
		break;
	}
}


void startCollectorsArea()
{
	bool isRunning = true;
	unsigned short choice;

	while (isRunning)
	{
		choice = 999;
		printCollectorsMenu();

		cin.sync();
		cin >> choice;

		if (!cin)
		{
			cin.clear(); // reset failbit
			cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n'); //skip bad input
		}

		isRunning = choice != 0;

		if (isRunning)
		{
			collectorsCommandManager(choice);
		}
	}
}

void vote()
{
	vector<string> input;

	cout << "Enter new vote in format with delimiter ':' [Name:Age:Gender(Male/Female/Other):City(London/Manchester/Liverpool/Belfast/Edinburgh/Bristol):\n:Ethnos(Briton/European/Indian/Pakistani/UnwantedJunk):Vote(Yes/No)]" << endl;
	getInputLine(input);

	//Add data to 'database'
	try
	{
		string name = input[0];
		unsigned short age = stoi(input[1]);
		Gender gender = EnumsHelper::stringToGenderEnum(input[2]);
		City city = EnumsHelper::stringToCityEnum(input[3]);
		Ethnos ethnos = EnumsHelper::stringToEthnosEnum(input[4]);
		Vote vote = EnumsHelper::stringToVoteEnum(input[5]);

		shared_ptr<Voter> currentVote = make_shared<Voter>(voteId, name, age, gender, city, ethnos, vote);
		votersDbByVote[vote].push_back(currentVote);
		votersDbByName[name][vote].push_back(currentVote);
		votersDbByAge[age][vote].push_back(currentVote);
		votersDbByCity[city][vote].push_back(currentVote);
		votersDbByEthnos[ethnos][vote].push_back(currentVote);
		votersDbByGender[gender][vote].push_back(currentVote);
		
		cout << " >>>>>> Added voter with id: " << voteId << endl;;
		voteId++;
	}
	catch (const char* msg)
	{
		cout << " >>>>>> " << msg << endl;
	}
	
}

bool checkForValidPassword(string & enteredPassword)
{
	return enteredPassword == collectorPasword;
}


void mainCommandManager(unsigned short choice)
{
	string enteredPassword;

	switch (choice)
	{
	case 1:
		cout << "Enter password:  ";
		cin >> enteredPassword;

		if (checkForValidPassword(enteredPassword))
		{
			startCollectorsArea();
		}
		else
		{
			cout << "Invalid password!";
		}

		break;
	case 2:
		vote();
		break;
	default:
		cout << endl << " >>>>>> Invalid command!" << endl;
		break;
	}
}

void start()
{
	bool isRunning = true;
	unsigned short choice;

	while (isRunning)
	{
		choice = 999;
		printMainMenu();

		cin.sync();
		cin >> choice;

		if (!cin)
		{
			cin.clear(); // reset failbit
			cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n'); //skip bad input
		}

		isRunning = choice != 0;

		if (isRunning)
		{
			mainCommandManager(choice);
		}
	}
}

int main()
{
	//Seed database
	Initialization init(votersDbByVote, votersDbByName, votersDbByAge, votersDbByCity, votersDbByEthnos, votersDbByGender);
	init.Initialize();
	//End

	start();

	return 0;
}