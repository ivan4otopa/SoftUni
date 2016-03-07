namespace RideTheHorse
{
    using System;
    using System.Collections.Generic;

    class RideTheHorse
    {
        private static List<Cell> visited = new List<Cell>();
        private static int[,] matrix;
        private static int matrixRows = 0;
        private static int matrixColumns = 0;

        static void Main()
        {
            matrixRows = int.Parse(Console.ReadLine());
            matrixColumns = int.Parse(Console.ReadLine());
            matrix = new int[matrixRows, matrixColumns];

            int startPositonRow = int.Parse(Console.ReadLine());
            int startPositionColumn = int.Parse(Console.ReadLine());
            var startCell = new Cell()
            {
                X = startPositonRow,
                Y = startPositionColumn,
                Value = 1
            };
            var queue = new Queue<Cell>();

            queue.Enqueue(startCell);

            while (queue.Count > 0)
            {
                var cell = queue.Dequeue();
                 
                visited.Add(cell);
                matrix[cell.X, cell.Y] = cell.Value;

                if (IsFreeCell(cell.X - 2, cell.Y + 1))
                {
                    queue.Enqueue(new Cell() { X = cell.X - 2, Y = cell.Y + 1, Value = cell.Value + 1 });
                    matrix[cell.X - 2, cell.Y + 1] = cell.Value + 1;
                }

                if (IsFreeCell(cell.X - 1, cell.Y + 2))
                {
                    queue.Enqueue(new Cell() { X = cell.X - 1, Y = cell.Y + 2, Value = cell.Value + 1 });
                    matrix[cell.X - 1, cell.Y + 2] = cell.Value + 1;
                }

                if (IsFreeCell(cell.X + 1, cell.Y + 2))
                {
                    queue.Enqueue(new Cell() { X = cell.X + 1, Y = cell.Y + 2, Value = cell.Value + 1 });
                    matrix[cell.X + 1, cell.Y + 2] = cell.Value + 1;
                }

                if (IsFreeCell(cell.X + 2, cell.Y + 1))
                {
                    queue.Enqueue(new Cell() { X = cell.X + 2, Y = cell.Y + 1, Value = cell.Value + 1 });
                    matrix[cell.X + 2, cell.Y + 1] = cell.Value + 1;
                }

                if (IsFreeCell(cell.X + 2, cell.Y - 1))
                {
                    queue.Enqueue(new Cell() { X = cell.X + 2, Y = cell.Y - 1, Value = cell.Value + 1 });
                    matrix[cell.X + 2, cell.Y - 1] = cell.Value + 1;
                }

                if (IsFreeCell(cell.X + 1, cell.Y - 2))
                {
                    queue.Enqueue(new Cell() { X = cell.X + 1, Y = cell.Y - 2, Value = cell.Value + 1 });
                    matrix[cell.X + 1, cell.Y - 2] = cell.Value + 1;
                }

                if (IsFreeCell(cell.X - 1, cell.Y - 2))
                {
                    queue.Enqueue(new Cell() { X = cell.X - 1, Y = cell.Y - 2, Value = cell.Value + 1 });
                    matrix[cell.X - 1, cell.Y - 2] = cell.Value + 1;
                }

                if (IsFreeCell(cell.X - 2, cell.Y - 1))
                {
                    queue.Enqueue(new Cell() { X = cell.X - 2, Y = cell.Y - 1, Value = cell.Value + 1 });
                    matrix[cell.X - 2, cell.Y - 1] = cell.Value + 1;
                }
            }

            int middleColumn = matrixColumns / 2;

            for (int i = 0; i < matrixRows; i++)
            {
                Console.WriteLine(matrix[i, middleColumn]);
            }
        }

        static bool IsFreeCell(int x, int y)
        {
            if (x >= 0 && x <= matrixRows - 1 && y >= 0 && y <= matrixColumns - 1 &&
                matrix[x, y] == 0)
            {
                return true;
            }

            return false;
        }
    }
}
