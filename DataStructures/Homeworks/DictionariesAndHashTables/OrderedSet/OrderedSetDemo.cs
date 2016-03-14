namespace OrderedSet
{
    using System;

    class OrderedSetDemo
    {
        static void Main()
        {
            var orderedSet = new OrderedSet<int>();

            orderedSet.Add(1);
            orderedSet.Add(2);
            orderedSet.Add(3);
            orderedSet.Add(4);
            orderedSet.Add(5);
            orderedSet.Add(-5);

            Console.WriteLine(orderedSet.Contains(-5));
            Console.WriteLine(orderedSet.Contains(10));
            Console.WriteLine(orderedSet.Contains(2));
            Console.WriteLine(orderedSet.Count);

            foreach (var element in orderedSet)
            {
                Console.WriteLine(element);
            }
        }
    }
}
