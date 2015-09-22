using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuadraticEquation
{
    class QuadraticEquation
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter three coefficients: ");
            Console.Write("a: ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("b: ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("c: ");
            double c = double.Parse(Console.ReadLine());
            double D = (b * b) - (4 * a * c);
            if (D > 0)
                Console.WriteLine("roots: x1 = " + ((-b - Math.Sqrt(D)) / (2 * a)) + "; x2 = " + ((-b + Math.Sqrt(D)) / (2 * a)));
            if (D == 0)
                Console.WriteLine("roots: x1 = x2 = " + (-b / (2 * a)));
            if (D < 0)
                Console.WriteLine("No real roots");
        }
    }
}
