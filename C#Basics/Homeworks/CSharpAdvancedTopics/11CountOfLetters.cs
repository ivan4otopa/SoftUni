using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _11CountOfLetters
{
    class CountOfLetters
    {
        static void Main(string[] args)
        {
            Console.Write("Enter letter sequence: ");
            string[] letterSequence = Console.ReadLine().Split(' ');
            Array.Sort(letterSequence);
            HashSet<string> letters = new HashSet<string>();
            for (int i = 0; i < letterSequence.Length; i++)
                letters.Add(letterSequence[i]);
            int count = 0;
            foreach (var letter in letters)
            {
                for (int i = 0; i < letterSequence.Length; i++)
                {
                    if (letter == letterSequence[i])
                        count++;
                }
                Console.WriteLine(letter + " -> " + count);
                count = 0;
            }
            Console.WriteLine();
        }
    }
}
