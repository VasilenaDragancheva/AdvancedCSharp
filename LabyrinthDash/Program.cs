namespace LabyrinthDash
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[][] labyrinth = new char[n][];
            for (int i = 0; i < n; i++)
            {
                labyrinth[i] = Console.ReadLine().ToCharArray();
            }

            int totalMoves = 0;
            int lives = 3;
            string commands = Console.ReadLine();
            int rowCurrent = 0;
            int colCurrent = 0;
            int rowNext = 0;
            int colNext = 0;

            for (int i = 0; i < commands.Length; i++)
            {
                char command = commands[i];

                switch (command)
                {
                    case '>':
                        rowNext = rowCurrent;
                        colNext = colCurrent + 1;
                        break;
                    case '<':
                        rowNext = rowCurrent;
                        colNext = colCurrent - 1;
                        break;
                    case '^':
                        rowNext = rowCurrent - 1;
                        colNext = colCurrent;
                        break;
                    case 'v':
                        rowNext = rowCurrent + 1;
                        colNext = colCurrent;
                        break;
                }

                if (rowNext >= n || colNext >= labyrinth[rowNext].Length || rowNext < 0 || colNext < 0
                    || char.IsWhiteSpace(labyrinth[rowNext][colNext]))
                {
                    totalMoves++;
                    Console.WriteLine("Fell off a cliff! Game Over!");
                    break;
                }

                char nextPosition = labyrinth[rowNext][colNext];
                switch (nextPosition)
                {
                    case '|':
                    case '_':
                        Console.WriteLine("Bumped a wall.");
                        break;
                    case '.':
                        Console.WriteLine("Made a move!");
                        totalMoves++;
                        rowCurrent = rowNext;
                        colCurrent = colNext;
                        break;
                    case '@':
                    case '#':
                    case '*':
                        lives--;
                        Console.WriteLine("Ouch! That hurt! Lives left: {0}", lives);
                        rowCurrent = rowNext;
                        colCurrent = colNext;
                        totalMoves++;
                        break;
                    case '$':
                        lives++;
                        Console.WriteLine("Awesome! Lives left: {0}", lives);
                        rowCurrent = rowNext;
                        colCurrent = colNext;
                        labyrinth[rowCurrent][colCurrent] = '.';
                        totalMoves++;
                        break;
                }

                if (lives == 0)
                {
                    Console.WriteLine("No lives left! Game Over!");
                    break;
                }
            }

            Console.WriteLine("Total moves made: {0}", totalMoves);
        }
    }
}