namespace ParkSYstem
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensios =
                Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            int rows = dimensios[0];
            int cols = dimensios[1];
            int[,] parking = new int[rows, cols];

            string line;
            while (true)
            {
                line = Console.ReadLine();
                if (line.ToLower() == "stop")
                {
                    break;
                }

                int[] dimensions =
                    line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                int currentRow = dimensions[0];
                int desiredRow = dimensions[1];
                int desiredCol = dimensions[2];
                if (parking[desiredRow, desiredCol] == 0)
                {
                    int movesMade = Math.Abs(desiredRow - currentRow) + 1 + desiredCol;
                    parking[desiredRow, desiredCol] = 1;
                    Console.WriteLine(movesMade);
                    continue;
                }

                bool isAnyFreeSpace = false;
                for (int i = 1; i < cols; i++)
                {
                    if (parking[desiredRow, i] == 0)
                    {
                        isAnyFreeSpace = true;
                        break;
                    }
                }

                if (!isAnyFreeSpace)
                {
                    Console.WriteLine("Row {0} full", desiredRow);
                    continue;
                }

                int colBefore = -1;
                int colsAfter = -1;

                for (int c = desiredCol - 1; c >= 1; c--)
                {
                    if (parking[desiredRow, c] == 0)
                    {
                        colBefore = c;
                        break;
                    }
                }

                for (int c = desiredCol + 1; c < cols; c++)
                {
                    if (parking[desiredRow, c] == 0)
                    {
                        colsAfter = c;
                        break;
                    }
                }

                int availableColumn = 0;

                if (colBefore == -1)
                {
                    availableColumn = colsAfter;
                }
                else if (colsAfter == -1)
                {
                    availableColumn = colBefore;
                }
                else
                {
                    var distanceBefore = desiredCol - colBefore;
                    var distanceAfter = -desiredCol + colsAfter;
                    if (distanceBefore <= distanceAfter)
                    {
                        availableColumn = colBefore;

                    }
                    else
                    {
                        availableColumn = colsAfter;
                    }
                }

                var distance = Math.Abs(desiredRow + currentRow) + availableColumn;
                parking[desiredRow, availableColumn] = 1;
                Console.WriteLine(distance);
            }
        }
    }
}

