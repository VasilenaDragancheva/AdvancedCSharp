using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static List<List<int>> matrix = new List<List<int>>();

    public static void Main()
    {
        var dimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        int value = 1;
        for (int i = 0; i < dimensions[0]; i++)
        {
            matrix.Add(new List<int>());
            for (int j = 0; j < dimensions[1]; j++)
            {
                matrix[i].Add(value);
                value++;
            }
        }

        while (true)
        {
            string line = Console.ReadLine();
            if (line.ToLower() == "Nuke it from orbit".ToLower())
            {
                break;
            }

            long[] size = line.Split(' ').Select(long.Parse).ToArray();
            long row = size[0];
            long col = size[1];
            long rad = size[2];
            Destroy(row, col, rad);
        }

        for (int i = 0; i < matrix.Count; i++)
        {
            Console.WriteLine(string.Join(" ", matrix[i]));
        }
    }

    private static void Destroy(long row, long col, long rad)
    {
        long startRow = row - rad;
        long endRow = row + rad;
        long startCol = col - rad;
        long endCol = col + rad;

        if (startRow < matrix.Count && endRow >= 0)
        {
            int start = startRow < 0 ? 0 : (int)startRow;
            int end = endRow < matrix.Count ? (int)endRow : matrix.Count - 1;
            for (int i = start; i <= end; i++)
            {
                if (i == row)
                {
                    continue;
                }

                if (matrix[i].Count > col && col >= 0)
                {
                    matrix[i].RemoveAt((int)col);
                }
            }
        }

        if (row >= 0 && row < matrix.Count)
        {
            if (startCol < matrix[(int)row].Count && endCol >= 0)
            {
                int startCols = startCol < 0 ? 0 : (int)startCol;
                int endCols = endCol < matrix[(int)row].Count ? (int)endCol : matrix[(int)row].Count - 1;
                int count = endCols - startCols + 1;
                matrix[(int)row].RemoveRange(startCols, count);
            }
        }

        matrix.RemoveAll(m => m.Count == 0);
    }
}