using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08DigitAsWord
{
    class DigitAsWord
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter a number from 0 to 9: ");
                int d = int.Parse(Console.ReadLine());
                switch (d)
                {
                    case 0:
                        Console.WriteLine("Result: Zero");
                        break;
                    case 1:
                        Console.WriteLine("Result: One");
                        break;
                    case 2:
                        Console.WriteLine("Result: Two");
                        break;
                    case 3:
                        Console.WriteLine("Result: Three");
                        break;
                    case 4:
                        Console.WriteLine("Result: Four");
                        break;
                    case 5:
                        Console.WriteLine("Result: Five");
                        break;
                    case 6:
                        Console.WriteLine("Result: Six");
                        break;
                    case 7:
                        Console.WriteLine("Result: Seven");
                        break;
                    case 8:
                        Console.WriteLine("Result: Eight");
                        break;
                    case 9:
                        Console.WriteLine("Result: Nine");
                        break;
                    default:
                        Console.WriteLine("Not a digit");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Not a digit");
            }
        }
    }
}
