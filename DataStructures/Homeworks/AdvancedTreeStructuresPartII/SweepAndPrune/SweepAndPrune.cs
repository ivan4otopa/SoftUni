namespace SweepAndPrune
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class SweepAndPrune
    {
        private static List<GameObject> objects = new List<GameObject>();

        static void Main()
        {
            int tickCount = 0;
            string command = Console.ReadLine();
            int x = 0;
            int y = 0;
            string name = string.Empty;

            while (command.StartsWith("add"))
            {
                string[] tokens = command.Split(' ');

                name = tokens[1].Trim();
                x = int.Parse(tokens[2].Trim());
                y = int.Parse(tokens[3].Trim());
                objects.Add(new GameObject(name, x, y));
                command = Console.ReadLine();
            }

            if (command == "start")
            {
                command = Console.ReadLine();

                while (true)
                {
                    if (String.IsNullOrEmpty(command))
                    {
                        break;
                    }

                    if (command.StartsWith("t"))
                    {
                        tickCount++;

                        CheckCollisions(tickCount);
                    }
                    else
                    {
                        string[] tokens = command.Split(' ');

                        name = tokens[1].Trim();
                        x = int.Parse(tokens[2].Trim());
                        y = int.Parse(tokens[3].Trim());

                        var obj = objects
                            .FirstOrDefault(go => go.Name == name);

                        if (obj != null)
                        {
                            obj.X1 = x;
                            obj.Y1 = y;
                        }

                        tickCount++;

                        CheckCollisions(tickCount);                        
                    }

                    command = Console.ReadLine();
                }
            }
        }

        private static void CheckCollisions(int tickCount)
        {
            InsertionSort();

            for (int i = 0; i < objects.Count; i++)
            {
                var currentObj = objects[i];

                for (int j = i + 1; j < objects.Count; j++)
                {
                    var candidateCollisionObj = objects[j];

                    if (currentObj.X2 < candidateCollisionObj.X1)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine(
                            "({0}) {1} collides {2}",
                            tickCount,
                            currentObj.Name,
                            candidateCollisionObj.Name);
                    }
                }
            }
        }

        private static void InsertionSort()
        {
            for (int i = 0; i < objects.Count - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (objects[j - 1].X1 > objects[j].X1)
                    {
                        var temp = objects[j - 1];

                        objects[j - 1] = objects[j];
                        objects[j] = temp;
                    }
                }
            }
        }
    }
}
