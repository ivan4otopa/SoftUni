using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _16DecimalToHexadecimalNumber
{
    class DecimalToHexadecimalNumber
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a decimal number: ");
            long decimalNum = long.Parse(Console.ReadLine());
            string hexadecimalNum = "";
            if (decimalNum == 0)
                hexadecimalNum = "0";
            else
            {
                while (decimalNum > 0)
                {
                    long r = decimalNum % 16;
                    switch (r)
                    {
                        case 10:
                            hexadecimalNum += 'A';
                            break;
                        case 11:
                            hexadecimalNum += 'B';
                            break;
                        case 12:
                            hexadecimalNum += 'C';
                            break;
                        case 13:
                            hexadecimalNum += 'D';
                            break;
                        case 14:
                            hexadecimalNum += 'E';
                            break;
                        case 15:
                            hexadecimalNum += 'F';
                            break;
                        default:
                            hexadecimalNum += r.ToString();
                            break;
                    }
                    decimalNum /= 16;
                }
            }
            Console.WriteLine(Reverse(hexadecimalNum));
        }
        public static string Reverse(string text)
        {
            char[] cArray = text.ToCharArray();
            string reverse = String.Empty;
            for (int i = cArray.Length - 1; i > -1; i--)
            {
                reverse += cArray[i];
            }
            return reverse;
        }
    }
}
