namespace CombinationsWithRepetition
{
    using System;

    class CombinationsWithRepetition
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            int[] combination = new int[k];

            FindCombinations(combination, n, 1, 0);
        }

        static void FindCombinations(
            int[] combination,
            int length,
            int startIndex,
            int index)
        {
            if (index == combination.Length)
            {
                Console.WriteLine("(" + String.Join(" ", combination) + ")");

                return;
            }

            for (int i = startIndex; i <= length; i++)
            {
                combination[index] = i;

                FindCombinations(combination, length, i, index + 1);
            }
        }
    }
}
