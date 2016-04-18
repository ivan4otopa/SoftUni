namespace GenerateSubsetsOfStringArray
{
    using System;

    class GenerateSubsetsOfStringArray
    {
        private static string[] s;

        static void Main()
        {
            s = Console.ReadLine().Split(' ');

            int k = int.Parse(Console.ReadLine());
            var array = new string[k];

            GenerateStringArrays(array);
        }

        private static void GenerateStringArrays(
            string[] array,
            int index = 0,
            int start = 0)
        {
            if (index == array.Length)
            {
                Console.WriteLine($"({string.Join(" ", array)})");
            }
            else
            {
                for (int i = start; i < s.Length; i++)
                {
                    array[index] = s[i];

                    GenerateStringArrays(array, index + 1, i + 1);
                }
            }
        }
    }
}
