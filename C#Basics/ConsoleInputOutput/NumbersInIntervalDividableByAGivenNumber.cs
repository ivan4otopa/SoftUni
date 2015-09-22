using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NumbersInIntervalDividableByAGivenNumber
{
    class NumbersInIntervalDividableByAGivenNumber
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter two positive numbers: ");
            Console.Write("Start: ");
            int start = int.Parse(Console.ReadLine());
            Console.Write("End: ");
            int end = int.Parse(Console.ReadLine());
            int count = 0;
            for (int i = start; i <= end; i++)
            {
                if (i % 5 == 0)
                    count++;
            }
            Console.WriteLine("P: " + count);
        }
    }
}
