#include <algorithm>
#include <vector>
#include <string>
#include <iostream>
#include <cmath>

using namespace std;

# define M_PI  3.14159265358979323846  /* pi */


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
		tokens.clear();  // empty vector if necessary
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


class Point {
	
public:	
	Point(double x, double y, double z): x(x), y(y), z(z) {}

	double x;
	double y;
	double z;
};

int main() 
{
	4, 1, 0; 9, 8, 6; 0, 7, 5; 	string inputStr;
	cin >> inputStr;

	vector<string> pointsStrTokens;

	SplitString s(inputStr);
	pointsStrTokens = s.split(';');

	vector<string> pointCoordTokens();
	vector<Point> pointsVec;

	for (auto pointCoords : pointsStrTokens)
	{
		vector<string> coordsTokens;
		SplitString c(pointCoords);
		coordsTokens = c.split(',');

		double x = stod(coordsTokens[0]);
		double y = stod(coordsTokens[1]);
		double z = stod(coordsTokens[2]);

		if (x < -120 || x > 120 || y < -120 || y > 120 || z < -120 || z > 120)
		{
			continue;
		}

		Point p(x,y,z);
		pointsVec.push_back(p);
	}

	double aSide = sqrt((pointsVec[0].x - pointsVec[1].x) * (pointsVec[0].x - pointsVec[1].x) +
		(pointsVec[0].y - pointsVec[1].y) * (pointsVec[0].y - pointsVec[1].y) +
		(pointsVec[0].z - pointsVec[1].z) * (pointsVec[0].z - pointsVec[1].z));

	double bSide = sqrt((pointsVec[0].x - pointsVec[2].x) * (pointsVec[0].x - pointsVec[2].x) +
		(pointsVec[0].y - pointsVec[2].y) * (pointsVec[0].y - pointsVec[2].y) +
		(pointsVec[0].z - pointsVec[2].z) * (pointsVec[0].z - pointsVec[2].z));

	double cSide = sqrt((pointsVec[1].x - pointsVec[2].x) * (pointsVec[1].x - pointsVec[2].x) +
		(pointsVec[1].y - pointsVec[2].y) * (pointsVec[1].y - pointsVec[2].y) +
		(pointsVec[1].z - pointsVec[2].z) * (pointsVec[1].z - pointsVec[2].z));


	double cgamma = ((bSide * bSide) + (cSide * cSide) - (aSide * aSide)) / (2.00f * bSide * cSide);
	double cbeta = ((aSide * aSide) + (cSide * cSide) - (bSide * bSide)) / (2.00f * aSide * cSide);
	double calpha = ((aSide * aSide) + (bSide * bSide) - (cSide * cSide)) / (2.00f * aSide * bSide);


	double alpha = acos(calpha) * 180.00f / 3.14;
	double beta = acos(cbeta) * 180.00f / M_PI;
	double gamma = acos(cgamma) * 180.00f / M_PI;

	
	cout << (int)alpha << ',' << (int)beta << ',' << (int)gamma << endl;
	return 0;
}
