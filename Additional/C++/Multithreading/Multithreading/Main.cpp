#include <iostream>.
#include <sstream>
#include <mutex>
#include <math.h>
#include <thread>
#include <chrono>
#include <atomic>
#include <vector>
#include <memory>
#include "Queue.cpp"


using namespace std;

mutex mtx;
string overflowMessage = "Number overflow";
bool cancleProgram = false;
Queue<string> myQueue;


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

			//this_thread::sleep_for(chrono::milliseconds(200)); //Slow the proccess for user facilatation. 

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

		//this_thread::sleep_for(chrono::milliseconds(150)); //Slow the proccess for user facilatation. 

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


void CalculatePrimeNumbersInRange(atomic<bool>& run, unsigned long long startNum, unsigned long long endNum)
{
	//unsigned long long i = 1;
	bool isPrime = false;
	bool initialCheck = false;
	auto startTime = std::chrono::high_resolution_clock::now();
	unsigned long  iSqred;
	ostringstream result;

	while (run.load() && startNum <= endNum)
	{
		initialCheck = false;

		if (startNum <= 1)
		{
			isPrime = false;
			initialCheck = true;
		}
		else if(startNum <= 3)
		{
			isPrime = true;
			initialCheck = true;
		}
		else if(startNum % 2 == 0 || startNum % 3 == 0)
		{
			isPrime = false;
			initialCheck = true;
		} 

		iSqred = sqrtl(startNum);

		if (!initialCheck)
		{
			for (unsigned long j = 3; j <= iSqred + 1; j++)
			{
				if (startNum % j != 0)
				{
					isPrime = true;
					break;
				}

				isPrime = true;			
			}
		}
		

		if (isPrime)
		{
			auto endTime = std::chrono::high_resolution_clock::now();
			auto elapsed = endTime - startTime;
			long long miliseconds = std::chrono::duration_cast<std::chrono::milliseconds>(elapsed).count();
			startTime = endTime;

			result.str(""); //Clear stream
			result << "Prime " << startNum << ", " << miliseconds << " ms.";

			//this_thread::sleep_for(chrono::milliseconds(100)); //Slow the proccess for user facilatation. 

			Print(result.str());
			//myQueue.push(result.str()); //This is not fast enough as I expected. Sad
		}

		// Catch number overflow.
		if (startNum++ >= numeric_limits<unsigned long long>::max())
		{
			Print(overflowMessage);
			break;
		}
		//End
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

void PrintFromQueue(atomic<bool>& run)
{
	while (run.load())
	{
		/*string result = myQueue.pop();
		cout << result;*/
		ostringstream  result;

		for (int i = 0; i < 10; i++)
		{
			result << myQueue.pop() << endl;
		}

		Print(result.str());

		//this_thread::sleep_for(chrono::milliseconds(200)); //Slow the proccess for user facilatation.

	}
}


int main()
{
	string msg = "Insert 'e' to cancel the program: ";
	Print(msg);

	atomic<bool> run(true);
	thread cinThread(ReadCin, ref(run));
	
	while (run.load())
	{
		//thread fibonacciThread(CalcilateFibonacciNumbers, ref(run));
		vector<shared_ptr<thread>> threadVector;
		threadVector.push_back(make_shared<thread>(thread(CalcilateFibonacciNumbers, ref(run))));

		// Лично при мен 8 е оптималната бройка на тредовете, които да поусна за изчислението на простите числа.
		// До колкото забелязах колкото ядра, толкова тредове. Ако са повече мютекса при принтирането на конзолата забавя много нещата.
		// При терминиране на програмата се чака малко докато се извърти while цикъла на всеки тред
		short numOfThreadsToInvoke = 8;
		unsigned long long range = numeric_limits<unsigned long long>::max() / numOfThreadsToInvoke;
		for (unsigned long long i = 0; i < numOfThreadsToInvoke; i++)
		{
			threadVector.push_back(make_shared<thread>(thread(CalculatePrimeNumbersInRange, ref(run), range * i, range * (i + 1))));
		}

		//fibonacciThread.join();
		for (int i = 0; i < threadVector.size(); i++)
		{
			threadVector[i]->join();
		}
	}


	run.store(false);
	cinThread.join();

	return 0;
}




 