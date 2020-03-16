using System;
using System.Linq;

namespace Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

            for (int row = 0; row < n; row++)
            {
                var currentLine = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currentLine[col];
                }
            }

            var diagonalOne = 0;
            for (int row = 0; row < n; row++)
            {
                diagonalOne += matrix[row, row];
            }

            int diagonalTwo = 0;
            for (int i = n - 1; i >= 0; i--)
            {
                int row = n - i - 1;
                int col = i;
                diagonalTwo += matrix[row, col];
            }
            var sum = Math.Abs(diagonalOne - diagonalTwo);
            Console.WriteLine(sum);

        }
    }
}
