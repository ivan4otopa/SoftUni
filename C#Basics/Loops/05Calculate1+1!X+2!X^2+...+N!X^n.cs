using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05Calculate1_1_X_2_X_2_._._._N_X_n
{
    class Calculate11X2X2Nn
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter two integers: ");
            Console.Write("n: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("x: ");
            int x = int.Parse(Console.ReadLine());
            double factorial = 1.0;
            double result = 1.0;
            double divisor = 1.0;
            for (int i = 1; i <= n; i++)
            {
                factorial *= i;
                divisor *= x;
                result += factorial / divisor;
            }
            Console.WriteLine("{0:0.00000}", result);
        }
    }
}
