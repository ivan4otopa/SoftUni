namespace FiveSpecialLetters
{
    using System;
    using System.Collections.Generic;

    class FiveSpecialLetters
    {
        static void Main()
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            char[] magicLetters = { 'a', 'b', 'c', 'd', 'e' };
            int[] weights = { 5, -12, 47, 7, -32 };
            string uniqueLetters = string.Empty;
            int weight = 0;
            int specialLettersCount = 0;
            List<string> strings = new List<string>();

            for (int j = 0; j < magicLetters.Length; j++)
            {
                for (int k = 0; k < magicLetters.Length; k++)
                {
                    for (int l = 0; l < magicLetters.Length; l++)
                    {
                        for (int m = 0; m < magicLetters.Length; m++)
                        {
                            for (int n = 0; n < magicLetters.Length; n++)
                            {
                                uniqueLetters = GetUniqueLettersString(
                                    magicLetters[j].ToString() +
                                    magicLetters[k].ToString() +
                                    magicLetters[l].ToString() +
                                    magicLetters[m].ToString() + 
                                    magicLetters[n].ToString());
                                weight = CountWeight(uniqueLetters);

                                if (start <= weight && weight <= end)
                                {
                                    strings.Add(
                                        magicLetters[j].ToString() +
                                        magicLetters[k].ToString() +
                                        magicLetters[l].ToString() +
                                        magicLetters[m].ToString() +
                                        magicLetters[n].ToString());
                                    specialLettersCount++;
                                }
                            }
                        }
                    }
                }
            }            

            if (specialLettersCount == 0)
            {
                Console.WriteLine("No");
            }
            else
            {
                strings.Sort();

                Console.WriteLine(string.Join(" ", strings));
            }
        }

        static string GetUniqueLettersString(string letters)
        {
            for (int i = 0; i < letters.Length; i++)
            {
                for (int j = letters.Length - 1; j >= 0; j--)
                {
                    if (i != j && letters[i] == letters[j])
                    {
                        letters = letters.Remove(j, 1).Insert(j, string.Empty);
                    }
                }
            }

            return letters;
        }

        static int CountWeight(string letters)
        {
            int count = 1;
            int weight = 0;

            for (int o = 0; o < letters.Length; o++)
            {
                switch (letters[o])
                {
                    case 'a':
                        weight += count * 5;
                        break;
                    case 'b':
                        weight += count * -12;
                        break;
                    case 'c':
                        weight += count * 47;
                        break;
                    case 'd':
                        weight += count * 7;
                        break;
                    case 'e':
                        weight += count * -32;
                        break;
                }

                count++;
            }

            return weight;
        }
    }
}
