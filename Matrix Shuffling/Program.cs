using System;
using System.Linq;

namespace Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            var cordinates = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            var rows = cordinates[0];
            var cols = cordinates[1];

            string[,] matrix = ReadStringMatrix(rows, cols);

            var input = Console.ReadLine();
            while (input != "END")
            {
                var splitedInput = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var command = splitedInput[0];
                if (command != "swap" && input.Length != 5)
                {
                    Console.WriteLine("Invalid input!");
                    input = Console.ReadLine();
                    continue;
                }

                var rowOne = int.Parse(splitedInput[1]);
                var colOne = int.Parse(splitedInput[2]);
                var rowTwo = int.Parse(splitedInput[3]);
                var ColTwo = int.Parse(splitedInput[4]);
                bool isValidFirstCell = IsValidCell(matrix, rowOne, colOne);
                bool isValidSecondCell = IsValidCell(matrix, rowTwo, ColTwo);

                if (isValidFirstCell && isValidSecondCell)
                {
                    var temp = matrix[rowOne, colOne];
                    matrix[rowOne, colOne] = matrix[rowTwo, ColTwo];
                    matrix[rowTwo, ColTwo] = temp;
                    PrintMatrix(matrix);
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
                input = Console.ReadLine();
            }
        }
        static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        static bool IsValidCell(string[,] matrix, int row, int col)
        {
            bool isValid = false;
            if (row >= 0 && row < matrix.GetLength(0)
               && col >= 0 && col < matrix.GetLength(1))
            {
                isValid = true;
            }
            return isValid;
        }

        static string[,] ReadStringMatrix(int rows, int cols)
        {
            string[,] matrix = new string[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                string[] rowValue = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowValue[col];
                }
            }
            return matrix;
        }
    }
}
