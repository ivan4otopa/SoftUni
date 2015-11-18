namespace Summertime
{
    using System;

    class Summertime
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            string spaces = new string(' ', number - (number / 2 + 1));

            Console.WriteLine(spaces + new string('*', number + 1));

            for (int i = 0; i < number / 2 + 1; i++)
            {
                Console.WriteLine(spaces + "*" + new string(' ', number - 1) + "*");
            }

            if (number != 3)
            {
                for (int i = 1; i < number / 2; i++)
                {
                    Console.WriteLine(new string(' ', number / 2 - i) + "*" + new string(' ', number + i * 2 - 1) + "*");
                }
            }

            for (int i = 0; i < number; i++)
            {
                Console.WriteLine("*" + new string('.', number * 2 - 2) + "*");
            }

            for (int i = 0; i < number; i++)
            {
                Console.WriteLine("*" + new string('@', number * 2 - 2) + "*");
            }

            Console.WriteLine(new string('*', number * 2));
        }
    }
}
