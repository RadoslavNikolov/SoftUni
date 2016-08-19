#include <iostream>
#include <algorithm>
#include <string>
#include <vector>

using namespace std;

int main()
{
	string input;
	cin >> input;

	string delimiter = ".";
	string token = input.substr(0, input.find(delimiter)); 
	vector<char> processedStr;



	int index = 0;
	for_each(token.begin(), token.end(), [&](char ch) {
		if (index % 2 == 0)
		{
			processedStr.push_back((char)((int)ch + 3));
		}
		else
		{
			processedStr.push_back((char)((int)ch - 3));
		}
		index += 1;
	});

	reverse(processedStr.begin(), processedStr.end());

	for (auto ch : processedStr)
	{
		cout << ch;
	}


	return 0;
}
