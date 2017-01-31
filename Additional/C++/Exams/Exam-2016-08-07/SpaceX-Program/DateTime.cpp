#include "DateTime.hpp"
#include <sstream>

// Radoslav Nikolov - rado_niko

DateTime::DateTime()
{
	this->day = 1;
	this->month = 1;
	this->year = 1900;
}

DateTime::DateTime(string dateStr)
{
	setDate(dateStr);
}

DateTime::~DateTime()
{
}

void DateTime::setDate(string dateStr)
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

	short int hour = stoi(input[3]);
	if (hour < 0 && hour > 24)
	{
		throw "Hour must be in ranage[0-24]";
	}

	short int minutes = stoi(input[4]);
	if (minutes < 0 && minutes > 60)
	{
		throw "Minutes must be in ranage[0-60]";
	}

	short int seconds = stoi(input[5]);
	if (seconds < 0 && seconds > 60)
	{
		throw "Seconds must be in ranage[0-60]";
	}

	this->day = day;
	this->month = month;
	this->year = year;
	this->hour = hour;
	this->minutes = minutes;
	this->seconds = seconds;
}

string DateTime::toString()
{
	ostringstream result;
	result << this->day << "." << this->month << "." << this->year << endl;

	return result.str();
}