using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NumbersFrom1ToN
{
    class NumbersFrom1ToN
    {
        static void Main(string[] args)
        {
            Console.Write("Enter how many numbers should be printed: ");
            int numbers = int.Parse(Console.ReadLine());
            for (int i = 1; i <= numbers; i++)
                Console.WriteLine(i);
        }
    }
}
