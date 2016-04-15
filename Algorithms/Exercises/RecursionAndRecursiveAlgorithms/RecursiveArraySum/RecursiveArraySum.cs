namespace RecursiveArraySum
{
    using System;

    class RecursiveArraySum
    {
        private static int[] arr = new int[] { 1, 2, 3, 4, 5 };

        static void Main()
        {
            int sum = FindSum(arr, 0);

            Console.WriteLine(sum);
        }

        static int FindSum(int[] arr, int index)
        {
            if (index == arr.Length)
            {
                return 0;
            }

            return arr[index] + FindSum(arr, index + 1);
        }
    }
}
