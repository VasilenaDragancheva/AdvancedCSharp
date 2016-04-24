using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunkerBuster
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            int[][] matrix = new int[rows][];
            for (int r = 0; r < rows; r++)
            {
                 matrix[r] = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
               
            }
            string line;
            while (true)
            {
                line = Console.ReadLine();
                if (line == "cease fire!")
                {
                    break;
                }
                Bombing(matrix, line,rows,cols);
            }

            int destroyed = 0;
            for(int r=0;r<rows;r++)
            {
                destroyed += matrix[r].Where(x => x <= 0).Count();
            }
            double max = rows * cols;
            double damage = destroyed * 100 / max;
            Console.WriteLine("Destroyed bunkers: {0}",destroyed);
            Console.WriteLine("Damage done: {0:f1} %",damage);
        }

        private static void Bombing(int[][] matrix, string line,int rows,int cols)
        {
            int row = int.Parse(line.Split(' ')[0]);
            int col = int.Parse(line.Split(' ')[1]);
            int power = char.Parse(line.Split(' ')[2]);
            int powerNeighb= (int) Math.Ceiling((double) power / 2);
            int startR = Math.Max(row - 1, 0);
            int endR = Math.Min(row + 1, rows - 1);
            int startC = Math.Max(col - 1, 0);
            int endC=Math.Min(col+1,cols-1);
            matrix[row][col] -= power;
            for (int r = startR; r <= endR; r++)
            {
                for(int c=startC;c<=endC;c++)
                {
                    if (c == col && r == row)
                    {
                        continue;
                    }
                    matrix[r][c] -= powerNeighb;
                }
            }
        }
    }
}
