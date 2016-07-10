#pragma once
#include "Voter.h"
#include <memory>
#include <list>
#include <map>

class Initialization
{
public:
	explicit Initialization(map<Vote, list<shared_ptr<Voter>>> & votersDbByVote_, map<string, map<Vote, list<shared_ptr<Voter>>>> & votersDbByName_,
		map<unsigned short, map<Vote, list<shared_ptr<Voter>>>> & votersDbByAge_, map<City, map<Vote, list<shared_ptr<Voter>>>> & votersDbByCity_,
		map<Ethnos, map<Vote, list<shared_ptr<Voter>>>> & votersDbByEthnos_, map<Gender, map<Vote, list<shared_ptr<Voter>>>> & votersDbByGender_);

	~Initialization();

	void Initialize() const;

private:
	map<Vote, list<shared_ptr<Voter>>> & votersDbByVote;
	map<string, map<Vote, list<shared_ptr<Voter>>>> & votersDbByName;
	map<unsigned short, map<Vote, list<shared_ptr<Voter>>>> & votersDbByAge;
	map<City, map<Vote, list<shared_ptr<Voter>>>> & votersDbByCity;
	map<Ethnos, map<Vote, list<shared_ptr<Voter>>>> & votersDbByEthnos;
	map<Gender, map<Vote, list<shared_ptr<Voter>>>> & votersDbByGender;
};

