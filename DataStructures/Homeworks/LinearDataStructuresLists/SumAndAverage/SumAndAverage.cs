namespace SumAndAverage
{
    using System;
    using System.Linq;

    class SumAndAverage
    {
        static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            Console.WriteLine("Sum={0}; Average={1}", numbers.Sum(), numbers.Average());
        }
    }
}
