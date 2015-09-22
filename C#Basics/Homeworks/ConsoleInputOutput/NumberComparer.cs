using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NumberComparer
{
    class NumberComparer
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter two numbers: ");
            Console.Write("a: ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("b: ");
            double b = double.Parse(Console.ReadLine());
            Console.WriteLine("Greater: {0}", Math.Max(a, b));
        }
    }
}
