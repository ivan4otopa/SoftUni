namespace MagicDates
{
    using System;

    class MagicDates
    {
        static void Main()
        {
            int startYear = int.Parse(Console.ReadLine());
            int endYear = int.Parse(Console.ReadLine());
            int magicWeight = int.Parse(Console.ReadLine());

            DateTime startDate = new DateTime(startYear, 1, 1);
            DateTime endDate = new DateTime(endYear, 12, 31);

            int dayFirstDigit = 0;
            int daySecondDigit = 0;
            int monthFirstDigit = 0;
            int monthSecondDigit = 0;
            int yearFirstDigit = 0;
            int yearSecondDigit = 0;
            int yearThirdDigit = 0;
            int yearFourthDigit = 0;
            int datesCount = 0;

            for (DateTime i = startDate; i <= endDate; i = i.AddDays(1))
            {
                dayFirstDigit = i.Day / 10;
                daySecondDigit = i.Day % 10;
                monthFirstDigit = i.Month / 10;
                monthSecondDigit = i.Month % 10;
                yearFirstDigit = i.Year / 1000;
                yearSecondDigit = (i.Year / 100) % 10;
                yearThirdDigit = (i.Year / 10) % 10;
                yearFourthDigit = i.Year % 10;

                int[] digits =
                    {
                        dayFirstDigit,
                        daySecondDigit,
                        monthFirstDigit,
                        monthSecondDigit,
                        yearFirstDigit,
                        yearSecondDigit,
                        yearThirdDigit,
                        yearFourthDigit
                    };

                if (GetDigitMultiplicationResult(digits) == magicWeight)
                {
                    Console.WriteLine("{0:dd-MM-yyyy}", i.Date);

                    datesCount++;
                }
            }

            if (datesCount == 0)
            {
                Console.WriteLine("No");
            }
        }

        static int GetDigitMultiplicationResult(int[] digits)
        {
            int result = 0;

            for (int i = 0; i < digits.Length; i++)
            {
                for (int j = i + 1; j < digits.Length; j++)
                {
                    result += digits[i] * digits[j];
                }
            }

            return result;
        }
    }
}
