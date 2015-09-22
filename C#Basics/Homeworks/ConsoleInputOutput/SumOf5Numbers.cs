using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SumOf5Numbers
{
    class SumOf5Numbers
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter 5 numbers: ");
            string numbers = Console.ReadLine();
            string[] digits = numbers.Split(' ');
            double sum = 0.0;
            for (int i = 0; i < 5; i++)
            {
                sum += double.Parse(digits[i]);
            }
            Console.WriteLine("Sum: " + sum);
        }
    }
}
