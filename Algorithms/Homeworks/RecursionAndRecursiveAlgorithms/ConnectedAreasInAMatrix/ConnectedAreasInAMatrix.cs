namespace ConnectedAreasInAMatrix
{
    using System;
    using System.Collections.Generic;

    class ConnectedAreasInAMatrix
    {
        //static char[,] matrix =
        //{
        //    { ' ', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ' },
        //    { ' ', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ' },
        //    { ' ', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ' },
        //    { ' ', ' ', ' ', ' ', '*', ' ', '*', ' ', ' ' }
        //};
        static char[,] matrix =
        {
            { '*', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ', ' ' },
            { '*', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ', ' ' },
            { '*', ' ', ' ', '*', '*', '*', '*', '*', ' ', ' ' },
            { '*', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ', ' ' },
            { '*', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ', ' ' }
        };
        static SortedSet<ConnectedArea> areas = new SortedSet<ConnectedArea>();
        static ConnectedArea currentArea;

        static void Main()
        {
            FindAreas();

            Console.WriteLine($"Total areas found: {areas.Count}");

            int counter = 0;

            foreach (var area in areas)
            {
                Console.WriteLine(
                    $"Area #{++counter} at ({area.X}, {area.Y}), size: {area.Size}");
            }
        }

        static void FindAreas()
        {
            FindTraversableCell();

            if (!FindTraversableCell())
            {
                return;
            }

            FindArea(currentArea.X, currentArea.Y);

            areas.Add(currentArea);

            FindAreas();
        }

        static void FindArea(int row, int col)
        {
            if (row < 0 || row >= matrix.GetLength(0) || col < 0 ||
                col >= matrix.GetLength(1))
            {
                return;
            }

            if (matrix[row, col] != ' ')
            {
                return;
            }

            matrix[row, col] = '.';
            currentArea.Size++;

            FindArea(row - 1, col);
            FindArea(row, col + 1);
            FindArea(row + 1, col);
            FindArea(row, col - 1);
        }

        static bool FindTraversableCell()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == ' ')
                    {
                        currentArea = new ConnectedArea()
                        {
                            X = i,
                            Y = j,
                        };

                        return true;
                    }
                }
            }

            return false;
        }
    }
}
