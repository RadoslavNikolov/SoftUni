using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Point_check
{
    class Program
    {
        static void Main(string[] args)
        {
            
            double coordX, coordY;
            bool check;
            Console.WriteLine("Програма за проверка дали точка с координати x,y е вътре в окръжност с център (0,0) и радиус 5 \r\n");
            Console.Write("Въведете координат X на т.О: ");
            coordX = Math.Abs(double.Parse(Console.ReadLine()));
            Console.Write("Въведете координат Y на т.О: ");
            coordY = Math.Abs(double.Parse(Console.ReadLine()));
            //Console.WriteLine(Math.Pow(coordX, 2));
            //Console.WriteLine(Math.Pow(coordY, 2));

            check = Math.Sqrt(Math.Pow(coordX,2)+Math.Pow(coordY,2)) <= 5;
            if (check)
            {
                Console.WriteLine("Въведената от вас точка с координати ({0},{1}) е в окръжността с център (0,0) и радиус 5", coordX,coordY);
            }
            else
            {
                Console.WriteLine("Въведената от вас точка с координати ({0},{1})  НЕ е в окръжността с център (0,0) и радиус 5", coordX, coordY);

            }

        }
    }
}
