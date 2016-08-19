// Radoslav Nikolov - rado_niko
#ifndef SplitString_hpp
#define SplitString_hpp
#include <vector>

using namespace std;

class SplitString : public string
{
	vector<string> tokens;
public:
	explicit SplitString(string s) : string(s) {};

	vector<string>& split(char delim, int rep = 0);
};

inline vector<string>& SplitString::split(char delim, int rep) {
	if (!tokens.empty())
	{
		tokens.clear();  
	}

	string work = data();
	string buf = "";
	unsigned int i = 0;

	while (i < work.length())
	{
		if (work[i] != delim)
		{
			buf += work[i];
		}
		else if (rep == 1)
		{
			tokens.push_back(buf);
			buf = "";
		}
		else if (buf.length() > 0)
		{
			tokens.push_back(buf);
			buf = "";
		}

		i++;
	}

	if (!buf.empty())
	{
		tokens.push_back(buf);
	}

	return tokens;
};

#endif