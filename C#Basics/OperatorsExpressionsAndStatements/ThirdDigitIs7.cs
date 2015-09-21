using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThirdDigitisSeven
{
    class ThirdDigitisSeven
    {
        static void Main(string[] args)
        {
            Console.Write("Enter an integer: ");
            int n = int.Parse(Console.ReadLine());
            int b = n / 100;
            int c = b % 10;
            bool isSeven;
            if (c == 7)
            {
                isSeven = true;
                Console.WriteLine("Third digit 7? " + isSeven);
            }
            else
            {
                isSeven = false;
                Console.WriteLine("Third digit 7? " + isSeven);
            }
        }
    }
}
