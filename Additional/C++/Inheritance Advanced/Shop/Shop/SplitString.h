#pragma once
#include <string>
#include <vector>

using namespace std;

class SplitString : public string {
	vector<string> tokens;
public:
	SplitString(string s) : string(s) { };
	vector<string>& split(char delim, int rep = 0);
};

vector<string>& SplitString::split(char delim, int rep) {
	if (!tokens.empty()) tokens.clear();  // empty vector if necessary
	string work = data();
	string buf = "";
	int i = 0;
	while (i < work.length()) {
		if (work[i] != delim)
			buf += work[i];
		else if (rep == 1) {
			tokens.push_back(buf);
			buf = "";
		}
		else if (buf.length() > 0) {
			tokens.push_back(buf);
			buf = "";
		}
		i++;
	}
	if (!buf.empty())
		tokens.push_back(buf);
	return tokens;
}
