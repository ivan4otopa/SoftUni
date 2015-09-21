using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BitExchange_Advanced_
{
    class BitExchangeAdvanced
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter an unsigned integer: ");
                uint n = uint.Parse(Console.ReadLine());
                Console.Write("Enter bit position 1: ");
                int p = int.Parse(Console.ReadLine());
                Console.Write("Enter bit position 2: ");
                int q = int.Parse(Console.ReadLine());
                Console.Write("Enter number of bits that will be swapped: ");
                int k = int.Parse(Console.ReadLine());
                if (Math.Max(p, q) + k - 1 > 31)
                    Console.WriteLine("out of range");
                else if (Math.Min(p, q) + k - 1 >= Math.Max(p, q))
                    Console.WriteLine("overlapping");
                else
                {
                    for (int i = p; i <= p + k - 1; i++)
                    {
                        uint mask = 1;
                        uint qBits = (n & (mask << q)) >> q;
                        uint pBits = (n & (mask << i)) >> i;
                        n &= ~(mask << i);
                        n &= ~(mask << q);
                        n |= pBits << q;
                        n |= qBits << i;
                        q++;
                    }
                    Console.WriteLine("Result: " + n);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("out of range");
            }
        }
    }
}
