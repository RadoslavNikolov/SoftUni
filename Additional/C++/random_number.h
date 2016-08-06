#include <random>
#include <iostream>

using namespace std;

int main()
{
	random_device rd;
	
	//get random number
	cout << rd() << endl;
	
	
	// get a pseudo-random number
	mt19937_64 rng(rd());

	for (int i = 0; i < 50; i++)
	{
		cout << rng() << endl;

	}
	
	return 0;
}