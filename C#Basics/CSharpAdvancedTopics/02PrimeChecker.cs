using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02PrimeChecker
{
    class PrimeChecker
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            long number = long.Parse(Console.ReadLine());
            Console.WriteLine(IsPrime(number));
        }
        public static bool IsPrime(long n)
        {
            int count = 0;
            for (long i = 1; i <= n; i++)
            {
                if (n % i == 0)
                    count++;
            }
            if (count == 2)
                return true;
            else
                return false;
        }
    }
}
