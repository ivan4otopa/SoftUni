namespace ReversedList
{
    using System;

    class ReversedListTest
    {
        static void Main()
        {
            var reversedList = new ReversedList<int>();

            reversedList.Add(0);
            reversedList.Add(1);

            Console.WriteLine("Number of elements: {0}", reversedList.Count);

            reversedList.Add(2);
            reversedList.Add(3);

            Console.WriteLine("Capacity before resizing: {0}", reversedList.Capacity);

            reversedList.Add(4);

            Console.WriteLine("Capacity after adding and resizing: {0}", reversedList.Capacity);

            Console.WriteLine("Iterating:");

            foreach (var element in reversedList)
            {
                Console.WriteLine(element);
            }

            reversedList.Remove(3);

            Console.WriteLine("Count after removing: {0}", reversedList.Count);

            Console.WriteLine("Iterating:");

            foreach (var element in reversedList)
            {
                Console.WriteLine(element);
            }
        }
    }
}
