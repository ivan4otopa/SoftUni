using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OddOrEvenIntegers
{
    class OddOrEvenIntegers
    {
        static void Main(string[] args)
        {
            Console.Write("Enter an integer: ");
            int n = int.Parse(Console.ReadLine());
            bool odd;
            if (n % 2 == 0)
            {
                odd = false;
                Console.WriteLine("Odd? " + odd);
            }
            else
            {
                odd = true;
                Console.WriteLine("Odd? " + odd);
            }
        }
    }
}
