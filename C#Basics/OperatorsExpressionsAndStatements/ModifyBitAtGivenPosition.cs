using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModifyBitAtGivenPosition
{
    class ModifyBitAtGivenPosition
    {
        static void Main(string[] args)
        {
            Console.Write("Enter an integer: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Enter the position in which the bit will be changed: ");
            int p = int.Parse(Console.ReadLine());
            Console.Write("Enter 1 or 0 to change bit: ");
            int v = int.Parse(Console.ReadLine());
            int mask;
            int result;
            if (v == 0)
            {
                mask = ~(1 << p);
                result = n & mask;
                Console.WriteLine("Result: " + result);
            }
            if (v == 1)
            {
                mask = 1 << p;
                result = n | mask;
                Console.WriteLine("Result: " + result);
            }
        }
    }
}
