#include "Date.h"
#include <sstream>

Date::Date()
{
	this->day = 1;
	this->month = 1;
	this->year = 1900;
}

Date::Date(string dateStr)
{
	setDate(dateStr);
}

Date::~Date()
{
}

void Date::setDate(string dateStr)
{
	vector<string> input;

	SplitString s(dateStr);
	input = s.split('.');

	if (input.size() != 3)
	{
		throw "Invalid date string!";
	}

	short int day = stoi(input[0]);
	if (day < 1 && day > 31)
	{
		throw "Day must be in ranage[1-31]";
	}

	short int month = stoi(input[1]);
	if (month < 0 && month > 12)
	{
		throw "Month must be in ranage[1-12]";
	}

	short int year = stoi(input[2]);
	if (year < 1900 && year > 3000)
	{
		throw "Year must be in ranage[1900-3000]";
	}

	this->day = day;
	this->month = month;
	this->year = year;
}

string Date::toString() const
{
	ostringstream result;
	result << this->day << "." << this->month << "." << this->year << endl;

	return result.str();
}
