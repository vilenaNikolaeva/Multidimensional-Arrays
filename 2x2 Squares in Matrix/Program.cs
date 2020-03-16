using System;
using System.Linq;

namespace _2x2_Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var rowAndCol = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            var rows = rowAndCol[0];
            var cols = rowAndCol[1];
            char[,] matrix = ReadMatrix(rows, cols);

            var counter = 0;
            for (int row = 0; row <= rows - 2; row++)
            {
                for (int col = 0; col <= cols - 2; col++)
                {
                    if (matrix[row, col] == matrix[row, col + 1]
                        && matrix[row, col] == matrix[row + 1, col]
                        && matrix[row, col] == matrix[row + 1, col + 1])
                    {
                        counter++;
                    }
                }
            }
            Console.WriteLine(counter);
        }


        private static char[,] ReadMatrix(in int rows, in int cols)
        {
            char[,] matrixx = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                char[] rowValues = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrixx[row, col] = rowValues[col];
                }
            }
            return matrixx;
        }

    }
}
