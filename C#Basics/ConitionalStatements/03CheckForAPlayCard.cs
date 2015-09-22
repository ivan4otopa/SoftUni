using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03CheckForAPlayCard
{
    class CheckForAPlayCard
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a card sign: ");
            string character = Console.ReadLine();
            if (character == "2" || character == "3" || character == "4" || character == "5" || character == "6" || character == "7" ||
                character == "8" || character == "9" || character == "10" || character == "J" || character == "Q" || character == "K" ||
                character == "A")
                Console.WriteLine("Valid card sign: Yes");
            else
                Console.WriteLine("Valid card sign: No");
        }
    }
}
