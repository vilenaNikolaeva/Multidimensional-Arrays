using System;
using System.Collections.Generic;
using System.Linq;

namespace Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            var coordinates = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var snake = Console.ReadLine();
            var rows = coordinates[0];
            var cols = coordinates[1];
            string[,] matrix = new string[rows, cols];
            var capacity = rows * cols;
            Queue<string> snakesQueue = new Queue<string>();

            for (int i = 0; i < capacity; i++)
            {
                for (int j = 0; j < snake.Length; j++)
                {
                    snakesQueue.Enqueue(snake[j].ToString());
                }
            }

            for (int row = 0; row < rows; row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        matrix[row, col] = snakesQueue.Dequeue();
                    }
                }
                else
                {
                    for (int col = cols - 1; col > -1; col--)
                    {
                        matrix[row, col] = snakesQueue.Dequeue();
                    }
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
