using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CirclePerimeterAndArea
{
    class CirclePerimeterAndArea
    {
        static void Main(string[] args)
        {
            Console.Write("Enter radius of circle: ");
            double r = double.Parse(Console.ReadLine());
            double perimeter = 2 * 3.14 * r;
            double area = 3.14 * r * r;
            Console.WriteLine("Perimeter: {0:0.00} \nArea: {1:0.00}", perimeter, area);
        }
    }
}
