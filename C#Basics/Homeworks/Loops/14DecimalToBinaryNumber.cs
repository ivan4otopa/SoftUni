using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _14DecimalToBinaryNumber
{
    class DecimalToBinaryNumber
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a decimal number: ");
            long decimalNum = long.Parse(Console.ReadLine());
            long n = 0;
            string binaryNum = "";
            while (decimalNum > 0)
            {
                n = decimalNum % 2;
                decimalNum /= 2;
                binaryNum = n.ToString() + binaryNum;
            }
            Console.WriteLine(binaryNum);
        }
    }
}
