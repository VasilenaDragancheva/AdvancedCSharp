using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixShuffle
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int startRow = 0;
            int startCol = 0;

            char[] directions = new char[] { 'r', 'd', 'l', 'u' };//r l u d
            int cells = 0;// counting cell
            int limit = matrix.Length;
            int stepsInDirection = n - 1;//startrs
            int indexOfDirection = 0;
            int stepsInCurrentDirection = -1;
            int flag = 3;
            int directionsWithSameSteps = 0;

            while (cells < limit)
            {
                matrix[startRow, startCol] = cells < text.Length ? text[cells] : ' ';
                cells++;
                stepsInCurrentDirection++;
                if (stepsInCurrentDirection == stepsInDirection)
                {
                    stepsInCurrentDirection = 0;
                    indexOfDirection++;
                    directionsWithSameSteps++;
                    flag = cells < 3 * n ? 3 : 2;
                    if (directionsWithSameSteps == flag)
                    {
                        directionsWithSameSteps = 0;
                        stepsInDirection--;
                    }

                }
                char direction = directions[indexOfDirection % 4];
                switch (direction)
                {
                    case 'r':
                        startCol++;
                        break;
                    case 'l':
                        startCol--;
                        break;
                    case 'u':
                        startRow--;
                        break;
                    case 'd':
                        startRow++;
                        break;
                }
            }
            StringBuilder white = new StringBuilder();
            StringBuilder black = new StringBuilder();
            for (int r = 0; r < n; r++)
            {
                for (int c = 0; c < n; c++)
                {
                    if ((r % 2 == 0 && c % 2 == 1) || (r % 2 == 1 && c % 2 == 0))
                    {
                        white.Append(matrix[r, c].ToString());
                    }
                    else
                    {
                        black.Append(matrix[r, c].ToString());
                    }
                }

            }
           black.Append(white.ToString());
            char[] reversed = black.ToString().ToLower().ToCharArray();
            Array.Reverse(reversed);
            if(black.ToString().ToLower()!=new string(reversed))
            {
                Console.WriteLine("<div style='background-color:#E0000F'>{0}</div>",black.ToString());
            }
            else
            {
                Console.WriteLine("<div style='background-color:#4FE000'>{0}</div>",black.ToString());
            }
        }
    }
}