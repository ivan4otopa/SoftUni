using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04MultiplicationSign
{
    class MultiplicationSign
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
            if ((a > 0 && b > 0 && c > 0))
                Console.WriteLine("Result: +");
            else if ((a < 0 && b > 0 && c > 0) || (a > 0 && b < 0 && c > 0) || (a > 0 && b > 0 && c < 0))
                Console.WriteLine("Result: -");
            else if ((a < 0 && b < 0 && c > 0) || (a > 0 && b < 0 && c < 0) || (a < 0 && b > 0 && c < 0))
                Console.WriteLine("Result: +");
            else if ((a < 0 && b < 0 && c < 0))
                Console.WriteLine("Result: -");
            else if ((a == 0 || b == 0 || c == 0))
                Console.WriteLine("Result: 0");
        }
    }
}
