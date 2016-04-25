namespace CommandInterpeteter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine().Split();
            string line;
            while (true)
            {
                line = Console.ReadLine();
                if (line.ToLower() == "end")
                {
                    break;
                }

                string[] command = line.Split(' ');
                switch (command[0])
                {
                    case "sort":
                        SortExecute(command, array);
                        break;
                    case "reverse":
                        ReverseExecute(command, array);
                        break;

                    case "rollLeft":
                        ExecuteRollLeft(command, array);
                        break;
                    case "rollRight":
                        ExecuteRollRight(command, array);
                        break;
                }
            }
        }

        private static void ExecuteRollRight(string[] command, string[] array)
        {
            int times = int.Parse(command[1]);
            if (times < 0)
            {
                Console.WriteLine("Invalid input parameters.");
            }
            else
            {
                times %= array.Length;
                int left = array.Length - times;
                List<string> list = array.ToList();
                string[] moved = list.Skip(left).ToArray();

                array = list.ToArray();
            }
        }

        private static void ExecuteRollLeft(string[] command, string[] array)
        {
            int times = int.Parse(command[1]);
            if (times < 0)
            {
                Console.WriteLine("Invalid input parameters.");
            }
            else
            {
                times %= array.Length;
                List<string> list = array.ToList();
                string[] moved = list.Take(times).ToArray();
                list.RemoveRange(0, times);
                list.AddRange(moved);
                array = list.ToArray();
            }
        }

        private static void ReverseExecute(string[] command, string[] array)
        {
            int start = int.Parse(array[2]);
            int count = int.Parse(array[4]);
            if (start < 0 || start >= array.Length || count < 0 || start + count >= array.Length)
            {
                Console.WriteLine("Invalid input parameters.");
            }
            else
            {
                Array.Reverse(array, start, count);
            }
        }

        private static void SortExecute(string[] command, string[] array)
        {
            int start = int.Parse(array[2]);
            int count = int.Parse(array[4]);
            if (start < 0 || start >= array.Length || count < 0 || start + count >= array.Length)
            {
                Console.WriteLine("Invalid input parameters.");
            }
            {
                Array.Sort(array, start, count);
            }
        }
    }
}