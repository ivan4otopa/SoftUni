namespace ReverseNumbersWithAStack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ReverseNumbersWithAStack
    {
        static void Main()
        {
            string numbersSequence = Console.ReadLine();

            if (numbersSequence == "(empty)")
            {
                Console.WriteLine(numbersSequence);
            }
            else
            {
                var numbers = numbersSequence.Split(' ').Select(int.Parse);
                var numbersStack = new Stack<int>();

                foreach (var number in numbers)
                {
                    numbersStack.Push(number);
                }

                Console.WriteLine(string.Join(" ", numbersStack));
            }
        }
    }
}
