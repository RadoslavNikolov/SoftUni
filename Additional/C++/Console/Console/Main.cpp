#include "Console.h"

int main()
{
	Console console;

	while (console.isActive()) {	
		console.update();
	}

	return 0;
}
