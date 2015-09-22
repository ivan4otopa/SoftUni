using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrintLongSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 2; i < 1003; i++)
            {
                if (i % 2 == 0)
                    Console.WriteLine(i.ToString());
                else
                    Console.WriteLine((-i).ToString());
            }
        }
    }
}
