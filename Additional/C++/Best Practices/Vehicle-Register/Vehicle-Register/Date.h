#pragma once
#include <string>

using namespace std;
class Date
{
private:
	short int day;
	short int month;
	short int year;

	void setDate(string dateStr);
public:
	Date();
	Date(string dateStr);
	~Date();

	string toString();
};

