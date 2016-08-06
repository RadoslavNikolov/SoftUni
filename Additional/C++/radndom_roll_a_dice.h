#include <random>
#include <iostream>

using namespace std;

int main()
{
	random_device rd;
	// get a pseudo-random number
	mt19937_64 rng(rd());

	uniform_int_distribution<int> dice(1,6);
	cout << dice(rng) << endl;
	
	//double random number
	uniform_real_distribution<double> dice(-6,6);
	cout << dice(rng) << endl;
	
	return 0;
}