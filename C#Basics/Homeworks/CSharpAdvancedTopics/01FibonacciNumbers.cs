using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01FibonacciNumbers
{
    class FibonacciNumbers
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            int number = int.Parse(Console.ReadLine());
            Fib(number);
        }
        public static void Fib(int n)
        {
            int a = 2;
            int b = 3;
            int c = 0;
            if (n == 0)
                Console.WriteLine("Fibonacci number: " + 1);
            else if (n == 1)
                Console.WriteLine("Fibonacci number: " + 1);
            else if (n == 2)
                Console.WriteLine("Fibonacci number: " + a);
            else if (n == 3)
                Console.WriteLine("Fibonacci number: " + b);
            else
            {
                while (n > 3)
                {
                    c = a;
                    a = b;
                    b += c;
                    n--;
                }
                Console.WriteLine("Fibonacci number: " + b);
            }   
        }
    }
}
