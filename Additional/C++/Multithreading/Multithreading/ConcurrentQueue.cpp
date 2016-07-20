#include "ConcurrentQueue.h"





template<typename T>
ConcurrentQueue<T>::ConcurrentQueue()
{
}

template<typename T>
ConcurrentQueue<T>::~ConcurrentQueue()
{
}

template<typename T>
T ConcurrentQueue<T>::pop()
{
	unique_lock<mutex> mlock(mutex_);
	while (queue_.empty())
	{
		cond_.wait(mlock);
	}
	auto item = queue_.front();
	queue_.pop();
	return item;
}

template<typename T>
void ConcurrentQueue<T>::pop(T & item)
{
	unique_lock<mutex> mlock(mutex_);
	while (queue_.empty())
	{
		cond_.wait(mlock);
	}
	item = queue_.front();
	queue_.pop();
}

template<typename T>
void ConcurrentQueue<T>::push(const T & item)
{
	unique_lock<mutex> mlock(mutex_);
	queue_.push(item);
	mlock.unlock();
	cond_.notify_one();
}

template<typename T>
void ConcurrentQueue<T>::push(T && item)
{
	unique_lock<mutex> mlock(mutex_);
	queue_.push(std::move(item));
	mlock.unlock();
	cond_.notify_one();
}
