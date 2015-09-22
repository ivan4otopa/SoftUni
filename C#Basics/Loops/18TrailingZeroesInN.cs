using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _18TrailingZeroesInN
{
    class TrailingZeroesInN
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            int n = int.Parse(Console.ReadLine());
            int zeroes = 0;
            int a;
            for (int i = 5; i <= n; i += 5)
            {
                a = i;
                while (a % 5 == 0)
                {
                    a /= 5;
                    zeroes++;
                }
            }
            Console.WriteLine(zeroes);
        }
    }
}
