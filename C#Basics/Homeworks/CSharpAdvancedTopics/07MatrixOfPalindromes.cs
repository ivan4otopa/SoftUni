using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07MatrixOfPalindromes
{
    class MatrixOfPalindromes
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter rows and columns: ");
            Console.Write("Rows: ");
            int r = int.Parse(Console.ReadLine());
            Console.Write("Columns: ");
            int c = int.Parse(Console.ReadLine());
            string[,] palindrom = new string[r, c];
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    palindrom[i, j] = "" + (char)('a' + i) + (char)('a' + i + j) + (char)('a' + i);
                }
            }
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                    Console.Write(palindrom[i, j] + " ");
                Console.WriteLine();
            }
        }
    }
}
