namespace MasterHerbalist
{
    using System;

    class MasterHerbalist
    {
        static void Main()
        {
            decimal dailyExpenses = decimal.Parse(Console.ReadLine());
            int daysCount = 0;
            decimal seasonEarnings = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Season Over")
                {
                    break;
                }

                string[] parts = input.Split(' ');
                int hours = int.Parse(parts[0]);
                string path = parts[1];
                decimal price = decimal.Parse(parts[2]);
                int numberOfHerbs = 0;

                if (path.Length < hours)                
                {
                    while (path.Length < hours)
                    {
                        path += path;
                    }

                    path = path.Substring(0, hours);                                      
                }

                for (int i = 0; i < hours; i++)
                {
                    if (path[i] == 'H')
                    {
                        numberOfHerbs++;
                    }
                }

                seasonEarnings += numberOfHerbs * price;
                daysCount++;
            }

            decimal dailyEarnings = seasonEarnings / daysCount;

            if (dailyEarnings >= dailyExpenses)
            {
                Console.WriteLine(
                    "Times are good. Extra money per day: {0:0.00}.",
                    dailyEarnings - dailyExpenses);
            }
            else
            {
                Console.WriteLine(
                    "We are in the red. Money needed: {0}.",
                    dailyExpenses * daysCount - seasonEarnings);
            }
        }
    }
}
