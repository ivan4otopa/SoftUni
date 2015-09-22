using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02BonusScore
{
    class BonusScore
    {
        static void Main(string[] args)
        {
            Console.Write("Enter score between 1 and 9: ");
            int score = int.Parse(Console.ReadLine());
            if (score >= 1 && score <= 3)
            {
                score *= 10;
                Console.WriteLine("Result: " + score);
            }
            else if (score >= 4 && score <= 6)
            {
                score *= 100;
                Console.WriteLine("Result: " + score);
            }
            else if (score >= 7 && score <= 9)
            {
                score *= 1000;
                Console.WriteLine("Result: " + score);
            }
            else
                Console.WriteLine("Invalid score");
        }
    }
}
