namespace ReverseArray
{
    using System;

    class ReverseArray
    {
        static int[] arr = new int[] { 1, 2, 3, 4, 5, 6 };

        static void Main()
        {
            ReverseArr(arr, 0, arr.Length - 1);

            Console.WriteLine(string.Join(" ", arr));
        }
        
        static void ReverseArr(int[] arr, int index, int reverseIndex)
        {
            if (index > arr.Length / 2 - 1)
            {
                return;
            }

            int numberAtIndex = arr[index];

            arr[index] = arr[reverseIndex];
            arr[reverseIndex] = numberAtIndex;

            ReverseArr(arr, index + 1, reverseIndex - 1);
        }
    }
}
