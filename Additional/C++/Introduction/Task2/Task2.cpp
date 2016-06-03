#include "stdafx.h"
#include <iostream>
#include <vector>
#include <sstream>
#include <algorithm>
using namespace std;


#pragma region Custom defined predicates

auto cmpAscending = [](pair<string, unsigned short> const & a, pair<string, unsigned short> const & b)
{
	return a.second != b.second ? a.second < b.second : a.first < b.first;
};

auto cmpDescending = [](pair<string, unsigned short> const & a, pair<string, unsigned short> const & b)
{
	return a.second != b.second ? a.second > b.second : a.first > b.first;
};


#pragma endregion

#pragma region Helper functions

void PrintInfo(vector<pair<string, unsigned short>>& pancakesVector)
{
	for (vector<pair<string,unsigned short>>::iterator i = pancakesVector.begin(); i != pancakesVector.end(); ++i)
	{
		cout << i->first << " : " << i->second << endl;
	}
}

void SortPairsByValueAsc(vector<pair<string, unsigned short>>& sourceVector)
{
	sort(sourceVector.begin(), sourceVector.end(), cmpAscending);
}

void SortPairsByValueDesc(vector<pair<string, unsigned short>>& sourceVector)
{
	sort(sourceVector.begin(), sourceVector.end(), cmpDescending);
}

vector<pair<string, unsigned short>>  GetPersonWithLeastEatenPancake(vector<pair<string, unsigned short>> pancakeVector) 
{
	vector<pair<string, unsigned short>> leastEatenPancakes;
	SortPairsByValueAsc(pancakeVector);
	unsigned short referntValue = pancakeVector[0].second;

	for (vector<pair<string, unsigned short>>::iterator i = pancakeVector.begin(); i != pancakeVector.end(); ++i)
	{
		if (i->second == referntValue)
		{
			leastEatenPancakes.push_back(*i);
		}
		else
		{
			break;
		}
	}

	return leastEatenPancakes;
}

#pragma endregion

int main()
{
	vector<pair<string, unsigned short>> eatenPancakes;
	
	unsigned short i = 1;
	while (i <= 5)
	{
		string identifier = "Person" + to_string(i);
		cout << "Enter number of pancakes eaten for breakfast by " << identifier << "(0-65535): ";

		unsigned short cakes;
		cin >> cakes;

		pair<string, unsigned short> p = { identifier, cakes };

		eatenPancakes.push_back(p);
		i++;
	}

	vector<pair<string, unsigned short>> leastEatenPancakes = GetPersonWithLeastEatenPancake(eatenPancakes);
	cout << "List of persons with least eaten pancakes: " << endl;
	PrintInfo(leastEatenPancakes);

	vector<pair<string, unsigned short>> sortedEatenPancakesDesc = eatenPancakes;
	SortPairsByValueDesc(sortedEatenPancakesDesc);
	cout << "List of all person ordered by eaten pancakes in descending ordel: " << endl;
	PrintInfo(sortedEatenPancakesDesc);

    return 0;
}


