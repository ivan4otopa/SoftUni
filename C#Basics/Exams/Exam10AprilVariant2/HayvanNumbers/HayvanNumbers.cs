namespace HayvanNumbers
{
    using System;

    class HayvanNumbers
    {
        static void Main()
        {
            int sum = int.Parse(Console.ReadLine());
            int difference = int.Parse(Console.ReadLine());
            int hayvanNumbers = 0;
            int secondNumber = 0;
            int thirdNumber = 0;
            string number = string.Empty;

            for (int i = 555; i <= 999 - 2 * difference; i++)
            {
                secondNumber = i + difference;
                thirdNumber = i + 2 * difference;
                number =
                    i.ToString() +
                    secondNumber.ToString() +
                    thirdNumber.ToString();

                if (DigitsInRangeCheck(i) && DigitsInRangeCheck(secondNumber) &&
                    DigitsInRangeCheck(thirdNumber) && 
                    SumDigits(int.Parse(number)) == sum)
                {
                    Console.WriteLine(number);

                    hayvanNumbers++;
                }
            }

            if (hayvanNumbers == 0)
            {
                Console.WriteLine("No");
            }
        }

        static int SumDigits(int number)
        {
            int digitSum = 0;

            while (number > 0)
            {
                digitSum += number % 10;
                number /= 10;
            }

            return digitSum;
        }

        static bool DigitsInRangeCheck(int number)
        {
            int firstDigit = number / 100;
            int secondDigit = (number % 100) / 10;
            int thirdDigit = number % 10;

            if (firstDigit >= 5 && secondDigit >= 5 && thirdDigit >= 5)
            {
                return true;
            }

            return false;
        }
    }
}
