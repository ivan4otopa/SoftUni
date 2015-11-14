namespace LocalElections
{
    using System;

    class LocalElections
    {
        private const char BallotBackground = '.';

        static void Main()
        {
            int numberOfCandidates = int.Parse(Console.ReadLine());
            int electorChoice = int.Parse(Console.ReadLine());
            char votingSymbol = char.Parse(Console.ReadLine().ToUpper());

            for (int i = 1; i <= numberOfCandidates; i++)
            {
                if (i == electorChoice)
                {
                    if (votingSymbol == 'X')
                    {
                        Console.WriteLine(
                            "{0}\n{1}+{2}+{1}\n{1}|.\\./.|{1}\n{3}.|..X..|{1}\n{1}|./.\\.|{1}\n{1}+{2}+{1}",
                            new string(BallotBackground, 13),
                            new string(BallotBackground, 3),
                            new string('-', 5),
                            i.ToString().PadLeft(2, '0')
                        );
                    }
                    else
                    {
                        Console.WriteLine(
                            "{0}\n{1}+{2}+{1}\n{1}|\\.../|{1}\n{3}.|.\\./.|{1}\n{1}|..V..|{1}\n{1}+{2}+{1}",
                            new string(BallotBackground, 13),
                            new string(BallotBackground, 3),
                            new string('-', 5),
                            i.ToString().PadLeft(2, '0')
                        );
                    }
                }
                else
                {
                    Console.WriteLine(
                        "{0}\n{1}+{2}+{1}\n{1}|{3}|{1}\n{4}.|{3}|{1}\n{1}|{3}|{1}\n{1}+{2}+{1}",
                        new string(BallotBackground, 13),
                        new string(BallotBackground, 3),
                        new string('-', 5),
                        new string(BallotBackground, 5),
                        i.ToString().PadLeft(2, '0')
                    );
                }
            }

            Console.WriteLine("{0}", new string(BallotBackground, 13));
        }
    }
}
