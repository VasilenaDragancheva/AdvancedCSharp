namespace Longest
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            int row = int.Parse(Console.ReadLine());
            int col = int.Parse(Console.ReadLine());
            string[,] matrix = new string[row, col];
            for (int r = 0; r < row; r++)
            {
                for (int c = 0; c < col; c++)
                {
                    matrix[r, c] = Console.ReadLine();
                }
            }

            for (int r = 0; r < row; r++)
            {
                for (int c = 0; c < col; c++)
                {
                    int down = DownCount(matrix, r, c);
                    int right = RightCount(matrix, r, c);
                    int diag1 = Diagonal1(matrix, r, c);
                    int diag2 = Diagonal2(matrix, r, c);
                }
            }
        }

        private static int Diagonal2(string[,] matrix, int r, int c)
        {
            return 5;
        }

        private static int RightCount(string[,] matrix, int r, int c)
        {
            throw new NotImplementedException();
        }

        private static int Diagonal1(string[,] matrix, int r, int c)
        {
            throw new NotImplementedException();
        }

        private static int DownCount(string[,] matrix, int r, int c)
        {
            throw new NotImplementedException();
        }
    }
}