using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrintASequence
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 2; i < 13; i++)
            {
                if (i % 2 == 0)
                    Console.WriteLine(i.ToString());
                else
                    Console.WriteLine((-i).ToString());
            }
        }
    }
}
