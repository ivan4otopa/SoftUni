namespace SudokuResults
{
    using System;

    class SudokuResults
    {
        static void Main()
        {
            string input = string.Empty;
            int minutes = 0;
            int seconds = 0;
            int totalSeconds = 0;
            int numberOfGames = 0;

            while (true)
            {
                input = Console.ReadLine();

                if (input == "Quit")
                {
                    break;
                }

                string[] timeParts = input.Split(':');

                minutes = int.Parse(timeParts[0]);
                seconds = int.Parse(timeParts[1]);
                totalSeconds += minutes * 60 + seconds;
                numberOfGames++;
            }

            var averageSeconds = Math.Ceiling((double)totalSeconds / numberOfGames);
            string starType = string.Empty;

            if (averageSeconds < 720)
            {
                starType = "Gold";
            }
            else if (720 <= averageSeconds && averageSeconds <= 1440)
            {
                starType = "Silver";
            }
            else if (averageSeconds > 1440)
            {
                starType = "Bronze";
            }

            Console.WriteLine(
                "{0} Star\nGames - {1} \\ Average seconds - {2}",
                starType,
                numberOfGames,
                averageSeconds    
            );
        }
    }
}
