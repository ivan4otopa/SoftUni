using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06LongestAreaInArray
{
    class LongestAreaInArray
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            int n = int.Parse(Console.ReadLine());
            string[] words = new string[n];
            int max = 0;
            string word = "";
            for (int i = 0; i < n; i++)
            {
                words[i] = Console.ReadLine();
            }
            for (int i = 0; i < words.Length; i++)
            {
                int count = 0;
                for (int j = i; j < words.Length; j++)
                {
                    if (words[i] == words[j])
                    {
                        count++;
                        if (max < count)
                        {
                            max = count;
                            word = words[i];
                        }
                    }
                    else
                        break;
                }
            }
            Console.WriteLine(max);
            for (int i = 0; i < max; i++)
            {
                Console.WriteLine(word);
            }
        }
    }
}
