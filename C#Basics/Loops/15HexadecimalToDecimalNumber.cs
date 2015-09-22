using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _15HexadecimalToDecimalNumber
{
    class HexadecimalToDecimalNumber
    {
        static void Main(string[] args)
        {
            Console.Write("Enter hexadecimal number: ");
            string hexadecimalNum = Console.ReadLine();
            long decimalNumber = 0;
            long power = 1;
            for (int i = hexadecimalNum.Length - 1; i >= 0; i--)
            {
                int num;
                switch (hexadecimalNum[i])
                {
                    case 'A':
                        num = 10;
                        break;
                    case 'B':
                        num = 11;
                        break;
                    case 'C':
                        num = 12;
                        break;
                    case 'D':
                        num = 13;
                        break;
                    case 'E':
                        num = 14;
                        break;
                    case 'F':
                        num = 15;
                        break;
                    default:
                        num = (int)hexadecimalNum[i] - 48;
                        break;
                }
                decimalNumber += num * power;
                power *= 16;
            }
            Console.WriteLine(decimalNumber);
        }
    }
}
