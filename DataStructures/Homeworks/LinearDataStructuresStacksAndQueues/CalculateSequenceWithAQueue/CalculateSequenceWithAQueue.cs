namespace CalculateSequenceWithAQueue
{
    using System;
    using System.Collections.Generic;

    class CalculateSequenceWithAQueue
    {
        static void Main()
        {
            int startNumber = int.Parse(Console.ReadLine());
            var numbersQueue = new Queue<int>();

            numbersQueue.Enqueue(startNumber);

            int numberOfPrints = 0;

            while (numberOfPrints < 50)
            {
                int number = numbersQueue.Dequeue();

                if (numberOfPrints != 49)
                {
                    Console.Write(number + ", ");
                }
                else
                {
                    Console.Write(number);
                }
                numberOfPrints++;

                numbersQueue.Enqueue(number + 1);
                numbersQueue.Enqueue(2 * number + 1);
                numbersQueue.Enqueue(number + 2);
            }

            Console.WriteLine();
        }
    }
}
