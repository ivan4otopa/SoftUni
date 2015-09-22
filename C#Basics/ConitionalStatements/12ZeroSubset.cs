using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _12ZeroSubset
{
    class ZeroSubset
    {
        static void Main(string[] args)
        {
            Console.Write("Enter five numbers: ");
            string s = Console.ReadLine();
            string[] digits = s.Split(' ');
            int a = int.Parse(digits[0]);
            int b = int.Parse(digits[1]);
            int c = int.Parse(digits[2]);
            int d = int.Parse(digits[3]);
            int e = int.Parse(digits[4]);
            if(a + b == 0)
                Console.WriteLine(a + " + " + b + " = 0");
            if (a + c == 0)
                Console.WriteLine(a + " + " + c + " = 0");
            if (a + d == 0)
                Console.WriteLine(a + " + " + d + " = 0");
            if (a + e == 0)
                Console.WriteLine(a + " + " + e + " = 0");
            if(a + b + c == 0)
                Console.WriteLine(a + " + " + b + " + " + c + " = 0");
            if (a + b + d == 0)
                Console.WriteLine(a + " + " + b + " + " + d + " = 0");
            if (a + b + e == 0)
                Console.WriteLine(a + " + " + b + " + " + e + " = 0");
            if (a + c + d == 0)
                Console.WriteLine(a + " + " + c + " + " + d + " = 0");
            if (a + c + e == 0)
                Console.WriteLine(a + " + " + c + " + " + e + " = 0");
            if (a + d + e == 0)
                Console.WriteLine(a + " + " + d + " + " + e + " = 0");
            if (a + b + c + d == 0)
                Console.WriteLine(a + " + " + b + " + " + c + " + " + d + " = 0");
            if (a + b + c + e == 0)
                Console.WriteLine(a + " + " + b + " + " + c + " + " + e + " = 0");
            if (a + b + d + e == 0)
                Console.WriteLine(a + " + " + b + " + " + d + " + " + e + " = 0");
            if (a + c + d + e == 0)
                Console.WriteLine(a + " + " + c + " + " + d + " + " + e + " = 0");
            if (a + b + c + d + e == 0)
                Console.WriteLine(a + " + " + b + " + " + c + " + " + d + " + " + e + " = 0");
            if (b + c == 0)
                Console.WriteLine(b + " + " + c + " = 0");
            if (b + d == 0)
                Console.WriteLine(b + " + " + d + " = 0");
            if (b + e == 0)
                Console.WriteLine(b + " + " + e + " = 0");
            if(b + c + d == 0)
                Console.WriteLine(b + " + " + c + " + " + d + " = 0");
            if(b + c + e == 0)
                Console.WriteLine(b + " + " + c + " + " + e + " = 0");
            if (b + d + e == 0)
                Console.WriteLine(b + " + " + d + " + " + e + " = 0");
            if (b + c + d + e == 0)
                Console.WriteLine(b + " + " + c + " + " + d + " + " + e + " = 0");
            if (c + d == 0)
                Console.WriteLine(c + " + " + d + " = 0");
            if (c + e == 0)
                Console.WriteLine(c + " + " + e + " = 0");
            if (c + d + e == 0)
                Console.WriteLine(c + " + " + d + " + " + e + " = 0");
            if (d + e == 0)
                Console.WriteLine(d + " + " + c + " = 0");
            else
                Console.WriteLine("No zero subset");
        }
    }
}
