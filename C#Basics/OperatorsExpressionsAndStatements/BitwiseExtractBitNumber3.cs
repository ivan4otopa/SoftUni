using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BitwiseExtractBitNumber3
{
    class BitwiseExtractBitNumber3
    {
        static void Main(string[] args)
        {
            Console.Write("Enter an unsigned integer: ");
            uint n = uint.Parse(Console.ReadLine());
            if ((1 << 3 & n) == 0)
                Console.WriteLine("bit #3: 0");
            else
                Console.WriteLine("bit #3: 1");
        }
    }
}
