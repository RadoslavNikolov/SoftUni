
class Figure
{
public:
	virtual float perimeter() = 0;
	virtual float surface() = 0;

private:

};

class Rectangle : public Figure
{
public:
	float sideA;
	float sideB;

	float perimeter() 
	{
		return 2 * sideA + 2 * sideB;
	}

	float surface()
	{
		return sideA * sideB;
	}
};

class Circle : public Figure
{
public:
	float radius;

	float perimeter()
	{
		return 2 * 3.141592 * radius;
	}

	float surface()
	{
		return 3.141592 * radius * radius;
	}

private:

};




