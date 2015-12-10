namespace Arrow
{
    using System;

    class Arrow
    {
        private const char NumberSign = '#';
        private const char Dot = '.';

        static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine(
                "{0}{1}{0}",
                new string(Dot, number / 2),
                new string(NumberSign, number));

            for (int i = 0; i < number - 2; i++)
            {
                Console.WriteLine(
                    "{0}{1}{2}{1}{0}",
                    new string(Dot, number / 2),
                    NumberSign,
                    new string(Dot, number - 2));
            }

            Console.WriteLine(
                "{0}{1}{0}",
                new string(NumberSign, number / 2 + 1),
                new string(Dot, number - 2));

            int dotOuterCount = 1;

            for (int i = (number - 2) * 2 - 1; i > 0; i -= 2)
            {
                Console.WriteLine(
                    "{0}{1}{2}{1}{0}",
                    new string(Dot, dotOuterCount),
                    NumberSign,
                    new string(Dot, i));

                dotOuterCount++;
            }

            Console.WriteLine("{0}{1}{0}", new string(Dot, number - 1), NumberSign);
        }
    }
}
