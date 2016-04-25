namespace TeerroristWIn
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            char[] line = Console.ReadLine().ToCharArray();

            for (int i = 0; i < line.Length; i++)
            {
                int start = 0;
                int end = 0;
                if (line[i] == '|')
                {
                    start = i;
                    end = i + 1;
                    
                    while (end < line.Length)
                    {
                        if (line[end] == '|')
                        {
                            break;
                        }

                        end++;
                    }

                    int power = 0;
                    for (int c = start + 1; c <= end - 1; c++)
                    {
                        power += line[c];
                    }

                    power %= 10;
                    int startBomb = Math.Max(0, start - power);
                    int endBomb = Math.Min(line.Length - 1, end + power);
                    for (int j = startBomb; j <= endBomb; j++)
                    {
                        line[j] = '.';
                    }

                    i = endBomb;
                }
            }

            Console.WriteLine(line);
        }
    }
}