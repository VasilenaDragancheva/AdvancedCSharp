using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringMatrixRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] command = Console.ReadLine().Split(new char[] { ')', '(' }, StringSplitOptions.RemoveEmptyEntries);
            int degrees = int.Parse(command[1]) % 360;
            List<string> matrix = new List<string>();
            string line;
            int rowsOriginal = 0;
            int colsOriginal = 0;
            while (true)
            {
                line = Console.ReadLine();
                if (line.ToLower() == "end")
                {
                    break;
                }

                matrix.Add(line);
            }
            colsOriginal = matrix.Max(row => row.Length);
            rowsOriginal = matrix.Count;
            int times = degrees / 90;
            for (int i = 0; i < times;i++ )
            {
                matrix = RotateMatrix(matrix);
            }
            foreach (string row in matrix)
            {
                Console.WriteLine(row);
            }
        }

        private static List<string> RotateMatrix(List<string> matrix)
        {
            List<string> rotatedMatrix = new List<string>();
            int rowsOriginal = matrix.Count;
            int colsOriginal = matrix.Max(row => row.Length);
            for (int r = 0; r < colsOriginal; r++)
            {
                List<char> word = new List<char>();
                for (int c = rowsOriginal - 1; c >= 0; c--)
                {
                    if (r >= matrix[c].Length)
                    {
                        word.Add(' ');
                    }
                    else
                    {
                        word.Add(matrix[c][r]);
                    }
                }
                rotatedMatrix.Add(new string(word.ToArray()));
            }
           return rotatedMatrix;
        }

    }
}