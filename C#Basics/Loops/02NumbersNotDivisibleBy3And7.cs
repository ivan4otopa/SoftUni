using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02NumbersNotDivisibleBy3And7
{
    class NumbersNotDivisibleBy3And7
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a positive integer: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                if (i % 3 != 0 && i % 7 != 0)
                    Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
}
