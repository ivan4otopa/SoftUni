using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06TheBiggestOfFiveNumbers
{
    class TheBiggestOfFiveNumbers
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter five numbers: ");
            Console.Write("a: ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("b: ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("c: ");
            double c = double.Parse(Console.ReadLine());
            Console.Write("d: ");
            double d = double.Parse(Console.ReadLine());
            Console.Write("e: ");
            double e = double.Parse(Console.ReadLine());
            if (a >= b && a >= c && a >= d && a >= e)
                Console.WriteLine("Biggest: " + a);
            else if (b >= a && b >= c && b >= d && b >= e)
                Console.WriteLine("Biggest: " + b);
            else if (c >= a && c >= b && c >= d && c >= e)
                Console.WriteLine("Biggest: " + c);
            else if (d >= a && d >= b && d >= c && d >= e)
                Console.WriteLine("Biggest: " + d);
            else if (e >= a && e >= b && e >= c && e >= d)
                Console.WriteLine("Biggest: " + e);
        }
    }
}
