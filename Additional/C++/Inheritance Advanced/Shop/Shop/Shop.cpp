// Shop.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "Customer.h"
#include "SplitString.h"
#include <iostream>
#include <vector>

using namespace std;

typedef map<string, shared_ptr<Item>> ItemsDatabase;
ItemsDatabase itemsDB;

shared_ptr<Customer> currentCustomer;
int customerIdCounter = 1;

//Не съм използвам copy constructor поради факта,че всеки потребител пази колекция от пойнтери към желаните артикули.
//Реших да го направя по този начин за да може когато променя нещо в даден артикул това да се отрази веднага на всички артикули, добавени в количките на всеки един потребител
//Представете си ако сум добавил даден артикул в количките на n на брой потребители. Ако изполвам copy constructor това значи да итерирам през количките на всички потребители и ако намеря 
// артикул с такова id да направя промяната. Гарантирам, че знаме какво е и как се ползва copy constructor :))

void printMenu()
{
	cout << endl << "1. Add customer" << endl;
	cout << "2. Add item" << endl;
	cout << "3. Print item by id" << endl;
	cout << "4. Add item to customer cart" << endl;
	cout << "5. Print customer information" << endl;
	cout << "6. Change price of item by id" << endl;
	cout << "0 End" << endl;
	cout << "Enter number from menu:  ";
}

void getInputLine(vector<string> &input)
{
	string segment;
	cin >> segment;

	SplitString s(segment);
	input = s.split(':');
}

shared_ptr<Item> getItemById(string & id)
{
	ItemsDatabase::iterator it = itemsDB.find(id);
	if (it != itemsDB.end())
	{
		return it->second;
	}

	return nullptr;
}

void addCustomer()
{
	bool enterNewCustomer = false;

	if (currentCustomer != nullptr)
	{
		while (true)
		{
			cout << "There is already entered customerwith info: " << endl;
			cout << currentCustomer->toString();
			cout << " Would you like to enter new one? Y/N" << endl;

			string answer;
			cin >> answer;

			if (answer.size() == 1  && isalpha(answer.at(0)) && answer.at(0) == 'Y' || answer.at(0) == 'y' || answer.at(0) == 'N' || answer.at(0) == 'n')
			{
				if (answer.at(0) == 'Y' || answer.at(0) == 'y')
				{
					enterNewCustomer = true;
				}

				break;
			}
			else
			{
				cout << " >>>>>> Invalid Answer: " << endl;
				cout << " Would you like to enter new one? Y/N" << endl;
			}
		}
		
	}

	if (currentCustomer != nullptr && !enterNewCustomer)
	{
		return;
	}

	vector<string> input;
	cout << "Enter new customer in format with delimiter ':' [Name:Bic Code(8):Address]" << endl;
	getInputLine(input);

	//Add data to 'database'
	try
	{
		currentCustomer = make_shared<Customer>(customerIdCounter, input[0], input[1], input[2]);
		cout << " >>>>>> Added customer with id: " << customerIdCounter << endl;;
		customerIdCounter++;
	}
	catch (const char* msg)
	{
		cout << " >>>>>> " << msg << endl;
	}
}

void addItem()
{
	vector<string> input;
	cout << "Enter new item in format with delimiter ':' [Id(10 chars):Name:Price]" << endl;
	getInputLine(input);

	if (input.size() != 3)
	{
		cout << " >>>>>> Invalid input " << endl;;
		return;
	}

	shared_ptr<Item> p;

	//Add data to 'database'
	try
	{
		p = getItemById(input[0]);
		if (p != nullptr)
		{
			cout << "Item with this id already exists.";
			return;
		}

		itemsDB[input[0]] = make_shared<Item>(input[0], input[1], stof(input[2]));
		cout << " >>>>>> Added item with id: " << input[0] << endl;;
	}
	catch (const char* msg)
	{
		cout << " >>>>>> " << msg << endl;
	}
}

void addItemToCustomerCart()
{
	string searchedItemId;
	cout << "Enter id of item to add to customer cart (10 chars):" << endl;
	cin >> searchedItemId;

	if (searchedItemId.size() != 10)
	{
		cout << endl << " >>>>>> Invalid id! Id must consists of 10 characters." << endl;
		return;
	}

	shared_ptr<Item> p;

	p = getItemById(searchedItemId);

	if (p == nullptr)
	{
		cout << "Item with id: " << searchedItemId << " not founded!" << endl;
		return;
	}

	currentCustomer->addItemToCart(p);
	cout << "Item with id: " << p->getId() << " added to customer cart" << endl;
}

void printItemById()
{	
	string searchedItemId;
	cout << "Enter item id (10 characters):  ";
	cin >> searchedItemId;

	if (searchedItemId.size() != 10)
	{
		cout << endl << " >>>>>> Invalid id! Id must consists of 10 characters." << endl;
		return;
	}

	shared_ptr<Item> p;
	p = getItemById(searchedItemId);

	if (p != nullptr)
	{
		cout << p->toString() << endl;
	}
	else
	{
		cout << "Item with id: " << searchedItemId << " not founded!" << endl;
	}
}

void chageItemPriceById()
{
	string searchedItemId;
	cout << "Enter item id (10 characters):  ";
	cin >> searchedItemId;

	if (searchedItemId.size() != 10)
	{
		cout << endl << " >>>>>> Invalid id! Id must consists of 10 characters." << endl;
		return;
	}

	shared_ptr<Item> p;
	p = getItemById(searchedItemId);

	if (p == nullptr)
	{
		cout << "Item with id: " << searchedItemId << " not founded!" << endl;
	}

	float newPrice;
	while (true)
	{
		cout << "Enter nerw price: ";
		cin >> newPrice;

		if (!cin)
		{
			cin.clear();
			cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
			cout << endl << " >>>>>> Invalid new price!" << endl;
		}
		else
		{
			break;
		}
	}
	
	p->setPrice(newPrice);
	cout << "Price of item with id: " << p->getId() << " was changed to " << p->getPrice() << endl;

}

void commandManager(unsigned short choice)
{

	switch (choice)
	{
	case 1:
		addCustomer();
		break;
	case 2:
		addItem();
		break;
	case 3:
		printItemById();
		break;
	case 4:
		addItemToCustomerCart();
		break;
	case 5:
		cout << currentCustomer->toString() << endl;
		break;
	case 6:
		chageItemPriceById();
		break;
	default:
		cout << endl << " >>>>>> Invalid command!" << endl;
		break;
	}
}


void start()
{
	bool isRunning = true;
	unsigned short choice;

	while (isRunning)
	{
		choice = 999;
		printMenu();
		cin.sync();
		cin >> choice;

		if (!cin)
		{
			cin.clear(); // reset failbit
			cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n'); //skip bad input
		}

		isRunning = choice != 0;

		if (isRunning)
		{
			commandManager(choice);
		}

	}
}

int main()
{
	start();
    return 0;
}

