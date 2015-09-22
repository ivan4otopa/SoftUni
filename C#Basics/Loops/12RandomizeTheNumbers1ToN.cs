using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _12RandomizeTheNumbers1ToN
{
    class RandomizeTheNumbers1ToN
    {
        static void Main(string[] args)
        {
            Console.Write("Enter an integer: ");
            int n = int.Parse(Console.ReadLine());
            Random a = new Random();
            bool[] b = new bool[n + 1];
            int num = 0;
            for (int i = 0; i < n; i++)
            {
                num = a.Next(1, n + 1);
                if (!b[num])
                {
                    Console.Write(num + " ");
                    b[num] = true;
                }
                else
                    i--;
            }
            Console.WriteLine();
        }
    }
}
