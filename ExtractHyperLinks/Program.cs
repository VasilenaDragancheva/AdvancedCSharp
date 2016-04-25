namespace ExtractHyperLinks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[][] matrix = new char[n][];
            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                matrix[i] = line.ToCharArray();
            }

            string command;
            while (true)
            {
                command = Console.ReadLine();
                if (command.ToLower() == "end")
                {
                    break;
                }

                int[] info =
                    command.Split(new[] { ' ', ')', '(' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();
                int row = info[0];
                int col = info[1];
                int radius = info[2];
                int rotation = info[3];
                List<int[]> coordinatesToBeRotated = new List<int[]>();
                List<char> charsToBeRotated = new List<char>();
                for (int r = row - radius; r <= row + radius; r++)
                {
                    if (r == row - radius)
                    {
                        for (int c = col - radius; c <= col + radius; c++)
                        {
                            if (r >= 0 && r < n && c >= 0 && c < matrix[r].Length)
                            {
                                coordinatesToBeRotated.Add(new[] { r, c });
                                charsToBeRotated.Add(matrix[r][c]);
                            }
                        }
                    }
                    else if (r < radius + row)
                    {
                        int c = col + radius;
                        if (r >= 0 && r < n && c >= 0 && c < matrix[r].Length)
                        {
                            coordinatesToBeRotated.Add(new[] { r, c });
                            charsToBeRotated.Add(matrix[r][c]);
                        }
                    }
                    else if (r == row + radius)
                    {
                        for (int c = col + radius; c >= col - radius; c--)
                        {
                            if (r >= 0 && r < n && c >= 0 && c < matrix[r].Length)
                            {
                                coordinatesToBeRotated.Add(new[] { r, c });
                                charsToBeRotated.Add(matrix[r][c]);
                            }
                        }
                    }
                }

                for (int r = row + radius - 1; r >= row - radius + 1; r--)
                {
                    int c = col - radius;
                    if (r >= 0 && r < n && c >= 0 && c < matrix[r].Length)
                    {
                        coordinatesToBeRotated.Add(new[] { r, c });
                        charsToBeRotated.Add(matrix[r][c]);
                    }
                }

                List<char> charsAfterRotation = new List<char>();

                if (rotation > 0)
                {
                    int rotatedNumbers = rotation % coordinatesToBeRotated.Count;
                    int leftNumbers = coordinatesToBeRotated.Count - rotatedNumbers;
                    charsAfterRotation = charsToBeRotated.Skip(leftNumbers).Take(rotatedNumbers).ToList();
                    charsAfterRotation.AddRange(charsToBeRotated.Take(leftNumbers));
                    for (int i = 0; i < coordinatesToBeRotated.Count; i++)
                    {
                        int rrrr = coordinatesToBeRotated[i][0];
                        int cccc = coordinatesToBeRotated[i][0];
                        matrix[rrrr][cccc] = charsAfterRotation[i];
                    }

                    foreach (char[] chr in matrix)
                    {
                        Console.WriteLine(chr);
                    }
                }
            }
        }
    }
}