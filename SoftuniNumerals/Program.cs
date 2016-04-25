namespace SoftuniNumerals
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, int> numbers = new Dictionary<string, int>
                                                  {
                                                      { "aa", 0 }, 
                                                      { "aba", 1 }, 
                                                      { "bcc", 2 }, 
                                                      { "cc", 3 }, 
                                                      { "cdc", 4 }
                                                  };
            string pattern = @"(aa|aba|bcc|cc|cdc)";
            Regex regex = new Regex(pattern);
            string line = Console.ReadLine();
            List<int> convertedNumber = new List<int>();

            Match match = regex.Match(line);
            while (match.Success)
            {
                string findNumber = match.Groups[1].ToString();
                int num = numbers[findNumber];
                convertedNumber.Add(num);
                match = match.NextMatch();
            }

            BigInteger coverted = 0;
            int power = 0;
            for (int i = convertedNumber.Count - 1; i >= 0; i--)
            {
                BigInteger currentPow = CurrentPow(power);
                coverted += currentPow * convertedNumber[i];
                power++;
            }

            Console.WriteLine(coverted);
        }

        private static BigInteger CurrentPow(int power)
        {
            BigInteger result = 1;
            for (int i = 0; i < power; i++)
            {
                result *= 5;
            }

            return result;
        }
    }
}