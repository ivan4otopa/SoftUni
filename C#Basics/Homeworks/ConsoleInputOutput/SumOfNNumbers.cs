using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SumOfNNumbers
{
    class SumOfNNumbers
    {
        static void Main(string[] args)
        {
            Console.Write("Enter how many numbers you would like to sum: ");
            int numbers = int.Parse(Console.ReadLine());
            double a;
            double sum = 0.0;
            for (int i = 1; i <= numbers; i++)
            {
                Console.Write(i + ": ");
                a = double.Parse(Console.ReadLine());
                sum += a;
            }
            Console.WriteLine("Sum: " + sum);
        }
    }
}
