using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FibonacciNumbers
{
    class FibonacciNumbers
    {
        static void Main(string[] args)
        {
            Console.Write("Enter how long the Fibonacci sequence you want to be: ");
            int n = int.Parse(Console.ReadLine());
            int a = 0;
            int b = 1;
            int temp;
            if (n == 1)
                Console.WriteLine(a);
            if (n == 2)
                Console.WriteLine(a + " " + b);
            if (n == 3)
                Console.WriteLine(a + " " + b + " " + b);
            if (n > 3)
            {
                Console.Write(a + " " + b + " ");
                for (int i = 0; i < n - 2; i++)
                {
                    temp = a;
                    a = b;
                    b += temp;
                    Console.Write(b + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
