using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07CalculateNKN_K
{
    class CalculateNKNK
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter two integers: ");
            Console.Write("n: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("k: ");
            int k = int.Parse(Console.ReadLine());
            long result1 = 1;
            long result2 = 1;
            for (int i = n; i > k; i--)
                result1 *= i;
            for (int i = 2; i <= n - k; i++)
                result2 *= i;
            Console.WriteLine("n! / k! * (n - k)!: {0}", result1 / result2);
        }                    
    }
}
