namespace NewHouse
{
    using System;

    class NewHouse
    {
        private const char Dash = '-';
        private const char Asterisk = '*';
        private const char Pipe = '|';

        static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine("{0}{1}{0}", new string(Dash, number / 2), Asterisk);

            int numberOfAsterisks = 3;

            for (int i = number / 2 - 1; i > 0; i--)
            {
                Console.WriteLine("{0}{1}{0}", new string(Dash, i), new string(Asterisk, numberOfAsterisks));

                numberOfAsterisks += 2;
            }

            Console.WriteLine(new string(Asterisk, number));

            for (int i = 0; i < number; i++)
            {
                Console.WriteLine("{0}{1}{0}", Pipe, new string(Asterisk, number - 2));
            }
        }
    }
}
