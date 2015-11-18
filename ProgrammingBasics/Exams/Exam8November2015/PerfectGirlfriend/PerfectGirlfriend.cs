namespace PerfectGirlfriend
{
    using System;
    using System.Text.RegularExpressions;

    class PerfectGirlfriend
    {
        static void Main()
        {
            string input = string.Empty;
            int dayOfTheWeek = 0;
            long telephoneNumber = 0;
            string braSize = string.Empty;
            string girlName = string.Empty;
            string dayOfTheWeekName = string.Empty;
            int numberOfPerfectGirls = 0;
            long points = 0;

            while (true)
            {
                input = Console.ReadLine();

                if (input == "Enough dates!")
                {
                    break;
                }

                string[] information = input.Split('\\');

                dayOfTheWeekName = information[0];

                switch (dayOfTheWeekName)
                {
                    case "Monday":
                        dayOfTheWeek = 1;
                        break;
                    case "Tuesday":
                        dayOfTheWeek = 2;
                        break;
                    case "Wednesday":
                        dayOfTheWeek = 3;
                        break;
                    case "Thursday":
                        dayOfTheWeek = 4;
                        break;
                    case "Friday":
                        dayOfTheWeek = 5;
                        break;
                    case "Saturday":
                        dayOfTheWeek = 6;
                        break;
                    case "Sunday":
                        dayOfTheWeek = 7;
                        break;
                }

                telephoneNumber = long.Parse(information[1]);
                braSize = information[2];
                girlName = information[3];
                points = 
                    SumOfDigits(telephoneNumber) +
                    dayOfTheWeek +
                    BraSizeSum(braSize) -
                    NameSum(girlName);

                if (points >= 6000)
                {
                    Console.WriteLine("{0} is perfect for you.", girlName);

                    numberOfPerfectGirls++;
                }
                else
                {
                    Console.WriteLine("Keep searching, {0} is not for you.", girlName);
                }
            }

            Console.WriteLine(numberOfPerfectGirls);
        }

        static long SumOfDigits(long number)
        {
            long sum = 0;

            while (number != 0)
            {
                sum += number % 10;
                number /= 10;
            }

            return sum;
        }

        static int BraSizeSum(string braSize)
        {
            var numberRegex = new Regex(@"\d+");
            int braSizeNumber = int.Parse(numberRegex.Match(braSize).ToString());
            var letterRegex = new Regex(@"[a-zA-Z]");
            char braSizeLetter = char.Parse(letterRegex.Match(braSize).ToString());

            int braSum = braSizeNumber * (int)braSizeLetter;

            return braSum;
        }

        static int NameSum(string name)
        {
            var nameSum = (int)name[0] * name.Length;

            return nameSum;
        }
    }
}
