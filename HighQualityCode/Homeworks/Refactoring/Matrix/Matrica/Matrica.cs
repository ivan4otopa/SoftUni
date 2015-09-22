namespace Matrix
{
    using System;

    public class WalkInMatrix
    {
        private const int NumberOfPossibleDirections = 8;

        static void changeDirection(ref int horizontalDirection, ref int verticalDirection)
        {
            int[] horizontalDirections = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] diagonalDirections = { 1, 0, -1, -1, -1, 0, 1, 1 };
            int changeDirectionTimesCount = 0;

            for (int directionsCount = 0; directionsCount < NumberOfPossibleDirections; directionsCount++)
            {
                if (horizontalDirections[directionsCount] == horizontalDirection &&
                    diagonalDirections[directionsCount] == verticalDirection)
                {
                    changeDirectionTimesCount = directionsCount;
                    break;
                }
            }
            
            if (changeDirectionTimesCount == 7) 
            {
                horizontalDirection = horizontalDirections[0];
                verticalDirection = diagonalDirections[0]; 
                
                return;
            }
            
            horizontalDirection = horizontalDirections[changeDirectionTimesCount + 1];
            verticalDirection = diagonalDirections[changeDirectionTimesCount + 1];
        }

        static bool CheckNextCell(int[,] matrix, int x, int y)
        {
            int[] horizontalDirections = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] diagonalDirections = { 1, 0, -1, -1, -1, 0, 1, 1 };
          
            for (int i = 0; i < NumberOfPossibleDirections; i++)
            {
                if (x + horizontalDirections[i] >= matrix.GetLength(0) || x + horizontalDirections[i] < 0)
                {
                    horizontalDirections[i] = 0;
                }

                if (y + diagonalDirections[i] >= matrix.GetLength(0) || y + diagonalDirections[i] < 0)
                {
                    diagonalDirections[i] = 0;
                }
            }
            
            for (int i = 0; i < NumberOfPossibleDirections; i++)
            {
                if (matrix[x + horizontalDirections[i], y + diagonalDirections[i]] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public static void FindNextCell(int[,] matrix, out int x, out int y)
        {
            x = 0;
            y = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        x = i;
                        y = j;

                        return;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter a positive number ");
            string input = Console.ReadLine();
            int n = 0;

            while (!int.TryParse(input, out n) || n < 0 || n > 100)
            {
                Console.WriteLine("You haven't entered a correct positive number");
                input = Console.ReadLine();
            }

            int[,] matrix = new int[n, n];
            int row = 0;
            int col = 0;
            int matrixSquare = 1;
            int horizontalDirection = 1;
            int diagonalDirection = 1;

            SetupMatrix(matrix, row, col, matrixSquare, horizontalDirection, diagonalDirection, n);

            FindNextCell(matrix, out row, out col);
            
            if (row != 0 && col != 0)
            {
                horizontalDirection = 1;
                diagonalDirection = 1;
                
                SetupMatrix(matrix, row, col, matrixSquare, horizontalDirection, diagonalDirection, n);
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("{0,3}", matrix[i, j]);
                }

                Console.WriteLine();
            }
        }

        public static void SetupMatrix(int[,] matrix, int row, int col, int matrixSquare, int horizontalDirection,
            int diagonalDirection, int n)
        {
            while (true)
            {
                matrix[row, col] = matrixSquare;

                if (!CheckNextCell(matrix, row, col))
                {
                    break;
                }
                if (row + horizontalDirection >= n || row + horizontalDirection < 0 || col + diagonalDirection >= n ||
                    col + diagonalDirection < 0 || matrix[row + horizontalDirection, col + diagonalDirection] != 0)
                {
                    while ((row + horizontalDirection >= n || row + horizontalDirection < 0 || col + diagonalDirection >= n ||
                        col + diagonalDirection < 0 || matrix[row + horizontalDirection, col + diagonalDirection] != 0))
                    {
                        changeDirection(ref horizontalDirection, ref diagonalDirection);
                    }
                }

                row += horizontalDirection;
                col += diagonalDirection;
                matrixSquare++;
            }
        }
    }
}
