using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DivideBy7And5
{
    class DivideBy7And5
    {
        static void Main(string[] args)
        {
            Console.Write("Enter an integer: ");
            int n = int.Parse(Console.ReadLine());
            bool canBeDivided;
            if (n != 0 && n % 35 == 0)
            {
                canBeDivided = true;
                Console.WriteLine("Divided by 7 and 5? " + canBeDivided);
            }
            else
            {
                canBeDivided = false;
                Console.WriteLine("Divided by 7 and 5? " + canBeDivided);
            }
        }
    }
}
