namespace PathsBetweenCellsInMatrix
{
    using System;
    using System.Collections.Generic;

    class PathsBetweenCellsInMatrix
    {
        //static char[,] matrix =
        //{
        //    { 's', ' ', ' ', ' ' },
        //    { ' ', '*', '*', ' ' },
        //    { ' ', '*', '*', ' ' },
        //    { ' ', '*', 'e', ' ' },
        //    { ' ', ' ', ' ', ' ' }
        //};
        static char[,] matrix =
        {
            { ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', '*', '*', ' ', '*', ' ' },
            { ' ', '*', '*', ' ', '*', ' ' },
            { ' ', '*', 'e', ' ', ' ', ' ' },
            { ' ', ' ', ' ', '*', ' ', ' ' }
        };
        static int pathsFound = 0;
        static List<char> path = new List<char>();

        static void Main()
        {
            FindPaths(0, 0);

            Console.WriteLine($"Total paths found: {pathsFound}");
        }

        static void FindPaths(int row, int col)
        {
            if (row < 0 || row >= matrix.GetLength(0) || col < 0 ||
                col >= matrix.GetLength(1))
            {
                return;
            }

            if (matrix[row, col] == 'e')
            {
                pathsFound++;

                Console.WriteLine(string.Join("", path));

                return;
            }

            if (matrix[row, col] != ' ' && matrix[row, col] != 's')
            {
                return;
            }

            matrix[row, col] = '.';
            path.Add('U');

            FindPaths(row - 1, col);

            path.RemoveAt(path.Count - 1);
            path.Add('R');

            FindPaths(row, col + 1);

            path.RemoveAt(path.Count - 1);
            path.Add('D');

            FindPaths(row + 1, col);

            path.RemoveAt(path.Count - 1);
            path.Add('L');

            FindPaths(row, col - 1);

            path.RemoveAt(path.Count - 1);
            matrix[row, col] = ' ';
        }
    }
}
