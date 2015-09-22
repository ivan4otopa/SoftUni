using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2EnterNumbers
{
    class EnterNumbers
    {
        static void Main(string[] args)
        {
            int start = 1;
            for (int i = 0; i < 10; i++)
            {
                start = ReadNumber(start, 100);
            }
        } 
        public static int ReadNumber(int start, int end)
        {
            int number = 0;
            try
            {
                number = int.Parse(Console.ReadLine());
                if (start >= number || number > end)
                {
                    while (start >= number || number > end)
                    {
                        Console.WriteLine("Enter a number in the range ({0}...{1}).", start, end);
                        number = int.Parse(Console.ReadLine());
                    }
                }
            }
            catch (FormatException)
            {
                Console.Error.WriteLine("Invalid number!");
            }
            return number;
        }
    }
}
