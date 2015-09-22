using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SumOf3Numbers
{
    class SumOf3Numbers
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter 3 real numbers: ");
            Console.Write("a: ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("b: ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("c: ");
            double c = double.Parse(Console.ReadLine());
            Console.WriteLine("Sum: " + (a + b + c));
        }
    }
}
