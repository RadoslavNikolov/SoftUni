#include "stdafx.h"
#include <iostream>
#include <sstream>
#include <map>
using namespace std;


map<string, int> CountLetters(string userString, map<string, int>& counters)
{

	for (char c : userString) 
	{
		if (isupper(c))
		{
			counters["upper"]++;
		}
		else if (islower(c))
		{
			counters["lower"]++;
		}
		else
		{
			counters["other"]++;
		}
	}
		
	return counters;
}

int main()
{
	map<string, int> countersDic = {{"upper", 0}, {"lower", 0}, {"other", 0}};
	string inputString;

	cout << "Enter some text: ";
	cin >> inputString;

	CountLetters(inputString, countersDic);

	for (map<string, int>::iterator i = countersDic.begin(); i!=countersDic.end(); ++i)
	{
		string charIdentifier;
		if ((*i).first == "other")
		{
			charIdentifier = " characters: ";
		}
		else
		{
			charIdentifier = " case letters: ";
		}

		cout << "Number of " <<  i->first << charIdentifier << i->second << endl;
	}

    return 0;
}

