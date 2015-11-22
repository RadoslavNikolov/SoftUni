using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceCalculator
{
    using Point_3D;

    public static class DistanceCalculator
    {
        //This way the method overload accepts point with any dimension. The only condition is the object to implement
        //IPointable interface. That is how i can be sure the object has method to return point as array of doubles
        public static double CalculateDistance(IPointable p1, IPointable p2)
        {
            var point1 = p1.PointToArray();
            var point2 = p2.PointToArray();

            //Using LINQ.This sums up squared pairwise differences between individual coordinates, 
            //and returns the arithmetic square root of the sum
            var dist = Math.Sqrt(point1.Zip(point2, (a, b) => (a - b) * (a - b)).Sum());

            return dist;
        }
    }
}
