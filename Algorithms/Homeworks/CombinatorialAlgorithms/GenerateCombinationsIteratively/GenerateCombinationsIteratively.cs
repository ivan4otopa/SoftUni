namespace GenerateCombinationsIteratively
{
    using System;
    using System.Collections.Generic;

    class GenerateCombinationsIteratively
    {      
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            foreach (int[] c in Combinations(k, n))
            {
                for (int i = 0; i < c.Length; i++)
                {
                    Console.Write(c[i] + " ");
                }

                Console.WriteLine();
            }
        }

        public static IEnumerable<int[]> Combinations(int k, int n)
        {
            int[] result = new int[k];

            Stack<int> stack = new Stack<int>();

            stack.Push(1);

            while (stack.Count > 0)
            {
                int index = stack.Count - 1;
                int value = stack.Pop();

                while (value <= n)
                {
                    result[index++] = value++;
                    stack.Push(value);

                    if (index == k)
                    {
                        yield return result;
                        break;
                    }
                }
            }
        }
    }
}
