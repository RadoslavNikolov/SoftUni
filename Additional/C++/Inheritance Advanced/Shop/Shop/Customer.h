#pragma once
#include<sstream>
#include <map>
#include <memory>
#include "Item.h"


using namespace std;

class Customer
{
public:
	Customer(int customerId, string customerName, string customerBicCode, string customerAddress);
	~Customer();

	int getId() const;
	string getName() const;
	string getBicCode() const;
	string getAddress() const;
	float getTotalAmount();

	void setName(string customerName);
	void setBicCode(string customerBicCode);
	void setAddress(string customerAddress);

	string toString();
	string printAllItemsInCart();
	void addItemToCart(shared_ptr<Item> itemToAdd);
	void clearCart();

private:
	int id;
	string name;
	string bicCode;
	string address;
	map<string, shared_ptr<Item>> customerCart;
	int itemsCounter = 1;
};

