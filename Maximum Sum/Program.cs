using System;
using System.Linq;

namespace Maximum_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var rows = n[0];
            var cols = n[1];
            int[,] matrix = ReadMatrix(rows, cols);

            var maxSum = 0;
            var bestRowIndex = 0;
            var bestColIndex = 0;


            for (int row = 0; row <= rows - 3; row++)
            {
                for (int col = 0; col <= cols - 3; col++)
                {

                    int rowOneSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2];
                    int rowSecondSum = matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2];
                    int rowTirdSum = matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
                    int currentSum = rowOneSum + rowSecondSum + rowTirdSum;
                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        bestRowIndex = row;
                        bestColIndex = col;
                    }
                }
            }
            Console.WriteLine($"Sum = {maxSum}");
            for (int i = bestRowIndex; i <= bestRowIndex + 2; i++)
            {
                for (int j = bestColIndex; j <= bestColIndex + 2; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        private static int[,] ReadMatrix(in int rows, in int cols)
        {
            int[,] matrixx = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] rowValues = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
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
