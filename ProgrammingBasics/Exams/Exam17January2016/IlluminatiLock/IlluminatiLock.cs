namespace IlluminatiLock
{
    using System;

    class IlluminatiLock
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine(
                "{0}{1}{0}",
                new string('.', number),
                new string('#', number));

            int rows = number / 2;
            int outerDots = number - 2;
            int innerDots = 0;

            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine(
                    "{0}{1}{2}#{3}#{2}{1}{0}",
                    new string('.', outerDots),
                    new string('#', 2),
                    new string('.', innerDots),
                    new string('.', number - 2));

                outerDots -= 2;
                innerDots += 2;
            }

            outerDots = 1;
            innerDots = number - 3;

            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine(
                    "{0}{1}{2}#{3}#{2}{1}{0}",
                    new string('.', outerDots),
                    new string('#', 2),
                    new string('.', innerDots),
                    new string('.', number - 2));

                outerDots += 2;
                innerDots -= 2;
            }

            Console.WriteLine(
                "{0}{1}{0}",
                new string('.', number),
                new string('#', number));
        }
    }
}
