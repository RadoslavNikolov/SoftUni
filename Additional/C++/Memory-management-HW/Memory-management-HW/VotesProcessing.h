#pragma once
#include "Voter.h"
#include <memory>
#include <list>
#include <map>

class VotesProcessing
{
public:
	VotesProcessing();
	~VotesProcessing();

	static void printResultsInPersents(map<Vote, list<shared_ptr<Voter>>> & votersDbByVote);
	static void printResultsInNumbers(map<Vote, list<shared_ptr<Voter>>> & votersDbByVote);
	static void printResultsBasedOnAge(map<unsigned short, map<Vote, list<shared_ptr<Voter>>>> & votersDbByAge);
	static void printResultsBasedOnName(map<string, map<Vote, list<shared_ptr<Voter>>>> & votersDbByName);
	static void printResultsBasedOnEthnos(map<Ethnos, map<Vote, list<shared_ptr<Voter>>>> & votersDbByEthnos);
	static void printResultsBasedOnCity(map<City, map<Vote, list<shared_ptr<Voter>>>> & votersDbByCity);
	static void printResultsBasedOnGender(map<Gender, map<Vote, list<shared_ptr<Voter>>>> & votersDbByGender);
};

