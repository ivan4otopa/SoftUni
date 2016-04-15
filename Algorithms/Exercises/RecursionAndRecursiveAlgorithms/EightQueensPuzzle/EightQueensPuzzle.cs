namespace EightQueensPuzzle
{
    using System;
    using System.Collections.Generic;

    class EightQueensPuzzle
    {
        const int Size = 8;
        const int NumberOfDiagonals = 15;

        static bool[,] chessBoard = new bool[Size, Size];
        static bool[] attackedColumns = new bool[Size];
        static bool[] attackedLeftDiagonals = new bool[NumberOfDiagonals];
        static bool[] attackedRightDiagonals = new bool[15];
        static int solutionsFound = 0;

        static void Main()
        {
            PutQueens(0);

            Console.WriteLine(solutionsFound);
        }

        static void PutQueens(int row)
        {
            if (row == Size)
            {
                PrintSolution();
            }
            else
            {
                for (int col = 0; col < Size; col++)
                {
                    if (CanPlaceQueen(row, col))
                    {
                        MarkAllAttackedPositions(row, col);
                        PutQueens(row + 1);
                        UnmarkAllAttackedPositions(row, col);
                    }
                }
            }
        }

        static bool CanPlaceQueen(int row, int col)
        {
            var positionOccupied =
                attackedColumns[col] == true ||
                attackedLeftDiagonals[row - col + 7] == true ||
                attackedRightDiagonals[row + col];

            return !positionOccupied;
        }

        static void MarkAllAttackedPositions(int row, int col)
        {
            attackedColumns[col] = true;
            attackedLeftDiagonals[row - col + 7] = true;
            attackedRightDiagonals[row + col] = true;

            chessBoard[row, col] = true;
        }

        static void UnmarkAllAttackedPositions(int row, int col)
        {
            attackedColumns[col] = false;
            attackedLeftDiagonals[row - col + 7] = false;
            attackedRightDiagonals[row + col] = false;

            chessBoard[row, col] = false;
        }

        static void PrintSolution()
        {
            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    if (chessBoard[row, col])
                    {
                        Console.Write('-');
                    }
                    else
                    {
                        Console.Write('*');
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            solutionsFound++;
        }
    }
}
