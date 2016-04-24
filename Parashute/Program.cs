using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections;

class Homewokrd
{
    public static void Main()
    {
        int rows = int.Parse(Console.ReadLine());
        int cols = int.Parse(Console.ReadLine());
        int[,] matrix = new int[rows, cols];

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                matrix[r, c] = int.Parse(Console.ReadLine());
            }
        }
        string line;
        while (true)
        {
            line = Console.ReadLine();
            if (line.ToLower() == "end")
            {
                break;
            }
            string[] command = line.Split(' ');
            bool validCoordinates = ValidCommand(command, rows, cols);
            if(!validCoordinates)
            {
               Console.WriteLine("Invalid input!");
               continue;   
            }
            else
            {
               Swaping(matrix, command);
            }
        }

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                Console.Write(matrix[r,c]);
            }
            Console.WriteLine();
        }
    }

    private static void Swaping(int[,] matrix, string[] command)
    {
        int[] coordinates = command.Skip(1).Select(int.Parse).ToArray();
            int row1 = coordinates[0];
            int col1 = coordinates[1];
            int row2 = coordinates[2];
            int col2 = coordinates[3];
            int number1 = matrix[row1, col1];
            int buffer = number1;
            int number2 = matrix[row2,col2];
            matrix[row1, col1] = number2;
            matrix[row2,col2] = buffer;

    }

    private static bool ValidCommand(string[] command, int rows, int cols)
    {
        bool validCommand = true;
        if (command[0] != "swap")
        {
            validCommand = false;
        }
        else
        {
            int[] coordinates = command.Skip(1).Select(int.Parse).ToArray();
            int row1 = coordinates[0];
            int col1 = coordinates[1];
            int row2 = coordinates[2];
            int col2 = coordinates[3];
            if (row1 < 0 || row1 >= rows || row2 < 0 || row2 >= rows || col1 < 0 || col2 < 0 || col1 >= cols || col2 >= cols)
            {
                validCommand = false;
            }
        }
        return validCommand;
    }
}