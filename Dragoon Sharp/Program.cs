namespace Dragoon_Sharp
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> input = new List<string>();
            string pattern = "(if\\s+\\((.*)\\)|else)\\s+(loop\\s+\\d{1,2}\\s+)?out\\s+\"(.*)\"\\s*;";
            Regex validCommand = new Regex(pattern);
            bool compileError = false;
            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                if (!validCommand.IsMatch(line))
                {
                    Console.WriteLine("Compile time error @ line {0}", i + 1);
                    compileError = true;
                    break;
                }

                input.Add(line);
            }

            if (!compileError)
            {
                for (int i = 0; i < input.Count; i++)
                {
                    Match command = validCommand.Match(input[i]);
                    if (command.Groups[1].Value.Contains("if"))
                    {
                        bool validCondition = ValidCondition(command);
                        if (validCondition)
                        {
                            ExecuteCommand(command);
                            command = validCommand.Match(input[i + 1]);

                            string nextCommand = command.Groups[1].ToString();
                            if (nextCommand == "else")
                            {
                                i += 1;
                            }
                        }
                        else
                        {
                            command = validCommand.Match(input[i + 1]);

                            string nextCommand = command.Groups[1].ToString();
                            if (nextCommand == "else")
                            {
                                ExecuteCommand(command);
                                i += 1;
                            }
                        }
                    }
                }
            }
        }

        private static void ExecuteCommand(Match command)
        {
            string text = command.Groups[7].ToString();
            int times;
            if (string.IsNullOrEmpty(command.Groups[6].ToString()))
            {
                times = 1;
            }
            else
            {
                times = int.Parse(command.Groups[6].ToString().Split()[1]);
            }

            for (int i = 0; i < times; i++)
            {
                Console.WriteLine(text);
            }
        }

        private static bool ValidCondition(Match command)
        {
            bool valid = false;

            string num1 = command.Groups[3].Value;
            string num2 = command.Groups[5].Value;
            string sign = command.Groups[4].Value;
            switch (sign)
            {
                // case "<":
                // if (num1 < num2)
                // {
                // valid = true;
                // }
                // break;
                // case ">":
                // if (num1 > num2)
                // {
                // valid = true;
                // }
                // break;
                case "==":
                    if (num1 == num2)
                    {
                        valid = true;
                    }

                    break;
            }

            return valid;
        }
    }
}