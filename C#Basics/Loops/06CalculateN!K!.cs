using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06CalculateN_K_
{
    class CalculateNK
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter two integers: ");
            Console.Write("n: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("k: ");
            int k = int.Parse(Console.ReadLine());
            int result = 1;
            for (int i = n; i > k; i--)
            {
                result *= i;
            }
            Console.WriteLine("n! / k!: {0}", result);
        }
    }
}
