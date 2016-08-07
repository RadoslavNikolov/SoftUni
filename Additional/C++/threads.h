#include<vector>

void f(vector<double>&);

struct F{
	vector<double>&v;
	F(vector<double>&vv):v{vv}{}
	void operator()();
};

void code(vector<doble>& vec1, vector<double>& vec2)
{
	std::thread t1{f,vec1};
	std::thread t2{F{vec2}};
	
	t1.join();
	t2.join();
}

ORRRRRRR

double*f(const vector<double>&v);
double*g(const vector<double>&v);


void user(const vector<double> & some_vec)
{
	double res1, res2;
	thread t1{[&]{res1 = f(some_vec);}};
	thread t2{[&]{res2 = g(some_vec);}};
	
	
	t1.join():
	t2.join();

	cout << res1 << ' ' << res2 << '\n';
}



ORRRRRR


double*f(const vector<double>&v);
double*g(const vector<double>&v);

void user(const vector<double> & some_vec)
{
	auto res1 = async(f,some_vec);
	auto res2 = async(g,some_vec);
	
	cout << res1.get() << ' ' << res2.get() << '\n';
}

