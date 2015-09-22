using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1SquareRoot
{
    class SquareRoot
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            try
            {
                uint number = uint.Parse(input);
                double square = Math.Sqrt(number);
                Console.WriteLine(square);
            }
            catch (FormatException)
            {
                Console.Error.WriteLine("Invalid number");
            }
            catch (Exception)
            {
                Console.Error.WriteLine("Invalid number");
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }
    }
}
