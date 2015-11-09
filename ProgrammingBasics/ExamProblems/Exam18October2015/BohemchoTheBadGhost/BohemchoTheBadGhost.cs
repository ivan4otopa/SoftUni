namespace BohemchoTheBadGhost
{
    using System;

    class BohemchoTheBadGhost
    {
        static void Main()
        {
            string input = string.Empty;
            string binaryFloor = "".PadLeft(32, '0');
            int currentApartment = 0;
            long totalScore = 0;
            int totalLightsOn = 0;

            while (true)
            {
                input = Console.ReadLine();

                if (input == "Stop, God damn it")
                {
                    break;
                }
                else
                {
                    binaryFloor = Convert.ToString(long.Parse(input), 2).PadLeft(32, '0');
                }

                string[] apartments = Console.ReadLine().Split(' ');

                foreach (var apartment in apartments)
                {
                    currentApartment = int.Parse(apartment);

                    if (binaryFloor[31 - currentApartment] == '0')
                    {
                        binaryFloor = binaryFloor.Remove(31 - currentApartment, 1).Insert(31 - currentApartment, "1");
                    }
                    else
                    {
                        binaryFloor = binaryFloor.Remove(31 - currentApartment, 1).Insert(31 - currentApartment, "0");
                    }
                }

                for (int i = 0; i < binaryFloor.Length; i++)
                {
                    if (binaryFloor[i] == '1')
                    {
                        totalLightsOn++;
                    }
                }

                totalScore += Convert.ToInt64(binaryFloor, 2);

                binaryFloor = "".PadLeft(32, '0');
            }

            Console.WriteLine("Bohemcho left {0} lights on and his score is {1}", totalLightsOn, totalScore);            
        }
    }
}
