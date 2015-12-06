namespace TheExplorer
{
    using System;

    class TheExplorer
    {
        private const char DiamondOutline = '*';
        private const char SurroundingPart = '-';

        static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine(
                    "{0}{1}{0}",
                    new string(SurroundingPart, number / 2),
                    DiamondOutline);

            int upperMiddlePartsCount = 1;

            for (int i = number / 2 - 1; i > 0; i--)
            {
                Console.WriteLine(
                    "{0}{1}{2}{1}{0}",
                    new string(SurroundingPart, i),
                    DiamondOutline,
                    new string(SurroundingPart, upperMiddlePartsCount));

                upperMiddlePartsCount += 2;
            }

            Console.WriteLine(
                "{0}{1}{0}",
                DiamondOutline,
                new string(SurroundingPart, number - 2));

            int lowerMiddlePartsCount = number - 4;

            for (int i = 1; i < number / 2; i++)
            {
                Console.WriteLine(
                    "{0}{1}{2}{1}{0}",
                    new string(SurroundingPart, i),
                    DiamondOutline,
                    new string(SurroundingPart, lowerMiddlePartsCount));

                lowerMiddlePartsCount -= 2;
            }

            Console.WriteLine(
                    "{0}{1}{0}",
                    new string(SurroundingPart, number / 2),
                    DiamondOutline);
        }
    }
}
