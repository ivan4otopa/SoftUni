namespace CrossingSequences
{
    using System;

    class CrossingSequences
    {
        static void Main()
        {
            int firstTribonacci = int.Parse(Console.ReadLine());
            int secondTribonacci = int.Parse(Console.ReadLine());
            int thirdTribonacci = int.Parse(Console.ReadLine());
            int initialNumber = int.Parse(Console.ReadLine());
            int step = int.Parse(Console.ReadLine());
            int count = 1;
            int increaseCount = 0;
            bool isTribonacci = false;           

            while (initialNumber < 1000000)
            {
                initialNumber += step * count;
                increaseCount++;

                if (IsTribonacci(
                    firstTribonacci,
                    secondTribonacci,
                    thirdTribonacci,
                    initialNumber))
                {
                    isTribonacci = true;

                    Console.WriteLine(initialNumber);

                    break;
                }

                if (increaseCount % 2 == 0)
                {
                    count++;
                }
            }

            if (!isTribonacci)
            {
                Console.WriteLine("No");
            }
        }

        static bool IsTribonacci(
            int firstTribonacci,
            int secondTribonacci,
            int thirdTribonacci,
            int number)
        {
            if (number > 1000000)
            {
                return false;
            }

            int temporaryFirst = firstTribonacci;
            int temporarySecond = secondTribonacci;
            int temporaryThird = thirdTribonacci;
            int result = 0;

            while (temporaryFirst < 1000000)
            {
                if (firstTribonacci == number || secondTribonacci == number ||
                    thirdTribonacci == number)
                {
                    return true;
                }

                result = temporaryFirst + temporarySecond + temporaryThird;
                temporaryFirst = temporarySecond;
                temporarySecond = temporaryThird;
                temporaryThird = result;

                if (result == number)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
