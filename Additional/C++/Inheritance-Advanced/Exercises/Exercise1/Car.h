#pragma once
class Car
{
public:
	Car();
	Car(bool isEngBroken);
	~Car();
	bool getIsEngineBroken() const
	{
		return isEngineBroken;
	};

	friend void repairEngine(Car &aCar);

private:
	bool isEngineBroken;
};

