using System;
using System.Linq;

namespace Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrixRows = int.Parse(Console.ReadLine());
            int[][] matrix = new int[matrixRows][];

            for (int row = 0; row < matrix.Length; row++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                matrix[row] = new int[input.Length];

                for (int col = 0; col < input.Length; col++)
                {
                    matrix[row][col] = input[col];
                }
            }
            for (int row = 0; row < matrixRows - 1; row++)
            {
                if (matrix[row].Length == matrix[row + 1].Length)
                {
                    for (int i = row; i <= row + 1; i++)
                    {
                        for (int col = 0; col < matrix[i].Length; col++)
                        {
                            matrix[i][col] = matrix[i][col] * 2;
                        }
                    }
                }
                else
                {
                    for (int i = row; i <= row + 1; i++)
                    {
                        for (int col = 0; col < matrix[i].Length; col++)
                        {
                            matrix[i][col] = matrix[i][col] / 2;
                        }
                    }
                }
            }
            var commandInput = string.Empty;
            while (commandInput != "End")
            {
                commandInput = Console.ReadLine();
                if (commandInput == "End")
                {
                    break;
                }
                var splitedInput = commandInput.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var command = splitedInput[0];

                if (command == "Add")
                {
                    var currentRow = int.Parse(splitedInput[1]);
                    var currentCol = int.Parse(splitedInput[2]);
                    var value = int.Parse(splitedInput[3]);
                    if (currentRow <= matrixRows)
                    {
                        if (matrix[currentRow].Length <= currentCol)
                        {
                            matrix[currentRow][currentCol] = matrix[currentRow][currentCol] + value;
                        }

                    }

                }
                else if (command == "Subtract")
                {
                    var currentRow = int.Parse(splitedInput[1]);
                    var currentCol = int.Parse(splitedInput[2]);
                    var value = int.Parse(splitedInput[3]);
                    if (currentRow <= matrixRows)
                    {
                        if (matrix[currentRow].Length <= currentCol)
                        {
                            matrix[currentRow][currentCol] = matrix[currentRow][currentCol] - value;
                        }
                    }
                }
            }

            for (int row = 0; row < matrixRows; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
