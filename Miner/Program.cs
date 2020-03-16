using System;
using System.Collections.Generic;
using System.Linq;

namespace Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            var num = int.Parse(Console.ReadLine());
            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            var matrix = new char[num, num];
            var rowS = 0;
            var colS = 0;

            Dictionary<int, List<int>> coaldIndexs = new Dictionary<int, List<int>>();

            for (int row = 0; row < num; row++)
            {
                var cellValue = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                for (int col = 0; col < num; col++)
                {
                    matrix[row, col] = char.Parse(cellValue[col]);
                    if (matrix[row, col] == 's')
                    {
                        rowS = row;
                        colS = col;
                    }
                }
            }
            GetCoalLocation(coaldIndexs, matrix);
            Dictionary<int, int> endLocation = GetEndIndex(matrix);

            for (int i = 0; i < input.Length; i++)
            {
                var command = input[i];
                switch (command)
                {
                    case "up":
                        if (CellInMatrix(matrix, rowS - 1, colS))
                        {
                            rowS--;
                        }
                        break;
                    case "down":
                        if (CellInMatrix(matrix, rowS + 1, colS))
                        {
                            rowS++;
                        }
                        break;
                    case "right":
                        if (CellInMatrix(matrix, rowS, colS + 1))
                        {
                            colS++;
                        }
                        break;
                    case "left":
                        if (CellInMatrix(matrix, rowS, colS - 1))
                        {
                            colS--;
                        }
                        break;
                }
                if (endLocation.ContainsKey(rowS) && endLocation.ContainsValue(colS))
                {
                    Console.WriteLine($"Game Over! {string.Join("", endLocation.Keys)}, {string.Join("", endLocation.Values)}");
                    return;
                }
                if (coaldIndexs.ContainsKey(rowS) && coaldIndexs[rowS].Contains(colS))
                {
                    coaldIndexs.Remove(colS);
                    if (coaldIndexs.Count == 0)
                    {
                        Console.WriteLine($"You collected all coals! ({rowS}, {colS})");
                        return;
                    }
                    if (coaldIndexs[rowS].Count == 0)
                    {
                        coaldIndexs.Remove(rowS);
                    }
                }
            }
            Console.WriteLine($"{coaldIndexs.Count} coals left. ({rowS}, {colS})");

        }

        private static Dictionary<int, int> GetEndIndex(char[,] matrix)
        {
            Dictionary<int, int> endIndex = new Dictionary<int, int>();
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'e')
                    {
                        endIndex.Add(row, col);
                    }
                }
            }
            return endIndex;
        }

        static bool CellInMatrix(char[,] matrix, int row, int col)
        {

            if (row >= 0 && row <= matrix.GetLength(0) - 1
                && col >= 0 && col <= matrix.GetLength(1) - 1)
            {
                return true;
            }
            return false;
        }
        private static Dictionary<int, List<int>> GetCoalLocation(Dictionary<int, List<int>> coaldIndexs, char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'c')
                    {
                        if (!coaldIndexs.ContainsKey(row))
                        {
                            coaldIndexs[row] = new List<int>();
                        }
                        coaldIndexs[row].Add(col);
                    }
                }
            }
            return coaldIndexs;
        }
    }
}
