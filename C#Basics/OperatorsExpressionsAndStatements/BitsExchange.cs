using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BitsExchange
{
    class BitsExchange
    {
        static void Main(string[] args)
        {
            Console.Write("Enter an unsigned integer: ");
            uint n = uint.Parse(Console.ReadLine());
            uint mask = 7;
            uint bitsFrom3 = (n & (mask << 3)) >> 3;
            uint bitsFrom24 = (n & (mask << 24)) >> 24;
            n &= ~(mask << 3);
            n &= ~(mask << 24);
            n |= bitsFrom3 << 24;
            n |= bitsFrom24 << 3;
            Console.WriteLine("Result: " + n);
        }
    }
}
