using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class Program
{
    public static void Main()
    {
        List<string> output = new List<string>();
        string actionTag = "<\\s*(reverse|inverse|repeat)\\s*";
        string contentTag = "content\\s*=\\s*\"(.*?)\"\\s*/\\s*>";
        string patterEnd = "<\\s*stop\\s*/\\s*>";

        var regexAction = new Regex(actionTag);
        var regextText = new Regex(contentTag);

        var regexEnd = new Regex(patterEnd);
        string line;
        while (true)
        {
            line = Console.ReadLine();
            if (regexEnd.IsMatch(line))
            {
                break;
            }

            var content = regextText.Match(line).Groups[1].ToString();
            if (string.IsNullOrEmpty(content))
            {
                continue;
            }

            var action = regexAction.Match(line);
            var tagAction = action.Groups[1].ToString();

            switch (tagAction)
            {
                case "repeat":
                    try
                    {
                        int times = FindTimes(line);
                        var result = Enumerable.Repeat(content, times);
                        output.AddRange(result);
                    }
                    catch (FormatException)
                    {
                    }

                    break;
                case "inverse":
                    char[] inveresed = content.ToCharArray().Select(InverseChar).ToArray();
                    output.Add(new string(inveresed));
                    break;
                case "reverse":
                    output.Add(new string(content.ToCharArray().Reverse().ToArray()));
                    break;
            }
        }

        PrintResult(output);
    }

    private static void PrintResult(List<string> output)
    {
        int counter = 1;
        foreach (var line in output)
        {
            Console.WriteLine("{0}. {1}", counter, line);
            counter++;
        }
    }

    private static char InverseChar(char ch)
    {
        if (char.IsLower(ch))
        {
            return char.Parse(ch.ToString().ToUpper());
        }

        if (char.IsUpper(ch))
        {
            return char.Parse(ch.ToString().ToLower());
        }

        return ch;
    }

    private static int FindTimes(string line)
    {
        var patternTimes = "\\bvalue=\\s*\"([0-9]|10)\"\\B";
        var regex = new Regex(patternTimes);
        var times = int.Parse(regex.Match(line).Groups[1].ToString());

        return times;
    }
}