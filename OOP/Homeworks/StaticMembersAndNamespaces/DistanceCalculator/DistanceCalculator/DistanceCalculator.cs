using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistanceCalculator
{
    using Point3D;
    static class DistanceCalculator
    {
        public static double CalculateDistance(Point3D pointOne, Point3D pointTwo)
        {
            double deltaX = pointOne.x - pointTwo.x;
            double deltaY = pointOne.y - pointTwo.y;
            double deltaZ = pointOne.z - pointTwo.z;
            return Math.Sqrt((deltaX * deltaX) + (deltaY * deltaY) + (deltaZ * deltaZ));
        }
    }
    class DistanceCalculatorTest
    {
        static void Main()
        {
            Console.WriteLine(DistanceCalculator.CalculateDistance(new Point3D(3, 5, 7), new Point3D(2, 4, 6)));
        }
    }
}
