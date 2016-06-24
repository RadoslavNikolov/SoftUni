class Cube
{
public:
	Cube(double side) : cubeSide(side) {};
	Cube() : cubeSide(0) {};

	double getCubeSide() const
	{
		return cubeSide;
	}

	void setCubeSide(double side)
	{
		cubeSide = side;
	}

	double calcVolume()
	{
		return cubeSide * cubeSide * cubeSide;
	}

	double calcSurface()
	{
		return 6 * cubeSide * cubeSide;
	}

	double calcPerimeter()
	{
		return 12 * cubeSide;
	}

private:
	double cubeSide;
};
