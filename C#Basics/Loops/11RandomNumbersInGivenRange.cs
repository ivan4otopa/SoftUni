using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _11RandomNumbersInGivenRange
{
    class RandomNumbersInGivenRange
    {
        static void Main(string[] args)
        {
            Console.Write("Enter how many numbers to be displayed: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter range: ");
            Console.Write("Min: ");
            int min = int.Parse(Console.ReadLine());
            Console.Write("Max: ");
            int max = int.Parse(Console.ReadLine());
            Random a = new Random();
            for (int i = 0; i < n; i++)
            {
                Console.Write(a.Next(min, max + 1) + " ");
            }
            Console.WriteLine();
        }
    }
}
