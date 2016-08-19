// Radoslav Nikolov - rado_niko
#ifndef DateTime_hpp
#define DateTime_hpp

#include "SplitString.hpp"

class DateTime
{
private:
	short day;
	short month;
	short year;
	short hour;
	short minutes;
	short seconds;

	void setDate(string dateStr);
public:
	DateTime();
	DateTime(string dateStr);

	~DateTime();

	string toString();
};

#endif
