using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _14LongestWordInAText
{
    class LongestWordInAText
    {
        static void Main(string[] args)
        {
            Console.Write("Enter sentence: ");
            string sentence = Console.ReadLine();
            string trimmedSentence = sentence.Trim('.');
            string[] words = trimmedSentence.Split(' ');
            string longestWord = words[0];
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > longestWord.Length)
                    longestWord = words[i];
            }
            Console.WriteLine(longestWord);
        }
    }
}
