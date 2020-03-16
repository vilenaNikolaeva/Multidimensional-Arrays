using System;
using System.Linq;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrixSize = int.Parse(Console.ReadLine());
            var matrix = new int[matrixSize, matrixSize];
            var count = 0;
            var sum = 0;

            for (int row = 0; row < matrixSize; row++)
            {
                int[] input = Console.ReadLine().Split(" ").Select(int.Parse)
                .ToArray();
                for (int col = 0; col < input.Length; col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            var bombCoordinat = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            for (int i = 0; i < bombCoordinat.Length; i++)
            {
                var splitedCoordinates = bombCoordinat[i].Split(",");
                var row = int.Parse(splitedCoordinates[0]);
                var col = int.Parse(splitedCoordinates[1]);
                ReadForTheBomb(row, col, matrix);
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        count++;
                        sum += matrix[i, j];
                    }
                }
            }

            Console.WriteLine($"Alive cells: {count}");
            Console.WriteLine($"Sum: {sum}");

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    Console.Write(matrix[rows, cols] + " ");
                }
                Console.WriteLine();
            }
        }

        static void ReadForTheBomb(int bombRow, int bombCol, int[,] matrix)
        {
            var row = bombRow;
            var col = bombCol;

            var bombValue = matrix[bombRow, bombCol];

            if (bombValue > 0)
            {
                if (CellInMatrix(row - 1, col - 1, matrix) && matrix[row - 1, col - 1] > 0)
                {
                    matrix[row - 1, col - 1] -= bombValue;
                }
                if (CellInMatrix(row - 1, col, matrix) && matrix[row - 1, col] > 0)
                {
                    matrix[row - 1, col] -= bombValue;
                }
                if (CellInMatrix(row - 1, col + 1, matrix) && matrix[row - 1, col + 1] > 0)
                {
                    matrix[row - 1, col + 1] -= bombValue;
                }
                if (CellInMatrix(row, col - 1, matrix) && matrix[row, col - 1] > 0)
                {
                    matrix[row, col - 1] -= bombValue;
                }
                if (CellInMatrix(row, col, matrix) && matrix[row, col] > 0)
                {
                    matrix[row, col] -= bombValue;
                }
                if (CellInMatrix(row, col + 1, matrix) && matrix[row, col + 1] > 0)
                {
                    matrix[row, col + 1] -= bombValue;
                }
                if (CellInMatrix(row + 1, col - 1, matrix) && matrix[row + 1, col - 1] > 0)
                {
                    matrix[row + 1, col - 1] -= bombValue;
                }
                if (CellInMatrix(row + 1, col, matrix) && matrix[row + 1, col] > 0)
                {
                    matrix[row + 1, col] -= bombValue;
                }
                if (CellInMatrix(row + 1, col + 1, matrix) && matrix[row + 1, col + 1] > 0)
                {
                    matrix[row + 1, col + 1] -= bombValue;
                }

            }
        }
        static bool CellInMatrix(int row, int col, int[,] matrix)
        {

            if (row >= 0 && row <= matrix.GetLength(0) - 1
                && col >= 0 && col <= matrix.GetLength(1) - 1)
            {
                return true;
            }
            return false;
        }
    }
}
