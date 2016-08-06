#include <iostream>
#include <string>
#include <vector>
#include <tuple>
#include <algorithm>
#include <random>
using namespace std;

struct coord {
	coord(int x, int y, int z) : x(x), y(y), z(z) {};

	int x, y, z;

	bool operator < (const coord & other) const
	{
		return tie(this->x, this->y, this->z)
			< tie(other.x, other.y, other.z);
	}
};


int main()
{
	// User tuple to sort custom objects
	vector<coord> v;

	coord c1(5, 8, 10);
	coord c2(-5, 8, 12);

	v.push_back(c1);
	v.push_back(c2);

	for (auto i : v) {
		cout << i.x << "," << i.y << "," << i.z << endl;
	}

	sort(v.begin(), v.end());


	for (auto i : v) {
		cout << i.x << "," << i.y << "," << i.z << endl;
	}
	//end



	//create and access tuples
	vector<tuple<int, string, float>> t{
		make_tuple(42, "test", 1.5),
		make_tuple(22, "test1", 2.5)
	};

	
	for (auto i : t)
	{
		cout << get<0>(i) << endl;
		cout << get<1>(i) << endl;
		cout << get<2>(i) << endl;
	}
	//end

	return 0;
}