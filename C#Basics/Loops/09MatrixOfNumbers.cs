using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09MatrixOfNumbers
{
    class MatrixOfNumbers
    {
        static void Main(string[] args)
        {
            Console.Write("Enter an integer: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                for (int j = i; j < n + i; j++)
                    Console.Write(j + " ");
                Console.WriteLine();
            }
        }
    }
}
