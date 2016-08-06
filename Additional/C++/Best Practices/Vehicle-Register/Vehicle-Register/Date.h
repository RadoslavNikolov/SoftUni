#ifndef Date_h
#define Date_h
#endif

#include "SplitString.h"

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

	string toString() const;
};

