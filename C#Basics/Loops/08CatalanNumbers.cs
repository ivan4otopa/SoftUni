using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08CatalanNumbers
{
    class CatalanNumbers
    {
        static void Main(string[] args)
        {
            Console.Write("Enter an integer: ");
            int n = int.Parse(Console.ReadLine());
            int result1 = 1;
            int result2 = 1;
            for (int i = 2 * n; i > n + 1; i--)
                result1 *= i;
            for (int i = 2; i <= n; i++)
                result2 *= i;
            Console.WriteLine("Catalan number: {0}", result1 / result2);
        }
    }
}
