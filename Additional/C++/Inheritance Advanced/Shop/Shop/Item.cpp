#include "Item.h"
#include <sstream>



Item::Item() :id("0000000000"), name("NoName"), price(0.0f)
{
}

Item::Item(string itemId, string itemName, float itemPrice) 
{
	setId(itemId);
	setName(itemName);
	setPrice(itemPrice);
}


Item::~Item()
{
}

string Item::getId()
{
	return id;
}

string Item::getName()
{
	return name;
}

float Item::getPrice()
{
	return price;
}

void Item::setId(string itemId)
{
	if (itemId.size() != 10)
	{
		throw "Item id must be string with length of 10";
	}

	id = itemId;
}

void Item::setName(string itemName)
{
	if (itemName.size() == 0)
	{
		throw "Item name cannot be empty.";
	}

	name = itemName;
}

void Item::setPrice(float itemPrice)
{
	if (itemPrice < 0)
	{
		throw "Item price cannot be negative";
	}

	price = itemPrice;
}

string Item::toString()
{
	ostringstream result;
	result << endl << "Item info ========================" << endl
		<< "Type: " << typeid(this).name() << endl
		<< "Item id: " << getId() << endl
		<< "Item name: " << getName() << endl
		<< "Item price: " << getPrice() << endl
		<< "====================================" << endl;

	return result.str();
}
