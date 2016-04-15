namespace NestedLoopsToRecursion
{
    using System;

    class NestedLoopsToRecursion
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] combination = new int[n];

            FindCombinations(combination, n, 0);
        }

        static void FindCombinations(int[] combination, int length, int index)
        {
            if (index == length)
            {
                Console.WriteLine(string.Join(" ", combination));

                return;
            }
            else
            {
                for (int i = 1; i <= length; i++)
                {
                    combination[index] = i;

                    FindCombinations(combination, length, index + 1);
                }
            }
        }
    }
}
