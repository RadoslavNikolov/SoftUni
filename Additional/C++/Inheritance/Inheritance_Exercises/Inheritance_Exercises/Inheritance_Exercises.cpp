// Inheritance_Exercises.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"


void PrintIntValue(int * value)
{
	printf("%d, pointing to address %p\n", *value, value);
}


int main()
{
	int array[] = { 1,2,4,5,65,445,65644,1445,47496 };
	int * pointerToArray = array;
	printf("%d\n", pointerToArray[4]);
	PrintIntValue(&pointerToArray[4]);
	

	/*int variable = 5;
	printf("%d, with address: %p\n", variable, &variable);
	int * pointerToVariable = &variable;
	printf("%d, pointing to address %p\n", *pointerToVariable, pointerToVariable);

	PrintIntValue(pointerToVariable);
	PrintIntValue(&variable);*/

    return 0;
}

