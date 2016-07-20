#pragma once
#include <queue>
#include <thread>
#include <mutex>
#include <condition_variable>

using namespace std;

template <typename T>
class ConcurrentQueue
{
public:
	ConcurrentQueue();
	~ConcurrentQueue();

	T pop();
	void pop(T& item);
	void push(const T& item);
	void push(T&& item);

private:
	queue<T> queue_;
	mutex mutex_;
	condition_variable cond_;
};

