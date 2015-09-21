using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtractBitFromInteger
{
    class ExtractBitFromInteger
    {
        static void Main(string[] args)
        {
            Console.Write("Enter an unsigned integer: ");
            uint n = uint.Parse(Console.ReadLine());
            Console.Write("Enter the position from which the bit will be extracted: ");
            int p = int.Parse(Console.ReadLine());
            if ((1 << p & n) == 0)
                Console.WriteLine("bit @ " + p + ": 0");
            else
                Console.WriteLine("bit @ " + p + ": 1");
        }
    }
}
