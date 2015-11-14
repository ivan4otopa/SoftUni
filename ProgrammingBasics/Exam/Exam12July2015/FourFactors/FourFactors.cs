namespace FourFactors
{
    using System;

    class FourFactors
    {
        static void Main()
        {
            uint fieldGoals = uint.Parse(Console.ReadLine());
            uint fieldGoalAttempts = uint.Parse(Console.ReadLine());
            uint ThreePointFieldGoals = uint.Parse(Console.ReadLine());
            uint turnovers = uint.Parse(Console.ReadLine());
            uint offensiveRebounds = uint.Parse(Console.ReadLine());
            uint opponentDefensiveRebounds = uint.Parse(Console.ReadLine());
            uint freeThrows = uint.Parse(Console.ReadLine());
            uint freeThrowAttempts = uint.Parse(Console.ReadLine());

            double shootingFactorPercentage = (fieldGoals + 0.5 * ThreePointFieldGoals) / fieldGoalAttempts;
            double turnoverFactorPercentage = turnovers / (fieldGoalAttempts + 0.44 * freeThrowAttempts + turnovers);
            double reboundFactorPercentage = (double)offensiveRebounds / (double)(offensiveRebounds + opponentDefensiveRebounds);
            double freeThrowFactorPercentage = (double)freeThrows / (double)fieldGoalAttempts;

            Console.WriteLine(
                "eFG% {0:0.000}\nTOV% {1:0.000}\nORB% {2:0.000}\nFT% {3:0.000}", 
                shootingFactorPercentage,
                turnoverFactorPercentage, 
                reboundFactorPercentage,
                freeThrowFactorPercentage
            );
        }
    }
}
