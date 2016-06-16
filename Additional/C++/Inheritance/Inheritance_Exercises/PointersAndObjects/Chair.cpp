#include <sstream>
using namespace std;

class Chair
{
public:
	int numberOfLegs;
	unsigned char color[3];

	string toString() const
	{

		ostringstream result;
		result << "Chair number of legs: " << numberOfLegs << endl
		 << "Color: " << int(color[0]) << "; " << int(color[1]) << "; " << int(color[2]) << endl;

		return result.str();
	}
};