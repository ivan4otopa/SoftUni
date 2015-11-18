namespace FirefightingOrganization
{
    using System;

    class FirefightingOrganization
    {
        static void Main()
        {
            int numberOfFirefighters = int.Parse(Console.ReadLine());
            int temporaryNumberOfFirefighters = numberOfFirefighters;
            string input = string.Empty;
            int kids = 0;
            int adults = 0;
            int seniors = 0;
            int totalKids = 0;
            int totalAdults = 0;
            int totalSeniors = 0;

            while (true)
            {
                input = Console.ReadLine();

                if (input == "rain")
                {
                    break;
                }

                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] == 'K')
                    {
                        kids++;
                    }
                    else if(input[i] == 'A')
                    {
                        adults++;
                    }
                    else
                    {
                        seniors++;
                    }
                }

                if (numberOfFirefighters >= input.Length)
                {
                    totalKids += kids;
                    totalAdults += adults;
                    totalSeniors += seniors;
                }
                else
                {
                    if (kids <= numberOfFirefighters)
                    {
                        totalKids += kids;
                        numberOfFirefighters -= kids;

                        if (adults <= numberOfFirefighters)
                        {
                            totalAdults += adults;
                            numberOfFirefighters -= adults;

                            if (seniors <= numberOfFirefighters)
                            {
                                totalSeniors += seniors;
                                numberOfFirefighters -= seniors;
                            }
                            else
                            {
                                int unsavedSeniors = seniors - numberOfFirefighters;

                                totalSeniors += seniors - unsavedSeniors;
                            }
                        }
                        else
                        {
                            int unsavedAdults = adults - numberOfFirefighters;

                            totalAdults += adults - unsavedAdults;
                        }
                    }
                    else
                    {
                        int unsavedKids = kids - numberOfFirefighters;

                        totalKids += kids - unsavedKids;
                    }                                        
                }

                kids = 0;
                adults = 0;
                seniors = 0;
                numberOfFirefighters = temporaryNumberOfFirefighters;
            }

            Console.WriteLine("Kids: {0}\nAdults: {1}\nSeniors: {2}", totalKids, totalAdults, totalSeniors);
        }
    }
}
