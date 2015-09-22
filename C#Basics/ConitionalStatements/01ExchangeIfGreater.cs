using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01ExchangeIfGreater
{
    class ExchangeIfGreater
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter two numbers: ");
            Console.Write("a: ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("b: ");
            double b = double.Parse(Console.ReadLine());
            double temp;
            if (a > b)
            {
                temp = a;
                a = b;
                b = temp;
            }
            Console.WriteLine(a + " " + b);
        }
    }
}
