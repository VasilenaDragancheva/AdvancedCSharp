namespace TargetPractice
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            string dimensions = Console.ReadLine();
            string snake = Console.ReadLine();
            int[] shot = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int rows = int.Parse(dimensions.Split(' ')[0]);
            int cols = int.Parse(dimensions.Split(' ')[1]);
            char[,] stairs = new char[rows, cols];
            int rowsIndexer = 0;
            int snakeIndexer = 0;
            for (int r = rows - 1; r >= 0; r--)
            {
                if (rowsIndexer % 2 == 0)
                {
                    for (int c = cols - 1; c >= 0; c--)
                    {
                        stairs[r, c] = snake[snakeIndexer];
                        snakeIndexer++;
                        if (snakeIndexer == snake.Length)
                        {
                            snakeIndexer = 0;
                        }
                    }
                }
                else
                {
                    for (int c = 0; c < cols; c++)
                    {
                        stairs[r, c] = snake[snakeIndexer];
                        snakeIndexer++;
                        if (snakeIndexer == snake.Length)
                        {
                            snakeIndexer = 0;
                        }
                    }
                }

                rowsIndexer++;
            }

            Shooting(shot, stairs, rows, cols);
            ClearingStairs(stairs, rows);

            for (int r = 0; r < stairs.GetLength(0); r++)
            {
                for (int c = 0; c < stairs.GetLength(1); c++)
                {
                    Console.Write(stairs[r, c]);
                }

                Console.WriteLine();
            }
        }

        private static void Shooting(int[] bomb, char[,] stairs, int rows, int cols)
        {
            int radius = bomb[2];
            for (int r = 0; r < stairs.GetLength(0); r++)
            {
                for (int c = 0; c < stairs.GetLength(1); c++)
                {
                    double distanceR = r - bomb[0];
                    double distanceC = c - bomb[1];
                    double distance = Math.Sqrt(distanceC * distanceC + distanceR * distanceR);
                    if (distance <= radius)
                    {
                        stairs[r, c] = ' ';
                    }
                }
            }
        }

        static private void ClearingStairs(char[,] stairs, int rows)
        {
            for (int r = rows - 2; r >= 0; r--)
            {
                for (int c = 0; c < stairs.GetLength(1); c++)
                {
                    if (!char.IsWhiteSpace(stairs[r, c]))
                    {
                        int count = CountWhiteSpaces(stairs, r, c);
                        if (count > 0)
                        {
                            stairs[r + count, c] = stairs[r, c];
                            stairs[r, c] = ' ';
                        }
                    }
                }
            }
        }

        private static int CountWhiteSpaces(char[,] stairs, int r, int c)
        {
            int count = 0;
            for (int row = r; row < stairs.GetLength(0); row++)
            {
                if (char.IsWhiteSpace(stairs[row, c]))
                {
                    count++;
                }
            }

            return count;
        }
    }
}