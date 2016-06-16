#include "Human.cpp"
#include  <iostream>
#include "Chair.cpp";

int main()
{
	Human pesho("Pesho", 21);
	Human * pointerToPesho = &pesho;

	cout << pointerToPesho->toString();

	Chair aChair;
	aChair.numberOfLegs = 4;
	aChair.color[0] = 182;
	aChair.color[1] = 0x0F;
	aChair.color[2] = 0xDD;

	Chair * pointerToChair = &aChair;
	cout << pointerToChair->toString();

	pointerToChair->color[0] = 120;
	cout << int(pointerToChair->color[0]) << endl;;
	cout << int(aChair.color[0]) << endl;;

	Chair bChair;
	bChair.numberOfLegs = 4;
	bChair.color[0] = 0x00;
	bChair.color[1] = 0x00;
	bChair.color[2] = 0x00;

	pointerToChair = &bChair;
	cout << pointerToChair->toString();
	return 0;
}
