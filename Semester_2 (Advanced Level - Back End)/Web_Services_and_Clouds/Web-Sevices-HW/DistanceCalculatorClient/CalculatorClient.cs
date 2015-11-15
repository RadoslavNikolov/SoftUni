using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceCalculatorClient
{
    class CalculatorClient
    {
        static void Main(string[] args)
        {
            Console.Write("Enter start point X coordinate: ");
            float startPointX = float.Parse(Console.ReadLine());
            Console.Write("Enter start point Y coordinate: ");
            float startPointY = float.Parse(Console.ReadLine());
            Console.Write("Enter end point X coordinate: ");
            float endPointX = float.Parse(Console.ReadLine());
            Console.Write("Enter end point Y coordinate: ");
            float endPointY = float.Parse(Console.ReadLine());

            var distanceService = new DistanceService.DistanceServiceClient();
            var distance = distanceService.CalcDistance(startPointX, startPointY, endPointX, endPointY);
            Console.WriteLine("The distance between two points is:  {0}", distance);
        }
    }
}
