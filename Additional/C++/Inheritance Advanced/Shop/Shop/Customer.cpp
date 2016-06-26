#include "Customer.h"


Customer::Customer(int customerId, string customerName, string customerBicCode, string customerAddress) : id(customerId)
{
	setName(customerName);
	setBicCode(customerBicCode);
	setAddress(customerAddress);

}


Customer::~Customer()
{
}

int Customer::getId() const
{
	return id;
}

string Customer::getName() const
{
	return name;
}

string Customer::getBicCode() const
{
	return bicCode;
}

string Customer::getAddress() const
{
	return address;
}

float Customer::getTotalAmount()
{
	float totalAmount = 0.0f;

	for (auto const& item : Customer::customerCart)
	{
		totalAmount += item.second->getPrice();
	}

	return totalAmount;
}

void Customer::setName(string customerName)
{
	if (customerName.length() == 0)
	{
		throw "Customer name cannot be empty.";
	}

	name = customerName;
}

void Customer::setBicCode(string customerBicCode)
{
	if (customerBicCode.length() == 0)
	{
		throw "Customer bic code cannot be empty.";
	}

	bicCode = customerBicCode;
}

void Customer::setAddress(string customerAddress)
{
	if (customerAddress.length() == 0)
	{
		throw "Customer address cannot be empty.";
	}

	address = customerAddress;
}

string Customer::toString()
{
	ostringstream result;
	result << endl << "Customer info ========================" << endl
		<< "Type: " << typeid(this).name() << endl
		<< "Customer id: " << getId() << endl
		<< "Customer name: " << getName() << endl
		<< "Customer bic code: " << getBicCode() << endl
		<< "Customer address: " << getAddress() << endl
		<< "Purchases: " << endl << printAllItemsInCart() << endl
		<< "====================================" << endl;

	return result.str();
}

string Customer::printAllItemsInCart()
{
	ostringstream result;

	typedef map<string, shared_ptr<Item>>::iterator it_type;
	for (it_type iterator = customerCart.begin(); iterator != customerCart.end(); iterator++) {
		result << iterator->second->toString();
	}

	return result.str();
}

void Customer::addItemToCart(shared_ptr<Item> itemToAdd)
{
	customerCart[itemToAdd->getId() + '_' + to_string(itemsCounter++)] = itemToAdd;
}

void Customer::clearCart()
{
	customerCart.clear();
}


