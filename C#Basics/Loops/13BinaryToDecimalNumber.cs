using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _13BinaryToDecimalNumber
{
    class BinaryToDecimalNumber
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number in binary: ");
            string num = Console.ReadLine();
            long decimalNum = 0;
            for (int i = 0; i < num.Length; i++)
            {
                if (num[num.Length - i - 1] == '0')
                    continue;
                decimalNum += (long)Math.Pow(2, i);
            }
            Console.WriteLine(decimalNum);
        }
    }
}
