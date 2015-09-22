using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03MinMaxAndSumAndAvarageOfNNumbers
{
    class MinMaxAndSumAndAvarageOfNNumbers
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter how many numbers: ");
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            double avarage = 0.0;
            int max = 0;
            int min = 0;
            while (n != 0)
            {
                int a = int.Parse(Console.ReadLine());
                sum += a;
                avarage += a / 2d;
                if (a > max)
                    max = a;
                if (a < max)
                    min = a;
                n--;
            }
            Console.WriteLine("Sum = " + sum);
            Console.WriteLine("Avarage = " + avarage);
            Console.WriteLine("Max = " + max);
            Console.WriteLine("Min = " + min);
        }
    }
}
