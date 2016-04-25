namespace FireTheArrows
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            char[] arrows = { '>', '<', 'v', '^' };
            int n = int.Parse(Console.ReadLine());
            char[][] matrix = new char[n][];
            for (int i = 0; i < n; i++)
            {
                matrix[i] = Console.ReadLine().ToCharArray();
            }

            bool possibleMoves = true;
            do
            {
                List<int[]> newPositionMovedArrows = new List<int[]>();
                for (int r = 0; r < n; r++)
                {
                    for (int c = 0; c < matrix[r].Length; c++)
                    {
                        char symbol = matrix[r][c];
                        if (arrows.Contains(symbol) && !newPositionMovedArrows.Contains(new[] { r, c }))
                        {
                            switch (symbol)
                            {
                                case '<':
                                    if (c - 1 >= 0 && matrix[r][c - 1] == 'o')
                                    {
                                        matrix[r][c - 1] = symbol;
                                        matrix[r][c] = 'o';
                                        newPositionMovedArrows.Add(new[] { r, c - 1 });
                                    }

                                    break;
                                case '>':
                                    if (c + 1 < matrix[r].Length && matrix[r][c + 1] == 'o')
                                    {
                                        matrix[r][c + 1] = symbol;
                                        matrix[r][c] = 'o';
                                        newPositionMovedArrows.Add(new[] { r, c + 1 });
                                    }

                                    break;
                                case 'v':
                                    if (r + 1 < n && matrix[r + 1][c] == 'o')
                                    {
                                        matrix[r + 1][c] = symbol;
                                        matrix[r][c] = 'o';
                                        newPositionMovedArrows.Add(new[] { r + 1, c });
                                    }

                                    break;
                                case '^':
                                    if (r - 1 >= 0 && matrix[r - 1][c] == 'o')
                                    {
                                        matrix[r - 1][c] = symbol;
                                        matrix[r][c] = 'o';
                                        newPositionMovedArrows.Add(new[] { r - 1, c });
                                    }

                                    break;
                            }
                        }
                    }
                }

                if (newPositionMovedArrows.Count == 0)
                {
                    break;
                }
            }
            while (true);

            foreach (char[] line in matrix)
            {
                Console.WriteLine(line);
            }
        }
    }
}