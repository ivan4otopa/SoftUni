using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _17CalculateGCD
{
    class CalculateGCD
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter two numbers: ");
            Console.Write("a: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("b: ");
            int b = int.Parse(Console.ReadLine());
            int c = 0;
            while (b != 0)
            {
                c = b;
                b = a % b;
                a = c;
            }
            Console.WriteLine(a);
        }
    }
}
