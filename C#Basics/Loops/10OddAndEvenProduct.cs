using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _10OddndEvenProduct
{
    class OddAndEvenProduct
    {
        static void Main(string[] args)
        {
            Console.Write("Enter numbers: ");
            string[] numbers = Console.ReadLine().Split(' ');
            int sumEven = 1;
            int sumOdd = 1;
            for (int i = 1; i <= numbers.Count(); i++)
            {
                int a = int.Parse(numbers[i - 1]);
                if(i % 2 == 0)
                    sumEven *= a;
                else
                    sumOdd *= a;
            }
            if (sumEven == sumOdd)
                Console.WriteLine("Yes,\nproduct = {0}", sumEven);
            else
                Console.WriteLine("No,\nodd_product = {0}\neven_product = {1}", sumOdd, sumEven);
        }
    }
}
