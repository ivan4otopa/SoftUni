using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01NumbersFrom1ToN
{
    class NumbersFrom1ToN
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a positive integer: ");
            int n = int.Parse(Console.ReadLine());    
            Console.Write("Numbers from 1 to {0}: ", n);
            for (int i = 1; i <= n; i++)
                Console.Write(i + " ");
            Console.WriteLine();
        }
    }
}
