using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trapezoids
{
    class Trapezoids
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter top and bottom sides a and b, and height h of trapezoid: ");
            Console.Write("a: ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("b: ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("h: ");
            double h = double.Parse(Console.ReadLine());
            Console.WriteLine("Area: " + (((a + b) / 2) * h));
        }
    }
}
