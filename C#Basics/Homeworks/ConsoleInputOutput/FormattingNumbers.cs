using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormattingNumbers
{
    class FormattingNumbers
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter three numbers: ");
            Console.Write("An integer 0 <= a <= 500: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("A floating-point number: ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("Another floating-point number: ");
            double c = double.Parse(Console.ReadLine());
            Console.WriteLine("|{0, -10:X}|{1}|{2, 10:0.00}|{3, -10:0.000}|", a, Convert.ToString(a, 2).PadLeft(10, '0'), b, c);
        }
    }
}
