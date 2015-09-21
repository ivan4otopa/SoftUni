using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckABitAtGivenPosition
{
    class CheckABitAtGivenPosition
    {
        static void Main(string[] args)
        {
            Console.Write("Enter an unsigned integer: ");
            uint n = uint.Parse(Console.ReadLine());
            Console.Write("Enter the position in which the bit will be checked: ");
            int p = int.Parse(Console.ReadLine());
            bool isOne = (n & (1 << p)) > 0;
            Console.WriteLine("Bit @ " + p + " == 1 " + isOne);
        }
    }
}
