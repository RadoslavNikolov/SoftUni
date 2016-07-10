#include "VotesProcessing.h"
#include <iostream>


VotesProcessing::VotesProcessing()
{
}


VotesProcessing::~VotesProcessing()
{
}

void VotesProcessing::printResultsInPersents(map<Vote, list<shared_ptr<Voter>>>& votersDbByVote)
{
	unsigned int totalVotes = votersDbByVote[Yes].size() + votersDbByVote[No].size();

	cout << "Yes: " << (votersDbByVote[Yes].size() / (totalVotes * 1.0)) * 100 << "%" << endl;
	cout << "No: " << (votersDbByVote[No].size() / (totalVotes * 1.0)) * 100 << "%" << endl;
}

void VotesProcessing::printResultsInNumbers(map<Vote, list<shared_ptr<Voter>>>& votersDbByVote)
{
	cout << "Total votes: " << votersDbByVote[Yes].size() + votersDbByVote[No].size() << endl;
	cout << "Yes: " << votersDbByVote[Yes].size() << endl;
	cout << "No: " << votersDbByVote[No].size() << endl;
}

void VotesProcessing::printResultsBasedOnAge(map<unsigned short, map<Vote, list<shared_ptr<Voter>>>>& votersDbByAge)
{
	for (auto const& item : votersDbByAge)
	{
		auto sec = item.second;
		cout << item.first << " y - " << sec[Yes].size() << " Stay, " << sec[No].size() << " Leave" << endl;
	}
}

void VotesProcessing::printResultsBasedOnName(map<string, map<Vote, list<shared_ptr<Voter>>>>& votersDbByName)
{
	for (auto const& item : votersDbByName)
	{
		auto sec = item.second;
		cout << "Name " << item.first << " - " << sec[Yes].size() << " Stay, " << sec[No].size() << " Leave" << endl;
	}
}

void VotesProcessing::printResultsBasedOnEthnos(map<Ethnos, map<Vote, list<shared_ptr<Voter>>>>& votersDbByEthnos)
{
	for (auto const& item : votersDbByEthnos)
	{
		auto sec = item.second;
		cout << item.first << " - " << sec[Yes].size() << " Stay, " << sec[No].size() << " Leave" << endl;
	}
}

void VotesProcessing::printResultsBasedOnCity(map<City, map<Vote, list<shared_ptr<Voter>>>>& votersDbByCity)
{
	for (auto const& item : votersDbByCity)
	{
		auto sec = item.second;
		cout << item.first << " - " << sec[Yes].size() << " Stay, " << sec[No].size() << " Leave" << endl;
	}
}

void VotesProcessing::printResultsBasedOnGender(map<Gender, map<Vote, list<shared_ptr<Voter>>>>& votersDbByGender)
{
	for (auto const& item : votersDbByGender)
	{
		auto sec = item.second;
		cout << item.first << " - " << sec[Yes].size() << " Stay, " << sec[No].size() << " Leave" << endl;
	}
}
