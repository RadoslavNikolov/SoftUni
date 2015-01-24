using System;

class BatGoikoTower
{
    static void Main()
    {
        int height = int.Parse(Console.ReadLine());
        int triangularNumber = 1;
        int tempTriangularNum = 1;

        for (int i = 0; i < height; i++)
        {
            string outerDots=new string('.',height-i-1);
            string middleDots = new string('.', 2 * height - 2 * (height - i - 1) - 2);
            if (i==triangularNumber)
	        {
                middleDots = new string('-', 2 * height - 2 * (height - i - 1) - 2);
                tempTriangularNum++;
                triangularNumber += tempTriangularNum;
	        }

            Console.WriteLine("{0}/{1}\\{0}",outerDots,middleDots);
        }
    }
}
