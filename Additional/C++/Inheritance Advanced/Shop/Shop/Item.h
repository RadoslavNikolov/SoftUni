#pragma once
#include <string>
using namespace std;
class Item
{
public:
	Item();
	Item(string itemId, string itemName, float itemPrice);
	~Item();

	string getId();
	string getName();
	float getPrice();

	void setId(string itemId);
	void setName(string itemName);
	void setPrice(float itemPrice);

	string toString();

private:
	string id;
	string name;
	float price;
};

