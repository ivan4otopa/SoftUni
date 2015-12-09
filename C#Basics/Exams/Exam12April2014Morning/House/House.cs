namespace House
{
    using System;

    class House
    {
        private const char Asterisk = '*';
        private const char Dot = '.';

        static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine("{0}{1}{0}", new string(Dot, number / 2), Asterisk);

            int middleDotsCount = 1;

            for (int i = number / 2 - 1; i > 0; i--)
            {
                Console.WriteLine(
                    "{0}{1}{2}{1}{0}",
                    new string(Dot, i), 
                    Asterisk,
                    new string(Dot, middleDotsCount));

                middleDotsCount += 2;
            }

            Console.WriteLine(new string(Asterisk, number));

            int wallDistance = number / 4;

            for (int i = 0; i < number / 2 - 1; i++)
            {
                Console.WriteLine(
                    "{0}{1}{2}{1}{0}",
                    new string(Dot, number / 4),
                    Asterisk,
                    new string(Dot, number - 2 * wallDistance - 2));
            }

            Console.WriteLine(
                "{0}{1}{0}",
                new string(Dot, number / 4),
                new string(Asterisk, number - 2 * wallDistance));
        }
    }
}
