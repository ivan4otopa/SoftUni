using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _10JoinLists
{
    class JoinLists
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            string[] firstNumbers = Console.ReadLine().Split(' ');
            string[] secondNumbers = Console.ReadLine().Split(' ');
            string[] finalLine = new string[firstNumbers.Length + secondNumbers.Length];
            for (int i = 0; i < firstNumbers.Length; i++)
            {
                finalLine[i] = firstNumbers[i];
                for (int j = 0; j < secondNumbers.Length; j++)
                {
                    finalLine[firstNumbers.Length + j] = secondNumbers[j];
                }
            }
            for (int i = 0; i < finalLine.Length; i++)
            {
                numbers.Add(int.Parse(finalLine[i]));
            }
            numbers.Sort();
            List<int> noDuplicates = numbers.Distinct().ToList();
            foreach (var number in noDuplicates)
                Console.Write(number + " ");
            Console.WriteLine();
        }
    }
}
