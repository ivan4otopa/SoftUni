namespace Illuminati
{
    using System;

    class Illuminati
    {
        static void Main()
        {
            string message = Console.ReadLine();
            int numberOfVowels = 0;
            int vowelsSum = 0;

            for (int i = 0; i < message.Length; i++)
            {
                switch (message[i])
                {
                    case 'a':
                    case 'A':
                        vowelsSum += 65;
                        numberOfVowels++;
                        break;
                    case 'e':
                    case 'E':
                        vowelsSum += 69;
                        numberOfVowels++;
                        break;
                    case 'i':
                    case 'I':
                        vowelsSum += 73;
                        numberOfVowels++;
                        break;
                    case 'o':
                    case 'O':
                        vowelsSum += 79;
                        numberOfVowels++;
                        break;
                    case 'u':
                    case 'U':
                        vowelsSum += 85;
                        numberOfVowels++;
                        break;
                }
            }

            Console.WriteLine("{0}\n{1}", numberOfVowels, vowelsSum);
        }
    }
}
