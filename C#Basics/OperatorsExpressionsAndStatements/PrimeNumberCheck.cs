using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrimeNumberCheck
{
    class PrimeNumberCheck
    {
        static void Main(string[] args)
        {
            Console.Write("Enter an integer <= 100: ");
            int n = int.Parse(Console.ReadLine());
            int counter = 0;
            bool prime;
            for (int i = 1; i <= n; i++)
            {
                if (n % i == 0)
                    counter++;
            }
            if (counter == 2)
            {
                prime = true;
                Console.WriteLine("Prime? " + prime);
            }
            else
            {
                prime = false;
                Console.WriteLine("Prime? " + prime);
            }
        }
    }
}
