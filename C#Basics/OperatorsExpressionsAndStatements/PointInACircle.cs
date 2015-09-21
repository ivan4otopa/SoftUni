using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PointInACircle
{
    class PointInACircle
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter x and y coordinates: ");
            Console.Write("x: ");
            double x = double.Parse(Console.ReadLine());
            Console.Write("y: ");
            double y = double.Parse(Console.ReadLine());
            bool inside;
            if ((x * x) + (y * y) <= (2 * 2))
            {
                inside = true;
                Console.WriteLine(inside);
            }
            else
            {
                inside = false;
                Console.WriteLine(inside);
            }
        }
    }
}
