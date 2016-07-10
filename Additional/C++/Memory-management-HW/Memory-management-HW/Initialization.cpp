#include "Initialization.h"


Initialization::Initialization(map<Vote, list<shared_ptr<Voter>>> & votersDbByVote_, map<string, map<Vote, list<shared_ptr<Voter>>>> & votersDbByName_, 
	map<unsigned short, map<Vote, list<shared_ptr<Voter>>>> & votersDbByAge_, map<City, map<Vote, list<shared_ptr<Voter>>>> & votersDbByCity_,
	map<Ethnos, map<Vote, list<shared_ptr<Voter>>>> & votersDbByEthnos_, map<Gender, map<Vote, list<shared_ptr<Voter>>>> & votersDbByGender_)
	: votersDbByVote(votersDbByVote_), votersDbByName(votersDbByName_), votersDbByAge(votersDbByAge_), votersDbByCity(votersDbByCity_), votersDbByEthnos(votersDbByEthnos_), votersDbByGender(votersDbByGender_)
{
}


Initialization::~Initialization()
{
}

void Initialization::Initialize() const
{
	shared_ptr<Voter> currentVote = make_shared<Voter>(1, "Penko", 30, Male, London, European, Yes);

	votersDbByName[currentVote->name][currentVote->vote].push_back(currentVote);
	votersDbByAge[currentVote->age][currentVote->vote].push_back(currentVote);
	votersDbByCity[currentVote->city][currentVote->vote].push_back(currentVote);
	votersDbByEthnos[currentVote->ethnos][currentVote->vote].push_back(currentVote);
	votersDbByGender[currentVote->gender][currentVote->vote].push_back(currentVote);
	votersDbByVote[currentVote->vote].push_back(currentVote);

	currentVote = make_shared<Voter>(1, "Shuramatra", 25, Female, Liverpool, Indian, Yes);

	votersDbByName[currentVote->name][currentVote->vote].push_back(currentVote);
	votersDbByAge[currentVote->age][currentVote->vote].push_back(currentVote);
	votersDbByCity[currentVote->city][currentVote->vote].push_back(currentVote);
	votersDbByEthnos[currentVote->ethnos][currentVote->vote].push_back(currentVote);
	votersDbByGender[currentVote->gender][currentVote->vote].push_back(currentVote);
	votersDbByVote[currentVote->vote].push_back(currentVote);

	currentVote = make_shared<Voter>(1, "Minka", 65, Female, Bristol, Briton, No);

	votersDbByName[currentVote->name][currentVote->vote].push_back(currentVote);
	votersDbByAge[currentVote->age][currentVote->vote].push_back(currentVote);
	votersDbByCity[currentVote->city][currentVote->vote].push_back(currentVote);
	votersDbByEthnos[currentVote->ethnos][currentVote->vote].push_back(currentVote);
	votersDbByGender[currentVote->gender][currentVote->vote].push_back(currentVote);
	votersDbByVote[currentVote->vote].push_back(currentVote);

	currentVote = make_shared<Voter>(1, "Paki", 40, Male, Manchester, Pakistani, No);

	votersDbByName[currentVote->name][currentVote->vote].push_back(currentVote);
	votersDbByAge[currentVote->age][currentVote->vote].push_back(currentVote);
	votersDbByCity[currentVote->city][currentVote->vote].push_back(currentVote);
	votersDbByEthnos[currentVote->ethnos][currentVote->vote].push_back(currentVote);
	votersDbByGender[currentVote->gender][currentVote->vote].push_back(currentVote);
	votersDbByVote[currentVote->vote].push_back(currentVote);
}
