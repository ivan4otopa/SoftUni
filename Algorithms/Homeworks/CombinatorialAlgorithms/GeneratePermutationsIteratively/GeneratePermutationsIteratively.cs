namespace GeneratePermutationsIteratively
{
    using System;
    using System.Linq;

    class GeneratePermutationsIteratively
    {
        private static int countOfPermutations = 1;

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var permutation = Enumerable.Range(1, n).ToArray();

            Console.WriteLine(string.Join(", ", permutation));

            var array = new int[n];
            int i = 1;

            while (i < n)
            {
                if (array[i] < i)
                {
                    int j = i % 2 == 0 ? 0 : array[i];

                    Swap(ref permutation[i], ref permutation[j]);

                    Console.WriteLine(string.Join(", ", permutation));

                    countOfPermutations++;
                    array[i]++;
                    i = 1;
                }
                else
                {
                    array[i] = 0;
                    i++;
                }
            }

            Console.WriteLine($"Total permutations: {countOfPermutations}");
        }

        private static void Swap(ref int i, ref int j)
        {
            if (i == j)
            {
                return;
            }

            i ^= j;
            j ^= i;
            i ^= j;
        }
    }
}
