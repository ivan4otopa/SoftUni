using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07SortThreeNumbersWithNestedIfs
{
    class SortThreeNumbersWithNestedIfs
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter three numbers: ");
            Console.Write("a: ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("b: ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("c: ");
            double c = double.Parse(Console.ReadLine());
            if (a >= b && a >= c)
            {
                if (b >= c)
                    Console.WriteLine("Result: " + a + " " + b + " " + c);
                else
                    Console.WriteLine("Result: " + a + " " + c + " " + b);
            }
            else if (b >= a && b >= c)
            {
                if (a >= c)
                    Console.WriteLine("Result: " + b + " " + a + " " + c);
                else
                    Console.WriteLine("Result: " + b + " " + c + " " + a);
            }
            else if (c >= a && c >= b)
            {
                if (a >= b)
                    Console.WriteLine("Result: " + c + " " + a + " " + b);
                else
                    Console.WriteLine("Result: " + c + " " + b + " " + a);
            }
        }
    }
}
