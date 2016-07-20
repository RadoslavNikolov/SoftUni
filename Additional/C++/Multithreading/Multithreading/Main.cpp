#include <iostream>.
#include <sstream>
#include <mutex>
#include <math.h>
#include <thread>
#include <chrono>
#include <atomic>


using namespace std;

mutex mtx;
string overflowMessage = "Number overflow";
bool cancleProgram = false;


void Print(string & output)
{
	mtx.lock();
	cout << output << endl;
	mtx.unlock();
}

void CalculatePrimeNumbers(atomic<bool>& run)
{
	unsigned long long i = 1;
	bool isPrime = true;
	auto startTime = std::chrono::high_resolution_clock::now();

	while (run.load())
	{
		unsigned long  iSqred;
		ostringstream result;
		iSqred = sqrtl(i);
			
		for (unsigned long j = 2; j <= iSqred + 1; j++)
		{
			if (i > 2 && i % j != 0)
			{
				isPrime = true;
			}
			else if (i == 2)
			{
				isPrime = true;
				break;
			}
			else
			{
				isPrime = false;
				break;
			}
		}

		if (isPrime)
		{			
			auto endTime = std::chrono::high_resolution_clock::now();
			auto elapsed = endTime - startTime;
			long long miliseconds = std::chrono::duration_cast<std::chrono::milliseconds>(elapsed).count();
			startTime = endTime;

			result.str(""); //Clear stream
			result << "Prime " << i << ", " << miliseconds << " ms.";

			this_thread::sleep_for(chrono::milliseconds(200)); //Slow the proccess for user facilatation. 

			Print(result.str());
		}

		// Catch number overflow.
		if (i++ >= numeric_limits<unsigned long long>::max())
		{
			Print(overflowMessage);
			break;
		}
		//End
	}
}

void CalcilateFibonacciNumbers(atomic<bool>& run)
{
	unsigned long long temp1 = 1;
	unsigned long long temp2 = 0;
	ostringstream result;
	auto startTime = std::chrono::high_resolution_clock::now();

	while (run.load())
	{
		auto endTime = std::chrono::high_resolution_clock::now();
		auto elapsed = endTime - startTime;
		long long miliseconds = std::chrono::duration_cast<std::chrono::milliseconds>(elapsed).count();
		startTime = endTime;

		result.str("");  //Clear stream
		result << "Fibonacci " << temp2 << ", " << miliseconds << " ms.";

		this_thread::sleep_for(chrono::milliseconds(150)); //Slow the proccess for user facilatation. 
		Print(result.str());

		//// For some reason this code does not work properly only for unsigned long long. Tested for all other types.
		//// Catch number overflow.
		//if (temp2 + temp1 >= numeric_limits<unsigned long long>::max())
		//{
		//	Print(overflowMessage);
		//	break;
		//}
		////End

		temp2 = temp2 + temp1;
		temp1 = temp2 - temp1;	

		// Catch number overflow.
		if (temp2 < temp1)
		{
			Print(overflowMessage);
			break;
		}
	}

}

void ReadCin(atomic<bool>& run)
{
	string buffer;

	while (run.load())
	{
		std::cin >> buffer;
		if (buffer == "e")
		{
			run.store(false);
		}
	}
}


int main()
{
	string msg = "Insert 'e' to cancel the program: ";
	Print(msg);

	atomic<bool> run(true);
	thread cinThread(ReadCin, ref(run));
	thread primeThread(CalculatePrimeNumbers, ref(run));
	thread fibonacciThread(CalcilateFibonacciNumbers, ref(run));

	while (run.load())
	{
		//Main thread
	}

	run.store(false);

	cinThread.join();
	primeThread.join();
	fibonacciThread.join();
	
	return 0;
}




 