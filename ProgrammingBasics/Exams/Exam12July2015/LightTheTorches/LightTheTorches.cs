namespace LightTheTorches
{
    using System;

    class LightTheTorches
    {
        static void Main()
        {
            int totalRooms = int.Parse(Console.ReadLine());
            string lightDarkSeries = Console.ReadLine();
            string command = "";
            bool[] lightDarkRooms = new bool[totalRooms];
            int spareConditions = 0;
            string partToAdd = "";

            while (lightDarkSeries.Length < totalRooms)
            {
                spareConditions = totalRooms - lightDarkSeries.Length;

                if (spareConditions > lightDarkSeries.Length)
                {
                    spareConditions = lightDarkSeries.Length;
                }

                partToAdd = lightDarkSeries.Substring(0, spareConditions);

                lightDarkSeries += partToAdd;
            }

            for (int i = 0; i < lightDarkRooms.Length; i++)
            {
                if (lightDarkSeries[i] == 'L')
                {
                    lightDarkRooms[i] = true;
                }
                else
                {
                    lightDarkRooms[i] = false;
                }
            }

            int priestPosition = totalRooms / 2;
            string direction = "";
            int rooms = 0;
            bool hasChangedPosition = true;

            while (true)
            {
                command = Console.ReadLine();

                if (command == "END")
                {
                    break;
                }

                direction = command.Split(' ')[0];
                rooms = int.Parse(command.Split(' ')[1]);

                if (direction == "LEFT" || direction == "RIGHT")
                {
                    if (direction == "LEFT" && rooms >= priestPosition)
                    {
                        if (priestPosition == 0)
                        {
                            hasChangedPosition = false;
                        }

                        priestPosition = 0;
                    }
                    else if (direction == "RIGHT" && rooms >= totalRooms - priestPosition - 1)
                    {
                        if (priestPosition == totalRooms - 1)
                        {
                            hasChangedPosition = false;
                        }

                        priestPosition = totalRooms - 1;
                    }
                    else if (direction == "LEFT")
                    {
                        priestPosition -= rooms + 1;
                    }
                    else if (direction == "RIGHT")
                    {
                        priestPosition += rooms + 1;
                    }

                    if (hasChangedPosition)
                    {
                        if (lightDarkRooms[priestPosition])
                        {
                            lightDarkRooms[priestPosition] = false;
                        }
                        else
                        {
                            lightDarkRooms[priestPosition] = true;
                        }
                    }

                    hasChangedPosition = true;
                }
            }

            int darkRoomsCount = 0;

            foreach (var lightDarkRoom in lightDarkRooms)
            {
                if (lightDarkRoom == false)
                {
                    darkRoomsCount++;
                }
            }

            Console.WriteLine((int)'D' * darkRoomsCount);
        }
    }
}
