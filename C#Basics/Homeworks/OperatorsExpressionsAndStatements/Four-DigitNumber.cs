using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Four_DigitNumber
{
    class FourDigitNumber
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a four-digit number: ");
            int n = int.Parse(Console.ReadLine());
            int a = n / 1000;
            int b = (n / 100) % 10;
            int c = (n / 10) % 10;
            int d = n % 10;
            Console.WriteLine("Sum of digits: " + (a + b + c + d));
            Console.WriteLine("Reversed: " + d + c + b + a);
            Console.WriteLine("Last digit in front: " + d + a + b + c);
            Console.WriteLine("Second and third digits exchanged: " + a + c + b + d);
        }
    }
}
