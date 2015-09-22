using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05TheBiggestOfThreeNumbers
{
    class TheBiggestOfThreeNumbers
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
                Console.WriteLine("Biggest: " + a);
            else if (b >= a && b >= c)
                Console.WriteLine("Biggest: " + b);
            else if (c >= a && c >= b)
                Console.WriteLine("Biggest: " + c);
        }
    }
}
