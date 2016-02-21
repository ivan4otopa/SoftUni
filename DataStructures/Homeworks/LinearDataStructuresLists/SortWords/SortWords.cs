namespace SortWords
{
    using System;
    using System.Linq;

    class SortWords
    {
        static void Main()
        {
            var words = Console.ReadLine()
                .Split(' ')
                .ToList();

            words.Sort();

            Console.WriteLine(string.Join(" ", words));
        }
    }
}
