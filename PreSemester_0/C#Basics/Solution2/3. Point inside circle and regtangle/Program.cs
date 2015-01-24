using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Point_inside_circle_and_regtangle
{
    class Program
    {
        static void Main(string[] args)
        {
            double coordX, coordY;
            bool checkPointCircle, checkPointRectangle;
            Console.WriteLine("Програма за проверка дали точка с координати x,y е вътре в окръжност с център (0,0) и радиус 5 и едновременно с това извън правоъгълник с точки (-1,1) и (5,5)\r\n");
            Console.Write("Въведете координат X на т.О: ");
            coordX = double.Parse(Console.ReadLine());
            Console.Write("Въведете координат Y на т.О: ");
            coordY = double.Parse(Console.ReadLine());
            //Console.WriteLine(Math.Pow(coordX, 2));
            //Console.WriteLine(Math.Pow(coordY, 2));

            checkPointCircle = Math.Sqrt(Math.Abs(Math.Pow(coordX, 2)) + Math.Abs(Math.Pow(coordY, 2))) <= 5;
            checkPointRectangle = (coordX < -1) || (coordX > 5) || (coordY < 1) || (coordY > 5);

            if (!checkPointCircle)
            {
                Console.WriteLine("Въведената от вас точка с координати ({0},{1}) Не е в окръжността с център (0,0) и радиус 5", coordX, coordY);
            }
            else if (checkPointRectangle)
            {
                Console.WriteLine("Въведената от вас точка с координати ({0},{1})  е в окръжността с център (0,0) и радиус 5 и едновременно с това извън правоъгълник с коордонати (-1,1) и (5,5)", coordX, coordY);

            }
            else
            {
                Console.WriteLine("Въведената от вас точка с координати ({0},{1})  е в окръжността с център (0,0) и радиус 5, но едновременно с това вътре в правоъгълник с коордонати (-1,1) и (5,5)", coordX, coordY);
                
            }
           
        }
    }
}
